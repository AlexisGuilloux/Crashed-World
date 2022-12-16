using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BootManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadSceneAsync("BackgroundMap", LoadSceneMode.Additive);
    }

    public void OnPlayButtonClicked()
    {
        SceneManager.LoadSceneAsync("MapGenerator", LoadSceneMode.Single);
    }

    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }
}
