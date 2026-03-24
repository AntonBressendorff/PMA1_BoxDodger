using System.Diagnostics;
using System.Collections;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using System.Diagnostics.CodeAnalysis;
using System.Security.AccessControl;



public class Player : MonoBehaviour
{

    public float moveSpeed;
    [SerializeField] private float ShieldDuration = 5f;
    public DodgerAttributes attributes = new DodgerAttributes(3, 3, 0); //initialize attributes: 3 health, 3 max health, 0 score.
    Rigidbody2D rb;

    private bool isShielded = false;

    [SerializeField] InputSys inputSys;
    
    // [SerializeField] public bool TrueForTilt_FalseForTouch = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
            //REMOVE COMMENT AND COMMENT TILT-CODE IN SENS_GYRO.CS TO USE TOUCH CONTROLS
        // float moveDir = 0f;

        // Vector2 screenPos;

        // if (inputSys.IsPressing(out screenPos))
        // {
        //     Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, 0f));


        //     if (touchPos.x < 0)
        //     {
        //         moveDir = -1f;
        //     }
        //     else
        //     {
        //         moveDir = 1f;
        //     }

        // }


        // Vector3 viewportPos = Camera.main.WorldToViewportPoint(rb.position);

        // if ((viewportPos.x <= 0f && moveDir < 0f) || (viewportPos.x >= 1f && moveDir > 0f))
        // {
        //     moveDir = 0f;
        // }


        // rb.linearVelocity = new Vector2(moveDir * moveSpeed, rb.linearVelocity.y);

        
    }

    private IEnumerator EffectTimer(float duration)
    {
        yield return new WaitForSeconds(duration);
        GetComponent<SpriteRenderer>().color = Color.white; // Change color to indicate shield is inactive now
        isShielded = false;
    }

    public void ApplyShield()
    {
        isShielded = true;
        GetComponent<SpriteRenderer>().color = Color.blue; // Change color to indicate shield is active

        // Debug.Log("Shield applied! Player is now invulnerable for " + ShieldDuration + " seconds.");

        StartCoroutine(EffectTimer(ShieldDuration)); // start cooutine with duration of 5 seconds
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick") && isShielded == false)
        {
            attributes.setHealth(attributes.getHealth() - 1); //Loose 1 health

            // Debug.Log("health: " + attributes.getHealth());

            Debug.Log("health: " + attributes.getHealth());
            
            // Debug.Log("score: " + attributes.getCurrentScore());

            if (attributes.getHealth() <= 0) //Game Over if health <= 0
            {
                SceneManager.LoadScene(0);
            }
        }
    }


    


}
