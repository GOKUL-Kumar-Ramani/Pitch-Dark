using UnityEngine;
using UnityEngine.SceneManagement;  // For Game Over

public class EnemyCube : MonoBehaviour
{
    public float timeToGameOver = 3f; // Time in seconds before game over
    private float timer = 0f;
    private bool isPlayerInZone = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Assuming the Candle has "Player" tag
        {
            isPlayerInZone = true;
            Debug.Log("Candle entered the enemy zone!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = false;
            timer = 0f;  // Reset timer if the candle escapes
            Debug.Log("Candle escaped the enemy zone!");
        }
    }

    private void Update()
    {
        if (isPlayerInZone)
        {
            timer += Time.deltaTime;  // Increase time inside zone

            if (timer >= timeToGameOver)
            {
                GameOver();  // Trigger game over if time exceeds limit
            }
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over! The enemy got you.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart game
    }
}
