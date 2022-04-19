using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkerService.Models;

namespace WorkerService.Processors
{
    public class IncidentsCounter : IProcessor
    {
        private readonly Dictionary<int, int> _counter = new();
        public void Process(Record record)
        {
            if (_counter.ContainsKey(record.RiskLevel))
                _counter[record.RiskLevel]++;
            else
                _counter.Add(record.RiskLevel, 1);
        }

        public void ShowResult()
        {
            Console.WriteLine($"# of incidents:");
            foreach (var kv in _counter.OrderBy(kv => kv.Key))
            {
                Console.WriteLine("{0,6}: {1,6}", kv.Key, kv.Value);
            }
            Console.WriteLine("{0,6}: {1,6}", "Total", _counter.Sum(kv => kv.Value));
        }
    }
}