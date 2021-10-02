using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD49
{
    public class CamFollowPoint : MonoBehaviour
    {
        private void Update()
        {
            Vector3 playerPosition1 = Game.inst.player1.transform.position;
            Vector3 playerPosition2 = Game.inst.player2.transform.position;

            if (Game.inst.activeP2)
                transform.position = (playerPosition1 + playerPosition2) / 2;
            else
                transform.position = playerPosition1;
        }
    }
}