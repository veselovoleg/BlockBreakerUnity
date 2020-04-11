using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
    [SerializeField] int breackableBlocksCount = 0;

    // Cached reference
    SceneLoader sceneLoader;

    private void Start() {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBreackableBlocks() {
        breackableBlocksCount++;
    }

    public void BlockDestroyed() {
        breackableBlocksCount--;

        if ((breackableBlocksCount <= 0) & (sceneLoader != null)) {
            sceneLoader.LoadNextScene();
        } else if (sceneLoader == null) {
            Debug.LogError("sceneLoader is null");
        }
    }
}
