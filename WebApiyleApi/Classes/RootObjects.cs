using Newtonsoft.Json;
using System.Collections.Generic;
using WebApiyleApi.Models;

namespace WebApiyleApi.Classes
{
    public class RootObjects
    {
        [JsonProperty("results")]
        public Results Result { get; set; }

        public class Results
        {
            [JsonProperty("Users")]
            public Dictionary<string, User> User { get; set; }
            [JsonProperty("Books")]
            public Dictionary<string, Book> Book { get; set; }
            [JsonProperty("UserBookRelations")]
            public Dictionary<string, UserBookRelation> UserBookRelation { get; set; }
        }
    }
}