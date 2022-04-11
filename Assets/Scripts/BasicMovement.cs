using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    
    public Animator animator;
    public float speed = 5f;
    public bool right;
    public Rigidbody2D rb;
    Vector3 movement;
    bool move;
    public Footprints functions;
	private void Start()
	{
         functions = GetComponent<Footprints>();
        move = false;
	}

	void Update()
    {
      
        ProcessInputs();
        Move();
        Animate();

		if (move)
		{
            functions.Steps();
		}
	
    }

    private void ProcessInputs()
	{
        movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        
        if (movement.magnitude > 1 )
        {
            movement.Normalize();

		}
		
    }

    private void Move()
	{
      
        rb.velocity = new Vector2(movement.x, movement.y);

        if(rb.velocity.magnitude > 0)
		{
            move = true;

		}
		else
		{
            move = false;
		}

    }

    private void Animate()
	{
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);
        if (mousePosition.x < gameObject.transform.position.x)
        {
            animator.SetBool("right", false);
        }
        else if (mousePosition.x > gameObject.transform.position.x)
        {

            animator.SetBool("right", true);
        }
    }


}
