using Microsoft.Extensions.Primitives;

namespace NSEWebApp.Models
{
    public class MyConfiguration
    {
        public class ConnectionStrings
        {
            public string AllowedHosts { get; set; }
            public string SqlConnection { get; set; }
        }
    }
}
