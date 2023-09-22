using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DoorCollisionScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject unlText;
    public int cost;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.name == "Player")
        {
            unlText.SetActive(true);
            unlText.GetComponent<TextMeshProUGUI>().text = $"Unlock Door [E]\n${cost}";
            hit.GetComponent<PlayerScript>().touchingDoor = true;
            hit.GetComponent<PlayerScript>().door = transform.parent.gameObject;
            hit.GetComponent<PlayerScript>().doorCost = cost;
            
            
        }
    }

    private void OnTriggerExit(Collider hit)
    {
        if (hit.name == "Player")
        {
            unlText.SetActive(false);
            hit.GetComponent<PlayerScript>().touchingDoor = false;
            Debug.Log("Left Collision");
        }
    }
}
