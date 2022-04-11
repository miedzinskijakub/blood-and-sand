using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public int _health;
    private int _hunger;
    private int _food;
    PlayerUI playerui;

    void Start()
    {
        _health = 10;
        _hunger = 10;
        _food = 5;
        playerui = GetComponent<PlayerUI>();
    }
    
    
    // Update is called once per frame
    void Update()
    {
        SetStats();
    }

    public void Hurt(int damage)
	{
        _health -= damage;
	}

    public void Food(int value) 
    {
        _food += value;
    }
    void SetStats()
    {
        playerui.healthAmount.text = $"Health: {_health}".ToString();
        playerui.hungryAmount.text = $"Hunger: {_hunger}".ToString();
        playerui.food.text = $"Food: {_food}".ToString();


    }

}
