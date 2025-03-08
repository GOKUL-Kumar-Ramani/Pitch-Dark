using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CandleLightFlicker : MonoBehaviour
{
    public Light candleLight;
    public float flickerSpeed = 0.1f;
    public float minIntensity = 1.5f;
    public float maxIntensity = 3.0f;
    public float duration = 30f;  // Max time before the candle goes out
    
    public Light sceneLight;  // Reference to the light
    public Slider timerBar;   // UI Slider reference     

    private float startIntensity;
    private float timer;
    private bool isFlickering = true;

    void Start()
    {
        if (candleLight == null)
            candleLight = GetComponent<Light>();

        startIntensity = candleLight.intensity;
        timer = duration;
        StartCoroutine(FlickerEffect());
        StartCoroutine(ReduceLightOverTime());

        timerBar.maxValue = 100f;
        timerBar.value = duration;
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            timerBar.value = timer; // Update UI
        }
        else
        {
            sceneLight.enabled = false; // Turn off light
        }
    }

    IEnumerator FlickerEffect()
    {
        while (isFlickering)
        {
            candleLight.intensity = Random.Range(minIntensity, maxIntensity);
            yield return new WaitForSeconds(flickerSpeed);
        }
    }

    IEnumerator ReduceLightOverTime()
    {
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            candleLight.intensity = Mathf.Lerp(0, startIntensity, timer / duration);
            yield return null;
        }

        candleLight.enabled = false;  // Turn off light when time reaches 0
        isFlickering = false;  // Stop flickering
        GameOver();  // Call game over function
    }

    public void ResetCandle()  // Reset intensity & timer when box is collected
    {
        timer = timer + duration;  // Reset the timer
        candleLight.intensity = startIntensity;  // Reset intensity
        candleLight.enabled = true;  // Turn the light back on
        isFlickering = true;  // Resume flickering
        Debug.Log("Candle Reset! Time & Intensity Restored.");
    }

    void GameOver()
    {
        Debug.Log("Game Over! The candle has burned out.");
        // Restart scene (optional)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
