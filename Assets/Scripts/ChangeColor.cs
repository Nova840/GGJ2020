using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {

    [SerializeField]
    private Sprite[] sprites = null;

    private SpriteRenderer spriteRenderer;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameColor.onChangeColor += Change;
    }

    private void OnDestroy() {
        GameColor.onChangeColor -= Change;
    }

    private void Change(int newColorState) {
        spriteRenderer.sprite = sprites[newColorState];
    }

}
