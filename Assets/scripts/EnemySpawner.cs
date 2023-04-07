using System.Collections;
using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform[] zombieSpawners;
    public float generationTime = 5f;
    void Start()
    {
        zombieSpawners = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            zombieSpawners[i] = transform.GetChild(i);
        
        StartCoroutine(CreateEnemy());
    }

    IEnumerator CreateEnemy()
    {
        while (true)
        {
            for (int i = 0; i < zombieSpawners.Length; i++)
            {
                Transform zombieSpawner = zombieSpawners[i];
                Instantiate(zombiePrefab, zombieSpawner.position, zombieSpawner.rotation);
            }
            yield return new WaitForSeconds(generationTime);
        }
    }
}
