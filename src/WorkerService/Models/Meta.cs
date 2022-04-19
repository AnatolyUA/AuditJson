namespace WorkerService.Models
{
    public class Meta
    {
        public string Content { get; set; }
        public string UserAgent { get; set; }
        public string IpExternal { get; set; }
        public string[] IpInternal { get; set; }
        public string BrowserUuid { get; set; }
    }
}