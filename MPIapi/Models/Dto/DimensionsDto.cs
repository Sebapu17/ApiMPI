using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MPIapi.Models.Dto
{
    public class DimensionsDto
    
    {
        [JsonProperty("PackagingWeight", NullValueHandling = NullValueHandling.Ignore)]
        public long? PackagingWeight { get; set; }

        [JsonProperty("Width", NullValueHandling = NullValueHandling.Ignore)]
        public long? Width { get; set; }

        [JsonProperty("Height", NullValueHandling = NullValueHandling.Ignore)]
        public long? Height { get; set; }

        [JsonProperty("Length", NullValueHandling = NullValueHandling.Ignore)]
        public long? Length { get; set; }

        [JsonProperty("DimensionsUOM", NullValueHandling = NullValueHandling.Ignore)]
        public string DimensionsUom { get; set; }
    }
}