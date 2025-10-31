using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    public Transform player;         
    public GameObject enemyPrefab;     

    [Header("Spawn Timing")]
    public float spawnInterval = 2.0f; 
    private float _nextSpawnTime;

    [Header("Spawn Area Around Player")]
    public float minSpawnDistance = 60f;   
    public float maxSpawnDistance = 120f;  
    public Vector2 heightRange = new Vector2(15f, 50f); 

    [Header("Enemy Speed Range")]
    public Vector2 speedRange = new Vector2(10f, 25f);  

    void Update()
    {
        if (!player || !enemyPrefab) return;

        if (Time.time >= _nextSpawnTime)
        {
            SpawnEnemy();
            _nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        
        float dist = Random.Range(minSpawnDistance, maxSpawnDistance);
        float ang = Random.Range(0f, Mathf.PI * 2f);
        Vector3 offset = new Vector3(Mathf.Cos(ang), 0f, Mathf.Sin(ang)) * dist;

 
        float y = Random.Range(heightRange.x, heightRange.y);

        Vector3 spawnPos = new Vector3(player.position.x + offset.x, y, player.position.z + offset.z);

        
        Quaternion rot = Quaternion.LookRotation((player.position - spawnPos).normalized, Vector3.up);

       
        GameObject enemy = Instantiate(enemyPrefab, spawnPos, rot);

       
        float speed = Random.Range(speedRange.x, speedRange.y);
        var mover = enemy.GetComponent<EnemyPlane>();
        if (!mover) mover = enemy.AddComponent<EnemyPlane>();
        mover.moveSpeed = speed;
        mover.target = player; 
    }
}
