using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lol_Aplication.Models
{
    public class Champion : INotifyPropertyChanged
    {
        [JsonPropertyName("id")]
        public string ID { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        [JsonPropertyName("stats")]
        public Stats Stats { get; set; }

        public string TagsText => string.Join(", ", Tags);

        public string ImageUrl { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private int _level = 1;
        public int Level
        {
            get => _level;
            set
            {
                if (_level != value)
                {
                    _level = value;
                    OnPropertyChanged(nameof(Level));

                    // informujemy UI, że staty się zmieniły
                    OnPropertyChanged(nameof(ComputedStats));
                }
            }
        }

        public ComputedStats ComputedStats => new ComputedStats(Stats, Level);
    }
}
