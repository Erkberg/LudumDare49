using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD49
{
    public class CamFollowPoint : MonoBehaviour
    {
        public State state;
        public float moveSpeed = 1f;

        public enum State
        {
            FollowPlayers,
            StandStill,
            MoveLeft,
            MoveRight
        }

        private void Update()
        {
            switch(state)
            {
                case State.FollowPlayers:
                    FollowPlayers();
                    break;

                case State.MoveLeft:
                    MoveLeft();
                    break;

                case State.MoveRight:
                    MoveRight();
                    break;
            }
        }

        private void FollowPlayers()
        {
            Vector3 playerPosition1 = Game.inst.player1.transform.position;
            Vector3 playerPosition2 = Game.inst.player2.transform.position;

            if (Game.inst.BothPlayersAlive())
                transform.position = (playerPosition1 + playerPosition2) / 2;
            else if (Game.inst.P1Alive())
                transform.position = playerPosition1;
            else if (Game.inst.P2Alive())
                transform.position = playerPosition2;
        }

        private void MoveLeft()
        {
            transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
        }

        private void MoveRight()
        {
            transform.position += new Vector3(moveSpeed * 2f * Time.deltaTime, 0f, 0f);
        }
    }
}