using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class Block : MonoBehaviour {

    // config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockDestroyVFX;
    [SerializeField] Sprite[] hitSprites;

    // cached refs
    Level level;
    GameStatus gameStatus;

    // state vars
    [SerializeField] int timesHit = 0; // Only for serial for debug (TODO: remove)

    private void Start() {
        gameStatus = FindObjectOfType<GameStatus>();
        if (tag == "Breakable") {
            level = FindObjectOfType<Level>();
            level.AddBreakableBlock();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (tag == "Breakable") {
            HandleHit();
        }
    }

    private void HandleHit() {
        // play on camera
        timesHit++;
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);

        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits) {
            DestroyBlock();
        } else {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite() {
        var spriteIdx = timesHit-1;
        if (hitSprites[spriteIdx] != null) {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIdx];
        } else {
            Debug.LogError("Block sprite is missing from array! Object: " + gameObject.name);
        }
    }

    private void DestroyBlock() {
        level.RemoveBreakableBlock();
        gameStatus.addToScore();
        TriggerDestroyVFX();
        Destroy(gameObject);
    }

    private void TriggerDestroyVFX() {
        GameObject destruction = Instantiate(blockDestroyVFX, transform.position, transform.rotation);
        // a bit hacky way i think
        Destroy(destruction, 2f);
    }
}
