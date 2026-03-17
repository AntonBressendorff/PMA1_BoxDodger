using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{

    protected float gravityScale = 1f;
    Rigidbody2D rb;
    [SerializeField] public EnemyTag.enemyTag enemyTag; //set tag in inspector

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);

        if (viewportPos.y < 0f) // viewportPos.y > 1f
        {
            Destroy(gameObject);
        }
    }
}
