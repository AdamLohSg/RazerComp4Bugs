using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace _4Bugs.Models.Mambu
{
    public class IDDocument
    {
        [JsonProperty("encodedKey")]
        public string EncodedKey { get; set; }

        [JsonProperty("documentType")]
        public string DocumentType { get; set; }

        [JsonProperty("issuingAuthority")]
        public string IssuingAuthority { get; set; }

        [JsonProperty("documentIdTemplate")]
        public string DocumentIdTemplate { get; set; }

        [JsonProperty("mandatoryForClients")]
        public bool MandatoryForClients { get; set; }

        [JsonProperty("allowAttachments")]
        public bool AllowAttachments { get; set; }
    }
}
