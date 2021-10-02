using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD49
{
    public class GameUI : MonoBehaviour
    {
        public IngameMenu ingameMenu;

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