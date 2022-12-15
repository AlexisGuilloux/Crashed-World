using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BootManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadSceneAsync("MapGenerator", LoadSceneMode.Additive);
    }

    public void OnPlayButtonClicked()
    {
        //SceneManager.UnloadSceneAsync("Boot");
        //SceneManager.UnloadSceneAsync("MapGenerator");
        SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
    }

    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }
}
