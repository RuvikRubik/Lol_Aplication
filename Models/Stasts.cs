using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lol_Aplication.Models
{
    public class Stats
    {
        [JsonPropertyName("hp")]
        public float Hp { get; set; }

        [JsonPropertyName("hpperlevel")]
        public float HpPerLevel { get; set; }

        [JsonPropertyName("hpregen")]
        public float HpRegen { get; set; }

        [JsonPropertyName("hpregenperlevel")]
        public float HpRegenPerLevel { get; set; }

        [JsonPropertyName("mp")]
        public float Mp { get; set; }

        [JsonPropertyName("mpperlevel")]
        public float MpPerLevel { get; set; }

        [JsonPropertyName("mpregen")]
        public float MpRegen { get; set; }

        [JsonPropertyName("mpregenperlevel")]
        public float MpRegenPerLevel { get; set; }

        [JsonPropertyName("movespeed")]
        public float MoveSpeed { get; set; }

        [JsonPropertyName("armor")]
        public float Armor { get; set; }

        [JsonPropertyName("armorperlevel")]
        public float ArmorPerLevel { get; set; }

        [JsonPropertyName("spellblock")]
        public float SpellBlock { get; set; }

        [JsonPropertyName("spellblockperlevel")]
        public float SpellBlockPerLevel { get; set; }

        [JsonPropertyName("attackrange")]
        public float AttackRange { get; set; }

        [JsonPropertyName("crit")]
        public float Crit { get; set; }

        [JsonPropertyName("critperlevel")]
        public float CritPerLevel { get; set; }

        [JsonPropertyName("attackdamage")]
        public float AttackDamage { get; set; }

        [JsonPropertyName("attackdamageperlevel")]
        public float AttackDamagePerLevel { get; set; }

        [JsonPropertyName("attackspeed")]
        public float AttackSpeed { get; set; }

        [JsonPropertyName("attackspeedperlevel")]
        public float AttackSpeedPerLevel { get; set; }

        public float SpellDamage { get; set; }  
    }
}
