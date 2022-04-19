using System;
using System.IO;
using Newtonsoft.Json;
using WorkerService.Models;

namespace WorkerService.JsonHelpers
{
    public class MetaConverter : JsonConverter<Meta>
    {
        public override void WriteJson(JsonWriter writer, Meta? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override Meta? ReadJson(JsonReader reader, Type objectType, Meta? existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            var str =  serializer.Deserialize<string>(reader);
            return serializer.Deserialize<Meta>(new JsonTextReader(new StringReader(str)));
        }
    }
}