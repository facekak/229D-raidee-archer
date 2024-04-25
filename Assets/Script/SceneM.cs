using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneM : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void GameScene()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void EndCredits()
    {
        SceneManager.LoadSceneAsync(3);
    }
}

