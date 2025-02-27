using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishManager : MonoBehaviour
{
    int fruitCount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fish")) 
        { 
            Destroy(collision.gameObject);
            fruitCount ++;
        }
    }

    private void OnGUI()
    {
        GUI.contentColor = Color.red;
        GUI.skin.label.fontSize = 30;
        GUI.Label(new Rect(20, 20, 500, 500), "Fish Num: " + fruitCount);
    }
}
