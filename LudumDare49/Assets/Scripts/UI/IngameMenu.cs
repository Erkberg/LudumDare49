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
            Time.timeScale = 0f;
        }

        public void Close()
        {
            holder.SetActive(false);
            Time.timeScale = 1f;
        }

        public bool IsOpen()
        {
            return holder.activeSelf;
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
    }
}