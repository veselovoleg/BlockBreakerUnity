using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    [SerializeField] bool showMouse = true;

    int sceneCount;
    int currentSceneIndex;
    string currentSceneName;

    public void Start() {
        // Set cursor visibility
        Cursor.visible = showMouse;

        sceneCount = SceneManager.sceneCountInBuildSettings;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        currentSceneName = SceneManager.GetActiveScene().name;
        
        Debug.Log($"Current scene name: {currentSceneName}");
    }


    public void LoadNextScene() {
        if ((currentSceneIndex + 1) == sceneCount) {
            Debug.Log("Last scene");
            LoadStartScene();
        } else {
            Debug.Log("Next Scene");
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        
    }

    public void LoadStartScene() {
        SceneManager.LoadScene(0); // Menu screen
        ClearGameStatus();
    }

    public void QuitApp() {
        Application.Quit();
        Debug.Log("Quitting");
    }

    public void LoadLooseMenu() {
        SceneManager.LoadScene("GameOver");
        ClearGameStatus();
    }

    public void ClearGameStatus() {
        GameStatus gameStatus = FindObjectOfType<GameStatus>();

        if (gameStatus != null) {
            gameStatus.DestroyGameObject();
        }
    }
}
