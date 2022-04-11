using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footprints : MonoBehaviour
{
    public Transform footfalls;
    public Transform footfallsleft;
    public float totaltime = 0;
    [SerializeField] bool left;
    void Start()
    {
        left = true;
    }


    public void Steps()
	{

        totaltime += Time.deltaTime;
        if (totaltime > 1)
        {
            if (!left)
            {
                var foot = Instantiate(footfalls, gameObject.transform.position, footfalls.rotation);
                Destroy(foot.gameObject, 5f);
                totaltime = 0;
                left = true;
            }
            else
            {
                var foot = Instantiate(footfallsleft, gameObject.transform.position, footfallsleft.rotation);
                Destroy(foot.gameObject, 5f);
                totaltime = 0;
                left = false;
            }

        }
    }
}
