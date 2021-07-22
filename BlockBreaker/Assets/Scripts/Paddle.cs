using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float screenWidthUnits = 16f;
    [SerializeField] float minPaddleX = 1f;
    [SerializeField] float maxPaddleX = 15f;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        float mousePosXUnit = Input.mousePosition.x / Screen.width * screenWidthUnits;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        // Limit movement
        paddlePos.x = Mathf.Clamp(mousePosXUnit, minPaddleX, maxPaddleX);
        transform.position = paddlePos;
    }
}
