using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    // config
    [SerializeField] Paddle mainPaddle;
    [SerializeField] float velocityX = 2f;
    [SerializeField] float velocityY = 15f;
    [SerializeField] AudioClip[] ballSounds;

    // state
    Vector2 paddleToBallVector;
    bool isStarted = false;

    // Cached comp refs
    AudioSource myAudoSource;

    // Start is called before the first frame update
    void Start() {
        paddleToBallVector = transform.position - mainPaddle.transform.position;
        myAudoSource = GetComponent<AudioSource>();
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
            GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX, velocityY);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (isStarted) {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudoSource.PlayOneShot(clip);
        }
    }
}
