using UnityEngine;
using UnityEngine.SceneManagement;

public class LooseCollider : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) {
        bool ballLaunched = checkIfBallLaunched();
        Debug.Log($"Collision. ballLaunched: {ballLaunched}");

        if (ballLaunched) {
            SceneLoader sceneLoader = FindObjectOfType<SceneLoader>();
            sceneLoader.LoadLooseMenu();
        } else {
            Debug.LogError("Ball was not launched yet");
        }
    }

    private bool checkIfBallLaunched() {
        BallBehavior ball = FindObjectOfType<BallBehavior>();
        return ball != null ? ball.ballLaunched : false;
    }
}
