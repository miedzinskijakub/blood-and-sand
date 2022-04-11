using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private int _foodValue = 1;
    private bool collected;

    public GameObject prefab;

    public void SetValue(int value)
	{
        _foodValue = value;
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collected) return;
		if (!collision.CompareTag("Player")) return;
		var player = collision.gameObject.GetComponent<PlayerCharacter>();
		if (player == null) return;
		player.Food(_foodValue);
		collected = true;
		Destroy(gameObject);

	}
}
