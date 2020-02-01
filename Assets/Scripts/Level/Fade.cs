using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

    [SerializeField]
    private float fadeSpeed = 1;

    [SerializeField]
    private Color fadeInColor = Color.white;

    [SerializeField]
    private Color fadeOutColor = Color.white;

    [SerializeField]
    private bool disableCollider = true;

    private float fadeCurrentValue = 1;
    private float fadeTargetValue = 1;

    private SpriteRenderer spriteRenderer;
    private Collider2D collider2d;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2d = GetComponent<Collider2D>();
    }

    private void Update() {
        fadeCurrentValue = Mathf.MoveTowards(fadeCurrentValue, fadeTargetValue, fadeSpeed * Time.deltaTime);
        Color c = Color.Lerp(fadeOutColor, fadeInColor, fadeCurrentValue);
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