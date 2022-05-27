using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject menuOptions;
     public void PlayStart()
    {
        SceneManager.LoadScene("Scene1");
    }
    public void Options()
    {
        menuOptions.SetActive(true); 


    }
    public void CloseOptions()
    {
        menuOptions.SetActive(false);
    }

    public void GoToLevelOne()
    {
        SceneManager.LoadScene("Scene1");
    }
    public void GoToLevelTwo()
    {
        SceneManager.LoadScene("Scene2");
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
