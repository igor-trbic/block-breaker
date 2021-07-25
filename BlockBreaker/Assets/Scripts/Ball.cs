using UnityEngine;

public class Ball : MonoBehaviour {

    // config
    [SerializeField] Paddle mainPaddle;
    [SerializeField] float velocityX = 2f;
    [SerializeField] float velocityY = 15f;
    [SerializeField] AudioClip[] ballSounds;
    // TODO: just added var not used
    [SerializeField] float randomFactor = 0.2f;

    // state
    Vector2 paddleToBallVector;
    bool isStarted = false;

    // Cached comp refs
    AudioSource myAudoSource;
    Rigidbody2D myRigidBody2D;

    // Start is called before the first frame update
    void Start() {
        paddleToBallVector = transform.position - mainPaddle.transform.position;
        myAudoSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (!isStarted) {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LockBallToPaddle() {
        Vector2 paddlePos = new Vector2(mainPaddle.transform.position.x, mainPaddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void LaunchOnMouseClick() {
        if (Input.GetMouseButtonDown(0)) {
            isStarted = true;
            myRigidBody2D.velocity = new Vector2(velocityX, velocityY);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Vector2 velocityTweak = new Vector2(
            Random.Range(0f, randomFactor),
            Random.Range(0f, randomFactor));
        
        if (isStarted) {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            myAudoSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }
    }
}
