using ErksUnityLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD49
{
    public class LevelEnd : MonoBehaviour
    {
        public int id;

        public void SetPositionX(float x)
        {
            transform.SetLocalPositionX(x);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerMovement playerMovement = collision.GetComponent<PlayerMovement>();
            if (playerMovement)
            {
                Game.inst.OnLevelEnd(id);
                Destroy(gameObject);
            }
        }
    }
}