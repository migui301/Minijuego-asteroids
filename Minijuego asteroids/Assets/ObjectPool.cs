using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    public int poolSize = 10;
    private List<GameObject> pool = new List<GameObject>();
    private static ObjectPool instance;
    public static ObjectPool Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(prefab);
            bullet.SetActive(false);
            pool.Add(bullet);
        }
    }
    public GameObject RequestBullet(Vector3 pos, Vector3 dir)
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeSelf)
            {
                pool[i].transform.position = pos;
                pool[i].transform.rotation = Quaternion.identity;
                pool[i].SetActive(true);
                Bullet balaScript = pool[i].GetComponent<Bullet>();
                balaScript.targetVector = dir;
                balaScript.Reset();
                return pool[i];
            }
        }

        return null;    
    }
    
    
}
