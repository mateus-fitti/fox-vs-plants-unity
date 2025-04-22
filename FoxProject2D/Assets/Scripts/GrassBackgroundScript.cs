using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassBackgroundScript : MonoBehaviour
{
    SpriteRenderer rend;
    Collider2D[] bushes;

    Color nColor;
    Color[] bColors;
    // colorCount <= -1 para escolher uma cor aleatória no começo
    public int colorCount = 0;
    // colorSwitchDelay <= 0.0f para não trocar a cor
    public float colorSwitchDelay = 5.0f;
    float currentTime = 0.0f;

    public LayerMask bushLayer;

    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponent<SpriteRenderer>();
        Vector2 boxSize = rend.bounds.size;

        nColor = new Color(0.75f,0.75f,0.75f);
        bColors = new Color[] {Color.white, Color.green * nColor, Color.magenta * nColor, Color.red * nColor, Color.yellow};

        bushes = Physics2D.OverlapBoxAll(transform.position, boxSize, 0, bushLayer);

        if (colorCount < 0)
            UpdateColor();
        else
        {
            rend.color = bColors[colorCount];
        }
        UpdateBushes();

        if (colorSwitchDelay <= 0.0f)
        {
            enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= colorSwitchDelay)
        {
            currentTime = 0.0f;

            UpdateColor();
            UpdateBushes();
        }
    }

    void UpdateColor()
    {
        int color = Random.Range(0, bColors.Length - 1);

        if(color == colorCount)
        {
            colorCount++;
            if (colorCount >= bColors.Length)
            {
                colorCount = 0;
            }
        }
        else
        {
            colorCount = color;
        }

        rend.color = bColors[colorCount];
    }

    void UpdateBushes()
    {
        foreach (Collider2D bush in bushes)
        {
            if (bush != null)
            {
                BushScript bushScript = bush.gameObject.GetComponent<BushScript>();
                bushScript.target = bColors[colorCount];
            }
        }
    }
}
