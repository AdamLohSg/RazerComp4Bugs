using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace _4Bugs.Models.Mambu
{
    public class Transfer
    {
        public Transfer()
        {
            type = "TRANSFER";
            method = "bank";
            notes = "transfer";
        }
         [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("amount")]
        public long amount { get; set; }

        [JsonProperty("notes")]
        public string notes { get; set; }

        [JsonProperty("toSavingsAccount")]
        public string toSavingsAccount { get; set; }

        [JsonProperty("method")]
        public string method { get; set; }
    }
}

