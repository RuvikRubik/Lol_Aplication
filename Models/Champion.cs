using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lol_Aplication.Models
{
    public class Champion
    {
        [JsonPropertyName("id")]
        public string ID { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        public string ModelId { get; set; }

        [JsonPropertyName("skins")]
        public List<Skin> Skins { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        [JsonPropertyName("stats")]
        public Stats Stats { get; set; }

        public string TagsText => string.Join(", ", Tags);

        public string ImageUrl { get; set; }
    }


}
