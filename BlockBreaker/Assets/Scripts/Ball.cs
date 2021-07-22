using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;

public class Ball : MonoBehaviour {

    // config
    [SerializeField] Paddle mainPaddle;
    [SerializeField] float velocityX = 2f;
    [SerializeField] float velocityY = 15f;

    // state
    Vector2 paddleToBallVector;
    bool idStarted = false;

    // Start is called before the first frame update
    void Start() {
        paddleToBallVector = transform.position - mainPaddle.transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (!idStarted) {
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
            idStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX, velocityY);
        }
    }
}
