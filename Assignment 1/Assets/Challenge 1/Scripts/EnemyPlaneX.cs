using UnityEngine;

public class EnemyPlaneX : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 15f;
    public Transform target;         // optional; if assigned, enemy will yaw toward target a bit

    [Header("Lifetime")]
    public float maxLifetime = 30f;  // auto-cleanup

    void Start()
    {
        Destroy(gameObject, maxLifetime);
    }

    void Update()
    {
        if (target)
        {
            Vector3 toTarget = (target.position - transform.position).normalized;
            Quaternion targetRot = Quaternion.LookRotation(toTarget, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, 0.5f * Time.deltaTime);
        }

        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);
    }

  
    
}
