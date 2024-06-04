using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MPIapi.Models.Dto
{
    public class ItemDto
    {
        
        [JsonProperty("Id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("UnitWeight", NullValueHandling = NullValueHandling.Ignore)]
        public long? UnitWeight { get; set; }

        [JsonProperty("UnitHeigth", NullValueHandling = NullValueHandling.Ignore)]
        public long? UnitHeigth { get; set; }

        [JsonProperty("UnitLength", NullValueHandling = NullValueHandling.Ignore)]
        public long? UnitLength { get; set; }

        [JsonProperty("UnitWidth", NullValueHandling = NullValueHandling.Ignore)]
        public long? UnitWidth { get; set; }

        //Unidad de medida, dejado por si es escalable
        [JsonProperty("UOM", NullValueHandling = NullValueHandling.Ignore)]
        public string Uom { get; set; }

        [JsonProperty("Fragil", NullValueHandling = NullValueHandling.Ignore)]
        public bool Fragil { get; set; }

        [JsonProperty("Inflamable", NullValueHandling = NullValueHandling.Ignore)]
        public bool Inflamable { get; set; }

        //Caras o identificador de los items
        

        //NUMERO DE ETIQUETA
        // [JsonProperty("SKU", NullValueHandling = NullValueHandling.Ignore)]
        // public string Sku { get; set; } 

        // [JsonProperty("LotNumber", NullValueHandling = NullValueHandling.Ignore)]
        // public string LotNumber { get; set; }

        // [JsonProperty("SerialNumber", NullValueHandling = NullValueHandling.Ignore)]
        // public string SerialNumber { get; set; }

        // [JsonProperty("Description", NullValueHandling = NullValueHandling.Ignore)]
        // public string Description { get; set; }

        // [JsonProperty("Description2", NullValueHandling = NullValueHandling.Ignore)]
        // public string Description2 { get; set; }

        // [JsonProperty("Description3", NullValueHandling = NullValueHandling.Ignore)]
        // public string Description3 { get; set; }

        // [JsonProperty("Quantity", NullValueHandling = NullValueHandling.Ignore)]
        // public long? Quantity { get; set; }


        // [JsonProperty("NetUnitWeight", NullValueHandling = NullValueHandling.Ignore)]
        // public long? NetUnitWeight { get; set; }


        //[JsonProperty("DangerousGoods", NullValueHandling = NullValueHandling.Ignore)]
        //public DangerousGoods DangerousGoods { get; set; }
    
    }
}