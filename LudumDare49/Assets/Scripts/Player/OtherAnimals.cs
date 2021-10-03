using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD49
{
    public class OtherAnimals : MonoBehaviour
    {
        public Animator animator;

        public void Die()
        {
            animator.SetTrigger("die");
        }
    }
}

