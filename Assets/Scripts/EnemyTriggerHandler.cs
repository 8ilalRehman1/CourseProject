using UnityEngine;

public class EnemyTriggerHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("You lose");
            // Player touched an enemy trigger, so quit the application
            Application.Quit();
        }
    }
}
