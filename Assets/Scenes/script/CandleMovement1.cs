using UnityEngine;

public class CandleMovement1 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 100f;

        void Update()
{
    if (Input.touchCount > 0)
    {
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Moved)
        {
            float swipeX = touch.deltaPosition.x;
            float swipeY = touch.deltaPosition.y;

            if (Mathf.Abs(swipeX) > Mathf.Abs(swipeY))
            {
                // Left or Right Turn
                transform.Rotate(Vector3.up, swipeX * turnSpeed * Time.deltaTime);
            }
            else
            {
                // Forward or Backward Movement
                transform.Translate(Vector3.forward * swipeY * moveSpeed * Time.deltaTime);
            }
        }
    }
}

}
