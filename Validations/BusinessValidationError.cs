using System.Collections.Generic;
using WebAPIRuleEngine.Codes;
using Newtonsoft.Json;

namespace WebAPIRuleEngine.Validations
{
    public class BusinessValidationError
    {
        /// <summary>
        /// Gets or sets the name of the fields concerned by the validation error
        /// </summary>
        [JsonProperty(PropertyName = "fields")]
        public List<string> Fields { get; set; }

        /// <summary>
        /// Gets or sets the error message
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

        /// <summary>
        /// Gets or sets the error code
        /// </summary>
        [JsonProperty(PropertyName = "errorCode")]
        public BusinessErrorCodes ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the validation criteries
        /// </summary>
        [JsonProperty(PropertyName = "validation")]
        public object Validation { get; set; }
    }
}
