using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{

	public float speed;
	public float stoppingDistance;

	private Transform target;
	bool attack, attacking, canAttack = true;
	bool playerInRange = false;
	 void Start()
	{
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		
	}

	 void Update()
	{
		if(Vector2.Distance(transform.position, target.position) >= stoppingDistance) { 
		transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
		}



		if(playerInRange && canAttack)
		{
			target.GetComponent<PlayerCharacter>().Hurt(1);
			StartCoroutine(AttackCooldown());
		}
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			playerInRange = true;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			playerInRange = false;
		}
	}

	IEnumerator AttackCooldown()
	{
		canAttack = false;
		yield return new WaitForSeconds(1);
		canAttack = true;
	}
}
