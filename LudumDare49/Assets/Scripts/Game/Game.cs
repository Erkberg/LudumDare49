using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LD49
{
    public class Game : MonoBehaviour
    {
        public static Game inst;
        public static int levelReached = 0;

        public GameInput input;
        public GameUI ui;
        public PlayerController player1;
        public PlayerController player2;
        public Firewall firewall;
        public Levels levels;
        [Space]
        public bool activeP2 = true;
        public int startLevel = 0;

        private void Awake()
        {
            inst = this;

            if (!activeP2)
                player2.gameObject.SetActive(false);

            if (startLevel != 0 && levelReached == 0)
                levelReached = startLevel;
        }

        private void Start()
        {
            Vector3 startPosi = GetStartingPosition();
            player1.transform.position = startPosi;
            player2.transform.position = startPosi;
        }

        private Vector3 GetStartingPosition()
        {
            Vector3 posi = new Vector3(0f, -1.5f, 0f);

            if(levelReached > 0)
            {
                Level currentLevel = levels.GetLevel(levelReached);
                posi = currentLevel.levelEnd.transform.position;
            }

            return posi;
        }

        public void OnPlayerDeath(PlayerController player)
        {
            if (!activeP2)
                Restart();

            player.Die();

            if (BothPlayersDead())
                Restart();
        }

        public bool BothPlayersAlive()
        {
            return P1Alive() && P2Alive();
        }

        public bool BothPlayersDead()
        {
            return !P1Alive() && !P2Alive();
        }

        public bool P1Alive()
        {
            return player1.gameObject.activeSelf;
        }

        public bool P2Alive()
        {
            return activeP2 && player2.gameObject.activeSelf;
        }

        public void OnLevelEnd(int id)
        {
            Debug.Log("reached end of level " + id);
            levelReached = id;
            firewall.OnLevelEndReached();
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Reset()
        {
            // reset static variables
            levelReached = 0;
        }
    }
}