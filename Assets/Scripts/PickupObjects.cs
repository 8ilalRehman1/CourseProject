using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupObjects : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            //destroys the object when the player touches it
            Debug.Log("You Win!"); 
        }
    }
    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        //this rotates the object
    }
}
