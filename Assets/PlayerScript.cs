using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int money;
    public bool touchingDoor;
    public int doorCost;
    public GameObject door;
    public GameObject unlockText;

    void Start()
    {
        money = 0;
        touchingDoor = false;
        doorCost = 0;
        door = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (touchingDoor)
            {
                BuyDoor();
            }
        }

    }

    float curI;
    public void BuyDoor()
    {
        
        if(money >= doorCost)
        {
            money -= doorCost;
            //door.gameObject.SetActive(false);
            unlockText.SetActive(false);
            touchingDoor = false;
            doorCost = 0;
            door.GetComponent<Animator>().Play(door.name);
            
        }
    }

}
