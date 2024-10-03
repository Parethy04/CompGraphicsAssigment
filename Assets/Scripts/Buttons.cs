using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] GameObject uitext;
    [SerializeField] GameObject uibuttons;
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        StartCoroutine(LoadScreen());
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    private IEnumerator LoadScreen()
    {
        uitext.SetActive(true);
        uibuttons.SetActive(false);
        yield return new WaitForSeconds(8);
        
        SceneManager.LoadScene("SampleScene");
    }
    
}
