using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float initialHealth = 10.0f;
    private float currentHealth;
    public GameObject prefab;
    public bool enemyAlive = true;
   
    void Start()
    {
        currentHealth = initialHealth;

    }

    public void TakeDamage(float damage)
	{
        currentHealth -= damage;
       
        var gem = Instantiate(prefab, gameObject.transform.position, Quaternion.identity);
        

        if (currentHealth < 0)
		{

            Destroy(gameObject);
		}
	}
   


}
