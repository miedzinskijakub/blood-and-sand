using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    private int damage = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth health = collision.gameObject.GetComponent<EnemyHealth>();
        Debug.Log("dupa");
        if(collision.gameObject.tag == "Enemy")
		{
            Destroy(gameObject);

            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
		else
		{
            Destroy(gameObject);

        }

    }
}
