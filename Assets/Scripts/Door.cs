using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        // Show "press `e` to <interact>"
    }

    private void OnTriggerStay(Collider other) {
        if (Input.GetKey(KeyCode.E))
        {
            
        }
    }
}
