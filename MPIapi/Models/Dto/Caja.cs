using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office.CustomUI;
using Newtonsoft.Json;

namespace MPIapi.Models.Dto
{
    public class Caja
    {
        [JsonProperty("Id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("Tipo", NullValueHandling = NullValueHandling.Ignore)]
        public string? Tipo { get; set; }

        [JsonProperty("Dimensiones", NullValueHandling = NullValueHandling.Ignore)]
        public DimensionsDto? Dimensiones { get; set; }

        [JsonProperty("Item", NullValueHandling = NullValueHandling.Ignore)]
        public List<ItemDto> items { get; set; }

        //Agregar atributo con disposición de las cajas

    }
}