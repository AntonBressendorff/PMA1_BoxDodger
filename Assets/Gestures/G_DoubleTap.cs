using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class G_DoubleTap : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float maxDelayTime = 0.3f;

    float lastTapTime = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        EnhancedTouchSupport.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (touch.activeTouches.Count < 1) return;

        var touch1 = touch.activeTouches[0];

        if (touch1.phase == UnityEngine.InputSystem.TouchPhase.Began)
        {
            float timeSinceLastTap = Time.time - lastTapTime;

            if (timeSinceLastTap <= maxDelayTime)
            {
                // player.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
                player.GetComponent<Player>().ApplyShield();
            }
            else
            {
                lastTapTime = Time.time;
            }
        }
    }
}
