using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnRatePerMinute = 30;
    public float spawnRateIncrement = 1f;
    public float Xlimit;
    public float maxlife = 2f;

    private float spawnNext = 0;
    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnNext)
        {
            spawnNext = Time.time + 60 / spawnRatePerMinute;
            spawnRatePerMinute += spawnRateIncrement;

            float rand = Random.Range(-Xlimit, Xlimit);
            Vector3 spawnPosition = new Vector3(rand, 10f, -3.63f);
            GameObject meteror = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
            Destroy(meteror, maxlife);
        }
        


    }
}
