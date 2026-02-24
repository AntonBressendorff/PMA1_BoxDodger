using System.Diagnostics;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;



public class Player : MonoBehaviour
{

    public float moveSpeed;
    public DodgerAttributes attributes = new DodgerAttributes(3, 3, 0); //initialize attributes: 3 health, 3 max health, 0 score.
    Rigidbody2D rb;

    [SerializeField] InputSys inputSys;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        float moveDir = 0f;

        Vector2 screenPos;

        if (inputSys.IsPressing(out screenPos))
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, 0f));


            if (touchPos.x < 0)
            {
                moveDir = -1f;
            }
            else
            {
                moveDir = 1f;
            }

        }


        Vector3 viewportPos = Camera.main.WorldToViewportPoint(rb.position);

        if ((viewportPos.x <= 0f && moveDir < 0f) || (viewportPos.x >= 1f && moveDir > 0f))
        {
            moveDir = 0f;
        }


        rb.linearVelocity = new Vector2(moveDir * moveSpeed, rb.linearVelocity.y);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            attributes.setHealth(attributes.getHealth() - 1); //Loose 1 health
            // Debug.Log("health: " + attributes.getHealth());
            Debug.Log("score: " + attributes.getCurrentScore());

            if (attributes.getHealth() <= 0) //Game Over if health <= 0
            {
                SceneManager.LoadScene(0);
            }
        }
    }


    


}
