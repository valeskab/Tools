using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public int sceneToLoad;

    public void StartGame()
    {
        SceneManager.LoadScene(sceneToLoad); // Scene to load
    }

    public void QuitGame()
    {
        Application.Quit(); // Quit Game
        Debug.Log("Quit Game"); // Print to Console
    }
}
