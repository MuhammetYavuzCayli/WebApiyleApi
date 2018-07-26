using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiyleApi.Models
{
    [Table("UserBookRelation")]
    public class UserBookRelation : Identity
    {
        [JsonProperty("userid")]
        public int UserId { get; set; }
        [JsonProperty("bookid")]
        public int BookId { get; set; }
        [JsonProperty("time")]
        public DateTime time{ get; set; }

        public Book Book { get; set; }
        public User User { get; set; }
    }
}