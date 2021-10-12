using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public float speed = 5f;
    public float bulletForce = 20f;
    public Transform firepoint;
    public GameObject bulletPrefab;
    private float fireRate = 1f;
    private float nextFire = 0f; 
    // Update is called once per frame
    void Update()
    {

		if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
		{
            nextFire = Time.time + fireRate;
            Shoot();
		}

        faceMouse();
    }

    void faceMouse()
	{
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
            );
        transform.up = direction;
	}

    void Shoot()
	{


      GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
      Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
	}

}
