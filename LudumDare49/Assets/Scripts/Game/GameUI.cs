using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD49
{
    public class GameUI : MonoBehaviour
    {
        public IngameMenu ingameMenu;
        public GameObject blackOverlay;
        public GameObject gameEndText;
        public GameObject creditsText;

        public void OnMenuButton()
        {
            if(ingameMenu.IsOpen())
            {
                ingameMenu.Close();
            }
            else
            {
                ingameMenu.Open();
            }
        }
    }
}