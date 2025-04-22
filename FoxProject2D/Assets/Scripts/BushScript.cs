using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushScript : MonoBehaviour
{
    SpriteRenderer bSprite;
    Color[] bColors;
    int colorCount = 0;
    public Color target = Color.white;

    Animator animator;

    // Start é chamado antes da primeira atualização de frame
    void Start()
    {
        bSprite = gameObject.GetComponent<SpriteRenderer>();

        Color nColor = new Color(0.75f,0.75f,0.75f);
        bColors = new Color[] {Color.white, Color.green * nColor, Color.magenta * nColor, Color.red * nColor, Color.yellow};

        colorCount = Random.Range(0, bColors.Length - 1);
        bSprite.color = bColors[colorCount];

        animator = GetComponent<Animator>();
    }

    // Update é chamado uma vez por frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("destroy") &&
        animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            GameObject.Destroy(gameObject);
        }
    }

    // Detecta quando inicia colisão e recebe o objeto colidido como parametro
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "PlayerProjectile")
        {
            colorCount++;
            if (colorCount >= bColors.Length)
            {
                colorCount = 0;
            }

            bSprite.color = bColors[colorCount];

            SoundManager.instance.Play("Hit");
        }

        if (col.gameObject.tag == "PlayerAttack")
        {
            if (target == bColors[colorCount])
            {
                SoundManager.instance.Play("Destroy");
                animator.SetTrigger("destroy");
                GetComponent<Collider2D>().enabled = false;
            }
        }
    }

}
