using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _4Bugs.Models.Mambu
{
    public partial class Deposit
    {
        public Deposit()
        {
            type = "DEPOSIT";
            method = "bank";
            notes = "Test";
            customInformation = new customInformation[] { new customInformation() };
        }
        [JsonProperty("amount")]
        public long amount { get; set; }

        [JsonProperty("notes")]
        public string notes { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("method")]
        public string method { get; set; }

        [JsonProperty("customInformation")]
        public customInformation[] customInformation { get; set; }
    }

    public partial class customInformation
    {
        public customInformation()
        {
            value = "unique identifier for receipt";
            customFieldID = "IDENTIFIER_TRANSACTION_CHANNEL_I";
        }
        [JsonProperty("value")]
        public string value { get; set; }

        [JsonProperty("customFieldID")]
        public string customFieldID { get; set; }
    }
}
