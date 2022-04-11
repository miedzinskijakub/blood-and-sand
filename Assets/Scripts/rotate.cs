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
    public Animator animator;
    public GameObject shoot;
    public float reloadTime = 1f;
    private bool isReloading = false;
    public int maxAmmo = 10;
    private int currentAmmo = -1;
    void Start()
    {

        if (currentAmmo == -1)
        {
            currentAmmo = maxAmmo;
        }
    }
   
    void Update()
    {

        if (isReloading)
            return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
            

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
        currentAmmo--;

      GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
      Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
        GameObject d = Instantiate(shoot, firepoint);
        d.transform.parent = null;
        Destroy(d, 2f);
        Destroy(bullet, 3f);
	}

    IEnumerator Reload()
    {
        isReloading = true;
        
        animator.SetBool("Reload", true);
        yield return new WaitForSeconds(reloadTime - .5f);
        animator.SetBool("Reload", false);
        yield return new WaitForSeconds(.5f);

        currentAmmo = maxAmmo;
        isReloading = false;

    }

	 void OnEnable()
	{
        isReloading = false;
        animator.SetBool("Reload", false);
	}

}
