using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ErksUnityLibrary;

namespace LD49
{
    public class Fire : MonoBehaviour
    {
        public ParticleSystem particles;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            FireStarter fireStarter = collision.GetComponent<FireStarter>();
            if(fireStarter)
            {
                SetEmissionEnabled(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            FireStarter fireStarter = collision.GetComponent<FireStarter>();
            if (fireStarter)
            {
                SetEmissionEnabled(false);
            }
        }

        private void SetEmissionEnabled(bool enabled)
        {
            particles.SetEmissionEnabled(enabled);
        }
    }
}