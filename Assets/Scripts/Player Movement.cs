using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    public float _speed = 5.0f;
    //this is the speed of the player
    public GameOverManager gameOverManager;
    private void FixedUpdate(){
           float horizontalInput = Input.GetAxis("Horizontal");
           //this will be used for left right movements
           float verticalInput = Input.GetAxis("Vertical");
           //this will be used for forward and backword movements
           transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
           //moves the player left right
           transform.Translate(Vector3.forward * verticalInput * _speed * Time.deltaTime);
           //moves the player forward backwards
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            gameOverManager.GameOver();
            //ends the game
        }
    }
}
