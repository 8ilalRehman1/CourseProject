using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform _playerTransform;
    //this tracks the players pos
    public float _speed = 1.0f;
    //speed
    public GameOverManager gameOverManager;
    //references the game manager to end the game

    private Rigidbody _rigidbody;

    private bool touched = false;
    //bool used to end game

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!touched)
        {
            // Calculate the direction to move towards the target
            Vector3 direction = (_playerTransform.position - transform.position).normalized;

            // Move the chaser towards the target
            _rigidbody.MovePosition(transform.position + direction * _speed * Time.deltaTime);

            // Rotate the chaser to face the target
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            _rigidbody.MoveRotation(Quaternion.RotateTowards(transform.rotation, lookRotation, 360f * Time.deltaTime));
        }

        if (touched) { Application.Quit(); } //end the game
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            touched = true;
            Application.Quit();
            //ends the game
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameOverManager.GameOver();
            Debug.Log("Restart Game");
            //ends the game
        }
    }
}
