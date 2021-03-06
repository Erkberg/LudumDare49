using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD49
{
    public class IngameMenu : MonoBehaviour
    {
        public GameObject holder;

        public void Open()
        {
            holder.SetActive(true);
            Game.inst.player1.ShowTutorial();
            if(Game.inst.P2Alive())
                Game.inst.player2.ShowTutorial();
            Time.timeScale = 0f;
        }

        public void Close()
        {
            holder.SetActive(false);
            Game.inst.player1.HideTutorial();
            Game.inst.player2.HideTutorial();
            Time.timeScale = 1f;
        }

        public bool IsOpen()
        {
            return holder.activeSelf;
        }

        public void OnContinueButton()
        {
            Close();
        }

        public void OnRestartFromStartButton()
        {
            Close();
            Game.inst.Reset();
            Game.inst.Restart();
        }

        public void OnRestartFromCheckpointButton()
        {
            Close();
            Game.inst.Restart();
        }

        public void OnQuitButton()
        {
            Application.Quit();
        }
    }
}