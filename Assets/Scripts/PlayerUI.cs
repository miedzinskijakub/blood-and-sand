using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Text healthAmount, hungryAmount, food;

    PlayerCharacter playerCharacter;
    // Start is called before the first frame update
    void Start()
    {
        playerCharacter = GetComponent<PlayerCharacter>();
        
    }


}
