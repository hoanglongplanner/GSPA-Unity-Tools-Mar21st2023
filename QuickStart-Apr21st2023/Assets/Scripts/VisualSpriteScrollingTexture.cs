using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class VisualSpriteScrollingTexture : MonoBehaviour {
    public Vector2 vec2_scrollSpeed;
    private void OnEnable() => GetComponent<SpriteRenderer>().material.SetVector("_ScrollSpeed", vec2_scrollSpeed);
}
