using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NSEWebApp.Models;
using System.Configuration;
using System.Data;

namespace NSEWeb.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IConfiguration Configuration;
        protected readonly string ConnectionString;
        //public MyConfiguration MyConfig { get; set; }

        public BaseController(IConfiguration config)
        {
            Configuration = config;
            ConnectionString = config.GetConnectionString("SqlConnection");
            //Configuration = config;
            
            //var myConfig = config.GetSection("myconfig").Get<MyConfiguration>();
            //config.GetSection("myconfig:root:inner").Bind(myConfig);


        }

    }
}
