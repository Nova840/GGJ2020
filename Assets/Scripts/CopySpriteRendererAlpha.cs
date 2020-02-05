using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class CopySpriteRendererAlpha : MonoBehaviour {

    [SerializeField]
    private SpriteRenderer spriteRendererToCopy = null;

    [SerializeField]
    private bool reverseAlpha = false;

    private SpriteRenderer thisSpriteRenderer;

    private void Awake() {
        thisSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        Color c = thisSpriteRenderer.color;
        c.a = spriteRendererToCopy.color.a;
        if (reverseAlpha)
            c.a = 1 - c.a;
        thisSpriteRenderer.color = c;
    }

}