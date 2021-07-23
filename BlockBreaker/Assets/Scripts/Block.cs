using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] AudioClip breakSound;

    // Cached refs
    Level level;
    GameStatus gameStatus;

    private void Start() {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameStatus>();
        level.AddBreakableBlock();
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        // play on camera
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        level.RemoveBreakableBlock();
        gameStatus.addToScore();
        Destroy(gameObject);
    }
}
