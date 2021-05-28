using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Model: MonoBehaviour
    {
        public Inventory Inventory;

        private void Start()
        {
            Inventory = GetComponent<Inventory>();
        }
    }
}
