using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{

    public float speed = 10f;
    public float maxLifeTime = 3f;
    private float lifeTimer;

    public Vector3 targetVector;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        lifeTimer = 0f;
    }

    public void Reset()
    {
        lifeTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * targetVector * Time.deltaTime);
        lifeTimer += Time.deltaTime;
        if (lifeTimer >= maxLifeTime)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            IncreaseScore();
            Asteroid asteroid = collision.gameObject.GetComponent<Asteroid>();
            if (asteroid != null)
            {
                asteroid.Split(targetVector);
            }
            gameObject.SetActive(false);

        }
    }

    private void IncreaseScore()
    {
        Player.SCORE++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<Text>().text = "Score: " + Player.SCORE;
    }
}
