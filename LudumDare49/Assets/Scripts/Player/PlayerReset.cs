using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD49
{
    public class PlayerReset : MonoBehaviour
    {
        private void Update()
        {
            if(transform.position.y < -10f)
            {
                transform.position = Vector3.zero;
            }
        }
    }
}