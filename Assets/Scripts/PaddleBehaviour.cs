using UnityEngine;

public class PaddleBehaviour : MonoBehaviour {
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float screenWidthInUnits = 16f;

    GameStatus gameStatus;
    BallBehavior ballBehavior;

    private void Start() {
        gameStatus = FindObjectOfType<GameStatus>();
        ballBehavior = FindObjectOfType<BallBehavior>();

        if ((gameStatus != null) & (ballBehavior != null) & gameStatus.IsAutoplayEnabled()) {
            ballBehavior.LaunchBall();
        }
    }

    void Update() {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetPosX(), minX, maxX);
        transform.position = paddlePos;
    }

    private float GetPosX() {
        if ((gameStatus != null) & gameStatus.IsAutoplayEnabled()) {
            if (ballBehavior == null) {
                return CalculateMousePosition();
            }

            return ballBehavior.transform.position.x;
        } else {
            return CalculateMousePosition();
        }
    }

    private float CalculateMousePosition() {
        return Input.mousePosition.x / Screen.width * screenWidthInUnits; ;
    }
}
