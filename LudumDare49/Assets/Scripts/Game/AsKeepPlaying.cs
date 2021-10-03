using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD49
{
    public class AsKeepPlaying : MonoBehaviour
    {
        public static AsKeepPlaying inst;

        private void Awake()
        {
            if (inst)
                Destroy(gameObject);
            else
            {
                inst = this;
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}

