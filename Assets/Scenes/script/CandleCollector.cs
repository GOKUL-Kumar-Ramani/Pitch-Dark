using UnityEngine;
using UnityEngine.SceneManagement;

public class CandleCollector : MonoBehaviour
{
    private int score = 0;
    private CandleLightFlicker candleLightFlicker;

    private void Start()
    {
        candleLightFlicker = FindObjectOfType<CandleLightFlicker>(); // Find the candle light script
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            score++;
            Destroy(other.gameObject);
            Debug.Log("Box Collected! Score: " + score);

            if (candleLightFlicker != null)
            {
                candleLightFlicker.ResetCandle(); // Reset candle intensity & timer
            }
        }
        if (other.CompareTag("finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
