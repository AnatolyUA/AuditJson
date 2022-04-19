using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using WorkerService.JsonHelpers;
using WorkerService.Models;

namespace WorkerService
{
    public class AuditReader
    {
        public async IAsyncEnumerable<Record> ReadAsync(string path)
        {
            await using var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            using var sr = new StreamReader(fs);
            using var reader = new JsonTextReader(sr);
            
            var serializer = new JsonSerializer
            {
                ContractResolver = new UnderscorePropertyNamesContractResolver(),
                DateFormatString = "dd/MM/yyyy HH:mm:ss.FFFFFFzz"
            };

            while (await reader.ReadAsync())
            {
                if (reader.TokenType != JsonToken.StartArray)
                    continue;
                
                Console.WriteLine(reader.Path);
                while (await reader.ReadAsync())
                {
                    if(reader.TokenType == JsonToken.EndArray)
                        break;
                    if (reader.TokenType != JsonToken.StartObject) 
                        continue;
                        
                    var record = serializer.Deserialize<Record>(reader);
                    yield return record;
                }
            }
        }
    }
}