using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lol_Aplication.Models
{
    public class Skin
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("num")]
        public int Num { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("chromas")]
        public bool Chromas { get; set; }
    }
}
