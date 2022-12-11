using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneToMainMenu : MonoBehaviour
{
    /// <summary>
    /// Loads the Menu screne after end scene is done
    /// </summary>
    public void LoadNewScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
