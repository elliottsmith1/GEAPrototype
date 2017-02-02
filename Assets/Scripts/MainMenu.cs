using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public void loadGame()
    {
        Application.LoadLevel("Main");
    }

    public void loadMenu()
    {
        Application.LoadLevel("MainMenu");
    }
}
