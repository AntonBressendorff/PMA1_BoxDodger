using UnityEngine;
using UnityEngine.InputSystem;

public class Actuator_Vibrate : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            Debug.Log("Vibrate!");
            Handheld.Vibrate();
        }
    }
}
