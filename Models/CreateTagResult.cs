using System;

namespace webapi_template_2.Controllers
{
    public class CreateTagResult
    {
        public bool Success { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.UtcNow;
    }
}