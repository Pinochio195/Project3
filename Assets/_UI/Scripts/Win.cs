using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : UICanvas
{
    public Text score;

    public void MainMenuButton()
    {
        UiManager.Instance.OpenUI<MainMenu>();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Close();
    }
}
