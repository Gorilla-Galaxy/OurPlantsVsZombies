using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateSpriteRenderer : MonoBehaviour
{
    [SerializeField] private float animationTime = 0.25f;
    [SerializeField] private int animationFrame;
    [SerializeField] private Sprite[] animationSprites;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private bool loop;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        InvokeRepeating(nameof(NextFrame), animationTime, animationTime);
    }

    private void NextFrame() {
        animationFrame++;
        if (animationFrame >= animationSprites.Length) {
            animationFrame = 0;
        }
        if (animationFrame >= 0 && animationFrame < animationSprites.Length) {
            spriteRenderer.sprite = animationSprites[animationFrame];
        }
    }
}
