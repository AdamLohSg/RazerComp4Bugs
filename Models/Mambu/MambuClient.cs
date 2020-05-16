using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _4Bugs.Models.Mambu
{
    public class MambuClient
    {
        public MambuClient()
        {
            client = new client();
            idDocuments = new IDDocument[] {new IDDocument()};
            addresses = new object[] { };
            CustomInformation = new CustomInformation[] { new CustomInformation("Singapore", "countryOfBirth") };

        }
        [JsonProperty("client")]
        public client client { get; set; }

        [JsonProperty("idDocuments")]
        public IDDocument[] idDocuments { get; set; }

        [JsonProperty("addresses")]
        public object[] addresses { get; set; }
        [JsonProperty("customInformation")]
        public CustomInformation[] CustomInformation { get; set; }

    }

    public class client
    {
        //NEEDED
        [JsonProperty("firstName")]
        public string firstName { get; set; }
        //NEEDED
        [JsonProperty("lastName")]
        public string lastName { get; set; }

        [JsonProperty("preferredLanguage")]
        public string preferredLanguage { get; set; }

        [JsonProperty("notes")]
        public string notes { get; set; }

        [JsonProperty("assignedBranchKey")]
        public string assignedBranchKey { get; set; }
    }
    public partial class CustomInformation
    {

        public CustomInformation(string value, string CustomFieldId)
        {
            this.value = value;
            this.customFieldID = CustomFieldId;
        }

        [JsonProperty("value")]
        public string value { get; set; }

        [JsonProperty("customFieldID")]
        public string customFieldID { get; set; }
    }

}
