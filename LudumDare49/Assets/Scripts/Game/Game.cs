using Cinemachine;
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

        public State state = State.Cutscene;

        public new GameAudio audio;
        public GameInput input;
        public GameUI ui;
        public GameCutscenes cutscenes;
        public PlayerController player1;
        public PlayerController player2;
        public Firewall firewall;
        public Levels levels;
        public CamFollowPoint camFollowPoint;

        public CinemachineVirtualCamera endCam;
        public GameObject endP1;
        public GameObject endP2;
        [Space]
        public static bool activeP2 = false;
        public int startLevel = 0;

        public enum State
        {
            Cutscene,
            Gameplay
        }

        [ContextMenu("GameEnd")]
        public void TriggerGameEnd()
        {
            StopAllCoroutines();
            inst.OnGameEnd(null);
        }

        private void Awake()
        {
            inst = this;

            if (startLevel != 0 && levelReached == 0)
                levelReached = startLevel;
        }

        private void Start()
        {
            if(StartFromBeginning())
            {
                state = State.Cutscene;
                StartCoroutine(cutscenes.StartCutscene());
            }
            else
            {
                state = State.Gameplay;
                Vector3 startPosi = GetStartingPosition();
                player1.transform.position = startPosi;
                if(activeP2)
                    player2.transform.position = startPosi;

                firewall.transform.position = startPosi + Vector3.left * 20f;
            }            
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

        private bool StartFromBeginning()
        {
            return levelReached == 0;
        }

        public void OnPlayerDeath(PlayerController player)
        {
            player.Die();
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
            return player1.isActive;
        }

        public bool P2Alive()
        {
            return activeP2 && player2.playerMovement.movementEnabled && player2.isActive;
        }

        public bool P2EndAlive()
        {
            return activeP2 && player2.isActive;
        }

        public void OnLevelEnd(int id)
        {
            Debug.Log("reached end of level " + id);
            firewall.maxDistanceToPlayer = 16f;
            levelReached = id;
            firewall.OnLevelEndReached();
            levels.AdjustFiresToLevel();
        }

        public void OnP2Freed()
        {
            activeP2 = true;
            StartCoroutine(cutscenes.FreeP2Cutscene());
        }

        public void OnGameEnd(PlayerController playerController)
        {
            if(state == State.Gameplay)
            {
                state = State.Cutscene;
                Debug.Log("game end!");
                StartCoroutine(cutscenes.EndCutscene());
            }            
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Reset()
        {
            // reset static variables
            levelReached = 0;
            activeP2 = false;
        }
    }
}