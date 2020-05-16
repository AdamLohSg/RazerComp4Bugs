using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace _4Bugs.Models.Mambu
{
 
    [DataContract(Name = "savingsAccount")]
    public class SavingsAccount
       
    {
        public SavingsAccount()
        {
            name = "Digital Account";
            accountHolderType = "CLIENT";
            accountState = "APPROVED";
            productTypeKey = "8a8e878471bf59cf0171bf6979700440";
            accountType = "CURRENT_ACCOUNT";
            currencyCode = "SGD";
            allowOverdraft= true;
            overdraftLimit = "100";
            overdraftInterestSettings = new overdraftInterestSettings();
            interestSettings = new interestSettings();
        }
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("accountHolderType")]
        public string accountHolderType { get; set; }

        [JsonProperty("accountHolderKey")]
        public string accountHolderKey { get; set; }

        [JsonProperty("accountState")]
        public string accountState { get; set; }

        [JsonProperty("productTypeKey")]
        public string productTypeKey { get; set; }

        [JsonProperty("accountType")]
        public string accountType { get; set; }

        [JsonProperty("currencyCode")]
        public string currencyCode { get; set; }

        [JsonProperty("allowOverdraft")]
        public bool allowOverdraft { get; set; }

        [JsonProperty("overdraftLimit")]
        public string overdraftLimit { get; set; }

        [JsonProperty("overdraftInterestSettings")]
        public overdraftInterestSettings overdraftInterestSettings { get; set; }

        [JsonProperty("interestSettings")]
        public interestSettings interestSettings { get; set; }
    }

    public partial class interestSettings
    {
        [JsonProperty("interestRate")]
        public string interestRate { get; set; }
    }

    public partial class overdraftInterestSettings
    {
        [JsonProperty("interestRate")]
        public float interestRate { get; set; }
    }
}


