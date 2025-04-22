using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LeafProjectileScript : MonoBehaviour
{

    SpriteRenderer sprite;
    Color nColor;
    Color[] colors;
    int colorCount;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        colorCount = 0;

        nColor = new Color(0.75f,0.75f,0.75f);
        colors = new Color[] {Color.white, Color.green * nColor, Color.magenta * nColor, Color.red * nColor, Color.yellow};
    }

    void Update()
    {
        colorCount++;

        if (colorCount >= colors.Length)
        {
            colorCount = 0;
        }

        sprite.color = colors[colorCount];
    }
    
    // Detecta quando inicia colisão e recebe o objeto colidido como parametro
    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject.Destroy(gameObject);
    }

}
