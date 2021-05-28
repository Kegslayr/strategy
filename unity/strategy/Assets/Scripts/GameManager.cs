﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager: MonoBehaviour
    {
        public static GameManager Instance;
        public Model Current;

        private void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }
}