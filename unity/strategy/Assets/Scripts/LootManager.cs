using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public enum PersonalLootType { 
        SemiIntA,
        SemiIntB,
        SemiIntC,
        SemiIntD,
        SemiIntE,
        LowIntA,
        LowIntB,
        LowIntC,
        LowIntD,
        LowIntE,
        AvgIntA,
        AvgIntB,
        AvgIntC,
        AvgIntD,
        AvgIntE,
        HighIntA,
        HighIntB,
        HighIntC,
        HighIntD,
        HighIntE,
        GeniusA,
        GeniusB,
        GeniusC,
        GeniusD,
        GeniusE
    };

    public class Loot
    {
        public int CP;
        public int SP;
        public int GP;
        public int PP;
        public List<Item> Items = new List<Item>();
    }

    public class LootManager: MonoBehaviour
    {
        public static LootManager Instance;

        private void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public Loot GenPersonalLoot(PersonalLootType lt)
        {
            var loot = new Loot();

            switch (lt) {
                // Furbearer Light
                case PersonalLootType.LowIntA:
                    break;
            }
          
            return loot;
        }
    }
}
