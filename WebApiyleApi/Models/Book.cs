using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiyleApi.Models
{
    [Table("Book")]
    public class Book : Identity
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonProperty("author")]
        public string Author { get; set; }
        [JsonProperty("isbn")]
        public string ISBN { get; set; }
        [JsonProperty("createdtime")]
        public DateTime CreatedTime{ get; set; }
        [JsonProperty("isvalid")]
        public bool IsValid { get; set; }
    }
}