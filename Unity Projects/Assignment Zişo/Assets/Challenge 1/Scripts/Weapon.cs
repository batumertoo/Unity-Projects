using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Bomb Setup")]
    public GameObject bombPrefab;     
    public Transform bombSpawn;       

    [Header("Fire")]
    public float fireCooldown = 0.25f;
    public float launchSpeed = 30f;   

    private float _nextFireTime;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= _nextFireTime)
        {
            FireBomb();
            _nextFireTime = Time.time + fireCooldown;
        }
    }

    void FireBomb()
    {
        if (!bombPrefab || !bombSpawn) return;

        GameObject bomb = Instantiate(bombPrefab, bombSpawn.position, bombSpawn.rotation);

        Rigidbody planeRb = GetComponent<Rigidbody>();
        Rigidbody bombRb = bomb.GetComponent<Rigidbody>();
        if (bombRb != null)
        {
            Vector3 inherited = planeRb ? planeRb.velocity : Vector3.zero;
            bombRb.velocity = inherited + transform.forward * launchSpeed;
        }
    }
}
