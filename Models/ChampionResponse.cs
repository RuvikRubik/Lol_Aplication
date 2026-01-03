using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lol_Aplication.Models
{
    public class Json
    {
        [JsonPropertyName("data")]
        public Dictionary<string, Champion> champions { get; set; }
    }
}
