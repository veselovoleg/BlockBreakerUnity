using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : MonoBehaviour {
    // Config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject breakBlockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;
    [SerializeField] int maxHits;

    // Cached reference
    Level level;
    GameStatus gameStatus;

    // State
    [SerializeField] int timesHit;

    private void Start() {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameStatus>();

        if (level != null & tag == "BreakableBlock") {
            level.CountBreackableBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (tag == "BreakableBlock") {
            HandleHit();
        } else if (tag == "UnbreakableBlock") {
            PlayBreakSound();
        }
    }

    private void DestroyBlock() {
        PlayBreakSound();
        level.BlockDestroyed();
        gameStatus.AddScore();
        Destroy(gameObject);
        triggerSparklesVFX();
        Debug.Log("Block Destroyed");
    }

    private void PlayBreakSound() {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void triggerSparklesVFX() {
        GameObject sparkles = Instantiate<GameObject>(breakBlockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }

    private void HandleHit() {
        timesHit++;

        if (timesHit >= maxHits) {
            DestroyBlock();
        } else {
            ShowNextBlockHitSprite();
        }
    }

    private void ShowNextBlockHitSprite() {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        int spriteIndex = timesHit - 1;

        if (hitSprites[spriteIndex] != null) {
            spriteRenderer.sprite = hitSprites[spriteIndex];
        } else {
            spriteRenderer.sprite = hitSprites[hitSprites.Length - 1];
        }
    }
}
