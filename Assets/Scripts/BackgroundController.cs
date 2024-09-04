using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private Renderer meuBrackground;
    private float posX = 0f;
    void Start()
    {
        meuBrackground = GetComponent<Renderer>();
    }

    void Update()
    {
        posX += 0.001f;
        meuBrackground.material.mainTextureOffset = new Vector2(posX, 0);
    }
}
