using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace _4Bugs.Models.Mambu
{
    public class IDDocument
    {

        [JsonProperty("documentType")]
        public string documentType { get; set; }

        [JsonProperty("issuingAuthority")]
        public string issuingAuthority { get; set; }

        [JsonProperty("identificationDocumentTemplateKey")]
        public string identificationDocumentTemplateKey { get; set; }
        //Validation Date  NEEDED
        [JsonProperty("validUntil")]
        public string validUntil { get; set; }
        //NRIC NEEDED
        [JsonProperty("documentId")]
        public string documentId { get; set; }
    }
}
