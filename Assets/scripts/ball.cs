using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{

   public Rigidbody2D rb;
   private bool isPressed = false;
   public float releasetime = 0.15f;

   private void Update()
   {
      if (isPressed)
      {
         rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      }
   }

   private void OnMouseDown()
   {
      isPressed = true;
      rb.isKinematic = true;
   }

   private void OnMouseUp()
   {
      isPressed = false;
      rb.isKinematic = false;

      StartCoroutine(release());
   }

   IEnumerator release()
   {
      yield return new WaitForSeconds(releasetime);
      GetComponent<SpringJoint2D>().enabled = false;
   }
   
}
