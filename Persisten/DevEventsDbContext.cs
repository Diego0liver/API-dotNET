using apicrud.Entities;

namespace apicrud.Persisten
{
    public class DevEventsDbContext
    {
        public List<DevEnvent> DevEnvents { get; set; }

        public DevEventsDbContext()
        {
            DevEnvents = new List<DevEnvent>();
        }
    }
}
