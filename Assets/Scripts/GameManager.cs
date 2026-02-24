using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject brickPref;

    public float spawnRate;

    bool gameStarted = false;


    public GameObject tapText;
    public TextMeshProUGUI scoreText;


    int score = 0;

    Vector2 screenPos;


    // Update is called once per frame
    void Update()
    {
        
        if (transform.GetComponent<InputSys>().IsPressing(out screenPos) && !gameStarted)
        {
            StartSpawning();
            gameStarted = true;
            tapText.SetActive(false);
        }
    }


    void StartSpawning()
    {
        InvokeRepeating("SpawnBrick",0.5f, spawnRate);
    }

    


    void SpawnBrick ()
    {
        Camera cam = Camera.main;

        float randomX = Random.Range(0f, 1f);

        Vector3 viewportPos = new Vector3(randomX, 1f, 0f);

        Vector3 worldPos = cam.ViewportToWorldPoint(viewportPos);

        worldPos.y += 1f;
        worldPos.z = 0f;

        Instantiate(brickPref, worldPos, Quaternion.identity);

        score++;

        UpdateText(score);
    }


    void UpdateText(int score)
    {

        scoreText.text = score.ToString();
    }
}
