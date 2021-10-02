using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ErksUnityLibrary;

namespace LD49
{
    public class Firewall : MonoBehaviour
    {
        public float moveSpeed = 1f;

        private void Update()
        {
            transform.SetLocalPositionX(transform.position.x + moveSpeed * Time.deltaTime);
        }
    }
}