using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiyleApi.Models
{
    [Table("User")]
    public class User : Identity
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("localtion")]
        public string Location { get; set; }
    }
}