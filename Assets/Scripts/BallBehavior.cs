using UnityEngine;

public class BallBehavior : MonoBehaviour {
    // Config
    [SerializeField] PaddleBehaviour paddle;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float launchBallX = 2f;
    [SerializeField] float launchBallY = 15f;
    [SerializeField] float randomFactor = 0.5f;


    Vector2 paddleToBallVector;
    AudioSource myAudioSource;
    public bool ballLaunched = false;
    private Rigidbody2D ballRigidbody2D;

    void Start() {
        paddleToBallVector = transform.position - paddle.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        ballRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (!ballLaunched) {
            LockBallToPaddle();
            LaunchBallOnClick();
        }
    }

    private void LaunchBallOnClick() {
        if (Input.GetMouseButtonDown(0)) {
            ballLaunched = true;
            ballRigidbody2D.velocity = new Vector2(launchBallX, launchBallY);
        }
    }

    private void LockBallToPaddle() {
        Vector2 paddlePosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
        AudioClip clip = ballSounds.Length > 0 ? ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)] : null; 

        if (clip != null & ballLaunched) {
            myAudioSource.PlayOneShot(clip);
            ballRigidbody2D.velocity += velocityTweak;
        }
        /**
        AudioSource audio = GetComponent<AudioSource>();

        if (audio != null & ballLaunched) {
            audio.Play();
        }
        **/
    }
}
