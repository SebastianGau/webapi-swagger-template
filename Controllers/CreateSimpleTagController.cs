using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webapi_template_2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreateSimpleTagController : Controller
    {
        public CreateSimpleTagController()
        {

        }

        [HttpPost]
        public async Task<CreateTagResult> Get([FromBody] CreateTagInformation input)
        {
            //do something here
            return new CreateTagResult()
            {
                Success = true
            };
        }
    }
}