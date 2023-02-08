using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)//33.
    {
        Debug.Log(col.relativeVelocity.magnitude);
    }
}
