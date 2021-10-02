using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD49
{
    public class GameCutscenes : MonoBehaviour
    {
        public IEnumerator StartCutscene()
        {
            Game.inst.player1.playerMovement.movementEnabled = false;
            Game.inst.player2.playerMovement.movementEnabled = false;
            Game.inst.camFollowPoint.state = CamFollowPoint.State.StandStill;
            yield return new WaitForSeconds(3f);
            Game.inst.camFollowPoint.state = CamFollowPoint.State.MoveLeft;
            yield return new WaitForSeconds(4f);
            Game.inst.camFollowPoint.state = CamFollowPoint.State.MoveRight;
            yield return new WaitForSeconds(12f);
            Game.inst.camFollowPoint.state = CamFollowPoint.State.FollowPlayers;
            Game.inst.player1.ShowTutorial();
            Game.inst.player1.playerMovement.movementEnabled = true;
            Game.inst.state = Game.State.Gameplay;
            yield return new WaitForSeconds(6f);
            Game.inst.player1.HideTutorial();
        }

        public IEnumerator FreeP2Cutscene()
        {
            Game.inst.player2.ShowTutorial();
            Game.inst.player2.playerMovement.movementEnabled = true;
            yield return new WaitForSeconds(6f);
            Game.inst.player2.HideTutorial();
        }

        public IEnumerator EndCutscene()
        {
            yield return null;
        }
    }
}