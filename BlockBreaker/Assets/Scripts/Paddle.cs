using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float screenWidthUnits = 16f;
    [SerializeField] float minPaddleX = 1f;
    [SerializeField] float maxPaddleX = 15f;

    // Cached comp refs
    GameStatus gameStatus;
    Ball ball;
    // Start is called before the first frame update
    void Start() {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update() {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        // Limit movement
        paddlePos.x = Mathf.Clamp(GetXPos(), minPaddleX, maxPaddleX);
        transform.position = paddlePos;
    }

    private float GetXPos() {
        if (gameStatus.IsAutoPlayEnabled()) {
            return ball.transform.position.x;
        } else {
            return Input.mousePosition.x / Screen.width * screenWidthUnits;
        }
    }
}
