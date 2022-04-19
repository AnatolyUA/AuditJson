using System;
using Newtonsoft.Json;

namespace WorkerService.JsonHelpers
{
    public class ActiveConverter : JsonConverter<bool>
    {
        public override void WriteJson(JsonWriter writer, bool value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool ReadJson(JsonReader reader, Type objectType, bool existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var str =  serializer.Deserialize<string>(reader);
            return "t".Equals(str, StringComparison.OrdinalIgnoreCase);
        }
    }
}