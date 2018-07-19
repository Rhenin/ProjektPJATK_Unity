using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {


    //zmiana sceny na kolejna
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    //wylaczenie aplikacji
    public void QuitGame()
    {
        Debug.Log("Exit");
        Application.Quit();

    }
}
