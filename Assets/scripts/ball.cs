using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ball : MonoBehaviour
{

   public Rigidbody2D rb;
   private bool isPressed = false;
   public float releasetime = 0.15f;
   public float maxdragdistance = 2f;
   public Rigidbody2D hook;

   private void Update()
   {
      if (isPressed)
      {
         Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         if (Vector3.Distance(mousepos, hook.position) > maxdragdistance)
         {
            rb.position = hook.position+(mousepos-hook.position).normalized * maxdragdistance;//33
         }
         else
         {
            rb.position = mousepos;

         }
       
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
      this.enabled = false;
      yield return new WaitForSeconds(5f);
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

   }
   
}
