using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lol_Aplication.Models
{
    public class ComputedStats
    {
        public float Hp { get; }
        public float Mp { get; }
        public float AttackDamage { get; }
        public float Armor { get; }
        public float SpellBlock { get; }
        public float MoveSpeed { get; }
        public float AttackRange { get; }
        public float SpellDamage { get; }


        public ComputedStats(Stats baseStats, int level)
        {
            int l = level - 1;

            Hp = baseStats.Hp + baseStats.HpPerLevel * l;
            Mp = baseStats.Mp + baseStats.MpPerLevel * l;
            AttackDamage = baseStats.AttackDamage + baseStats.AttackDamagePerLevel * l;
            Armor = baseStats.Armor + baseStats.ArmorPerLevel * l;
            SpellBlock = baseStats.SpellBlock + baseStats.SpellBlockPerLevel * l;
            MoveSpeed = baseStats.MoveSpeed;
            AttackRange = baseStats.AttackRange;
            SpellDamage = baseStats.SpellDamage;
        }
    }
}
