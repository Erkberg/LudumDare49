using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LD49
{
    public class Game : MonoBehaviour
    {
        public static Game inst;

        public GameInput input;
        public PlayerController player1;
        public PlayerController player2;
        public Firewall firewall;
        [Space]
        public bool activeP2 = true;
        public int startLevel = 0;

        private void Awake()
        {
            inst = this;

            if (!activeP2)
                player2.gameObject.SetActive(false);
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void OnLevelEnd(int id)
        {
            Debug.Log("reached end of level " + id);
            firewall.OnLevelEndReached();
        }
    }
}