using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
//using Newtonsoft.Json;

namespace webapi_template_2.Controllers
{
    public class CreateTagInformation
    {
        [Required]
        [StringLength(100)]
        public string AreaId { get; set; }
        [Required]
        public DataTypes DataType { get; set;}
        [Required]
        [StringLength(100)]
        public string SourceType { get; set; }
        [Required]
        [StringLength(100)]
        public string TagName { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        [Required]
        [StringLength(100)]
        public string Units { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DataTypes
    {
        Analog,
        Discrete,
        Text
    }
}