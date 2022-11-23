using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneToMainMenu : MonoBehaviour
{
    public void LoadNewScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
