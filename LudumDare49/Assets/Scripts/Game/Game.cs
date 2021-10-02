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
        public PlayerController player;
        public Firewall firewall;

        private void Awake()
        {
            inst = this;
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