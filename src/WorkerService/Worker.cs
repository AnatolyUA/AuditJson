using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WorkerService.Processors;

namespace WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHostApplicationLifetime _lifetime;
        private readonly AuditReader _reader;
        private readonly IEnumerable<IProcessor> _processors;

        public Worker(ILogger<Worker> logger, AuditReader reader, IEnumerable<IProcessor> processors, IHostApplicationLifetime lifetime)
        {
            _logger = logger;
            _reader = reader;
            _processors = processors;
            _lifetime = lifetime;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await foreach (var @record in _reader.ReadAsync("/users/mac/downloads/audit.json").WithCancellation(stoppingToken))
                foreach (var processor in _processors)
                    processor.Process(@record);

            foreach (var processor in _processors)
                processor.ShowResult();
            
            _lifetime.StopApplication();
        }
    }
}