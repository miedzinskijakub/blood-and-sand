using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class DayNightCycle : MonoBehaviour
{
    public float dayLength = 10.0f;
    public float nightLength = 10.0f;

    public Color dayColor = new Color(1.0f, 1.0f, 1.0f);
    public Color nightColor = new Color(0.25f, 0.25f, 0.25f);

    private Light2D light2D;
    private Camera cam;

    public bool daytime { get; private set; }
    private float timeRemaining;
    // Start is called before the first frame update
    void Start()
    {
        light2D = GetComponent<Light2D>();
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
       // timeRemaining -= Time.deltaTime;
        
        if (timeRemaining <= Time.deltaTime)
		{
            daytime = !daytime;
            timeRemaining = 1.0f;
			if (daytime)
			{
                light2D.color = Color.Lerp(dayColor, nightColor, Time.deltaTime / timeRemaining);
                timeRemaining -= Time.deltaTime;
                
			}
			else
			{
                light2D.color = Color.Lerp(nightColor, dayColor, timeRemaining);
                timeRemaining = nightLength;
			}
		}
    }
}
