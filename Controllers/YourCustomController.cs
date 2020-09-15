using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webapi_template_2.Models;

namespace webapi_template_2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class YourCustomController : ControllerBase
    {
        public YourCustomController()
        {
            
        }

        [HttpPost]
        public async Task<YourCustomObjectOutput> Get(YourCustomObjectInput input)
        {
            return new YourCustomObjectOutput
            {
                Arg1 = input.Arg1 + input.Arg2,
                Arg2 = input.Arg1 + input.Arg2
            };
        }

    }

}
