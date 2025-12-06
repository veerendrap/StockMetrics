using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Primitives;

namespace NSEWeb.Models
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
