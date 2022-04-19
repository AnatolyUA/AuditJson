using System.Threading.Tasks;
using WorkerService.Models;

namespace WorkerService.Processors
{
    public interface IProcessor
    {
        public void Process(Record @record);
        public void ShowResult();
    }
}