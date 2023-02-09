using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject deatheffect;
    public float health = 4f;
    public static int enemiesalive = 0;

    private void Start()
    {
        enemiesalive++;
    }

    private void OnCollisionEnter2D(Collision2D col) //33
    {
        if (col.relativeVelocity.magnitude > health) //relativevelocity !éé
        {
            Die();

        }
    }

    void Die()
    {
        Instantiate(deatheffect,transform.position,quaternion.identity);
        enemiesalive--;
        if (enemiesalive<=0)
        {
            Debug.Log("geçtin leveli helal olsun be.");

        }
        Destroy(gameObject);
    }
}