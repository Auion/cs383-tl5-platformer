using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishManager : MonoBehaviour
{
    int fruitCount = 0;

    // Player health
    [SerializeField] GameObject player;
    private PlayerScript playerScript;

    void Start()
    {
        playerScript = player.GetComponent<PlayerScript>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fish")) 
        { 
            Destroy(collision.gameObject);
            fruitCount ++;
            playerScript.PickupSound();
            if (playerScript.health < 9)
            {
                playerScript.health += 1;
            }
        }
    }

    private void OnGUI()
    {
        GUI.contentColor = Color.red;
        GUI.skin.label.fontSize = 30;
        GUI.Label(new Rect(20, 20, 500, 500), "Fish Eaten: " + fruitCount);
    }
}
