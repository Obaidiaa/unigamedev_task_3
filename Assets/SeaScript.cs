using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaScript : MonoBehaviour
{
    public float scrollSpeed = 0.5f;  // Adjust the speed of the scrolling sea

    private Renderer seaRenderer;

    void Start()
    {
        seaRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = Time.time * scrollSpeed;
        seaRenderer.material.SetTextureOffset("_MainTex", new Vector2(0, -offset));
    }
}