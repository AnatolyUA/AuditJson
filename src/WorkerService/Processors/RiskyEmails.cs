using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkerService.Models;

namespace WorkerService.Processors
{
    public class RiskyEmails : IProcessor
    {
        private readonly HashSet<string> _emails = new();
        public void Process(Record record)
        {
            if (record.RiskLevel > 0)
                _emails.Add(record.Email);
        }

        public void ShowResult()
        {
            Console.WriteLine("Risky emails:");
            foreach (var email in _emails)
            {
                Console.WriteLine(email);
            }
        }
    }
}