using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public Animator animator;
    public float speed = 5f;
    public bool right;

    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);


       // GameObject.Destroy(footprint, 5);
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);


        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

	

        if (mousePosition.x < 0)
		{

            animator.SetBool("right", false);
        }
        else if(mousePosition.x > 0) { 
		
            animator.SetBool("right", true);
        }
       

        transform.position = transform.position + movement * Time.deltaTime;

      
    }
}
