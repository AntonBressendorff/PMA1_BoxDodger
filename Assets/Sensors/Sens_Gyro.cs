using UnityEngine;
using UnityEngine.InputSystem;
using gyro = UnityEngine.InputSystem.Gyroscope;

public class Sens_Gyro : MonoBehaviour
{
    public float rotSpeed = 50f;
    public GameObject player;

    void Awake()
    {
        var m_gyro = Input.gyro;
        m_gyro.enabled = true; //attempt to fix issue with unresponsive gyroscope by enabling it in code (used OnePlus 8)

        if (gyro.current != null)
        {
            InputSystem.EnableDevice(gyro.current);
        }
    }

    void Update()
    {
        // if (gyro.current != null)
        // {
        //     // Vector3 rotRate = gyro.current.angularVelocity.ReadValue();

        //     Vector3 rotRate = Input.gyro.rotationRateUnbiased; //attempt to fix issue with unresponsive gyroscope by using unbiased rotation rate (used OnePlus 8) (THIS FIXED IT)

        //     Debug.Log("Gyro Rotation Rate: " + rotRate);


        //     Vector3 rotDegrees = rotRate * Mathf.Rad2Deg;

        //     player.transform.Rotate(0f, 0f, -rotDegrees.z * rotSpeed * Time.deltaTime);

        //     player.transform.Translate(rotDegrees.x, rotDegrees.y, 0f * Time.deltaTime);
        // }
        
            //COMMENT THIS IF USING TOUCH CONTROLS \/

        // Vector3 tilt = Input.gyro.gravity;
        // Debug.Log("Tilt: "+ tilt);

        // float moveX = tilt.x;

        // Vector3 movement = new Vector3(moveX, 0f, 0f);

        // player.transform.Translate(movement * rotSpeed * Time.deltaTime);
        
    }
}
