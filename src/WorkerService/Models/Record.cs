using System;
using Newtonsoft.Json;
using WorkerService.JsonHelpers;

namespace WorkerService.Models
{
    public class Record
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public string Email { get; set; }
        public string Risk { get; set; }
        public int RiskLevel { get; set; }
        
        [JsonConverter(typeof(ActiveConverter))]
        public bool Active { get; set; }
        
        [JsonConverter(typeof(MetaConverter))]
        public Meta Meta { get; set; }
    }
}