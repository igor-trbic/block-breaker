using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks; // serial for debugging

    // Cache refs
    SceneLoader sceneLoader;
    
    private void Start() {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    public void AddBreakableBlock() {
        breakableBlocks++;
    }

    public void RemoveBreakableBlock() {
        breakableBlocks--;
        if (breakableBlocks == 0) {
            sceneLoader.LoadNextScene();
        }
    }
}
