using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]private string GameScene;
    

    
    public void PlayGame()
    {
        SceneManager.LoadScene(GameScene);
    }

    public void QuitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
        //Debug.Log("It's Work");
    }


  
}
