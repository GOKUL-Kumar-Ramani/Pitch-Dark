using UnityEngine;

public class CandleMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 100f;

    void Update()
    {
        float move = 0f;
        float turn = 0f;

        // Keyboard Controls (For Testing)
        if (Input.GetKey(KeyCode.UpArrow)) move = 1f;    // Move Forward
        if (Input.GetKey(KeyCode.DownArrow)) move = -1f; // Move Backward
        if (Input.GetKey(KeyCode.LeftArrow)) turn = -1f; // Turn Left
        if (Input.GetKey(KeyCode.RightArrow)) turn = 1f; // Turn Right

        // Apply movement
        transform.Translate(Vector3.forward * move * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, turn * turnSpeed * Time.deltaTime);
    }
}
