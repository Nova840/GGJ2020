using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour {

    [SerializeField]
    private Sprite[] sprites = null;

    [SerializeField]
    private bool isBackground = false;

    private SpriteRenderer spriteRenderer;

    public int CurrentSpriteIndex { get; private set; } = 0;

    public static SpriteChanger Background { get; private set; }

    private void Awake() {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (isBackground)
            Background = this;
    }

    public void SetSprite(int index) {
        CurrentSpriteIndex = Mathf.Clamp(index, 0, sprites.Length - 1);
        spriteRenderer.sprite = sprites[CurrentSpriteIndex];
    }

}
