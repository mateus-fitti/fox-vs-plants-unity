using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    public Camera _worldCamera;

    public GameObject leafProjectile;
    public GameObject swordAttack;
    public float projectileSpeed = 5f;
    Animator animator;

    Vector2 lookDirection;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Define a direcao do jogador para o mouse utilizando a diferença do ponto alvo pelo ponto de partida
        lookDirection = _worldCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        // Normaliza o vetor para não influenciar a força
        lookDirection = lookDirection.normalized;

        if(Input.GetButtonDown("Fire1"))
        {
            SwordAttack();
            animator.SetFloat("axis_X", lookDirection.x);
            animator.SetFloat("axis_Y", lookDirection.y);
            animator.SetTrigger("attack");

            SoundManager.instance.Play("Sword");
        }

        if(Input.GetButtonDown("Fire2"))
        {
            CreateProjectile();

            SoundManager.instance.Play("Leaf");
        }
    }

    void SwordAttack()
    {
        Vector3 pos;
        float rot = 0;

        if(Mathf.Abs(lookDirection.x) >= Mathf.Abs(lookDirection.y))
        {
            if(lookDirection.x >= 0)
            {
                pos = Vector2.right;
            }
            else
            {
                pos = Vector2.left;
            }
        }
        else
        {
            rot = 90;
            if (lookDirection.y >= 0)
            {
                pos = Vector2.up;
            }
            else
            {
                pos = Vector2.down;
            }
        }

        GameObject sword = Instantiate(swordAttack, transform.position + pos/2, transform.rotation);
        Rigidbody2D rbSword = sword.GetComponent<Rigidbody2D>();
        rbSword.rotation = rot;
    }

    void CreateProjectile()
    {
        // Cria uma instancia do objeto definido no editor, no caso o Prefab LeafProjectile
        GameObject leaf = Instantiate(leafProjectile, transform.position, transform.rotation);

        // Adiciona uma força ao projetil para a direcao escolhida
        Rigidbody2D rbProj = leaf.GetComponent<Rigidbody2D>();
        rbProj.AddForce(lookDirection * projectileSpeed, ForceMode2D.Impulse);
    }
}
