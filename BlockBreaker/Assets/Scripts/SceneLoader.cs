using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    
    public void LoadNextScene() {
        int currSceneIdx = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currSceneIdx + 1);
    }

    public void LoadStartScene() {
        SceneManager.LoadScene(0);
    }

    public void QuitGame() {
        Application.Quit();
    }

}
