using UnityEngine;
using UnityEngine.Networking;

public class SpawnManager : MonoBehaviour
{
    public bool enableSpawn = false;
    public GameObject Enemy; 
    float randomT;
    void SpawnEnemy()
    {
        float randomX = Random.Range(-8.5f, 8.5f); 
        if (enableSpawn)
        {
           Instantiate(Enemy, new Vector3(randomX, 1.33f, 0f), Quaternion.identity); 
        }
    }
    void Start()
    {
        randomT = Random.Range(1f, 5f);
        InvokeRepeating("SpawnEnemy", 1, randomT); 
    }
    void Update()
    {

    }
}