using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD49
{
    public class PlayerController : MonoBehaviour
    {
        public bool isActive = true;
        public Player player;
        public PlayerMovement playerMovement;
        public float maxPlayerDistanceX = 14f;
        public GameObject tutorial;

        public enum Player
        {
            P1,
            P2
        }

        public void Die()
        {
            StartCoroutine(DieSequence());            
        }

        private IEnumerator DieSequence()
        {
            Game.inst.audio.PlayBurnSound();
            isActive = false;
            playerMovement.Stop();
            playerMovement.playerAnimation.OnDeath();
            playerMovement.movementEnabled = false;
            yield return new WaitForSeconds(3f);

            if (!Game.inst.activeP2 || Game.inst.BothPlayersDead())
                Game.inst.Restart();
        }

        public void ShowTutorial()
        {
            tutorial.SetActive(true);
        }

        public void HideTutorial()
        {
            tutorial.SetActive(false);
        }
    }
}