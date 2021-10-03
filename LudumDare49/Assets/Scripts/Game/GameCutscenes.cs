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
            yield return new WaitForSeconds(12.1f);
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
            Game.inst.ui.blackOverlay.SetActive(true);
            Destroy(Game.inst.firewall.gameObject);
            Game.inst.player1.playerMovement.movementEnabled = false;
            Game.inst.player2.playerMovement.movementEnabled = false;
            yield return new WaitForSeconds(3f);
            Game.inst.ui.gameEndText.SetActive(true);
            Game.inst.endCam.enabled = true;
            yield return new WaitForSeconds(10f);
            // scene
            Game.inst.ui.blackOverlay.SetActive(false);
            Game.inst.ui.gameEndText.SetActive(false);
            if (!Game.inst.P1Alive())
                Game.inst.endP1.SetActive(false);
            if (!Game.inst.P2EndAlive())
                Game.inst.endP2.SetActive(false);
            yield return new WaitForSeconds(8f);          
            Game.inst.ui.creditsText.SetActive(true);
        }
    }
}