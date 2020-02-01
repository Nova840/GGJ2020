using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

    [SerializeField]
    private float fadeSpeed = 1;

    [SerializeField]
    private bool disableCollider = true;

    private float fadeTargetValue = 1;

    private SpriteRenderer spriteRenderer;
    private Collider2D collider2d;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2d = GetComponent<Collider2D>();
    }

    private void Update() {
        Color c = spriteRenderer.color;
        c.a = Mathf.MoveTowards(c.a, fadeTargetValue, fadeSpeed * Time.deltaTime);
        spriteRenderer.color = c;
        if (disableCollider) {
            if (c.a <= 0 && collider2d.enabled)
                collider2d.enabled = false;
            else if (c.a >= 1 && !collider2d.enabled)
                collider2d.enabled = true;
        }
    }

    public void FadeOut() {
        fadeTargetValue = 0;
    }

    public void FadeIn() {
        fadeTargetValue = 1;
    }

}