using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SwordAttackScript : MonoBehaviour
{
    public float timer = 1.0f;
    float currentTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > timer)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
