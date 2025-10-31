using UnityEngine;

public class EnemyPlane : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 15f;
    public Transform target;         

    [Header("Lifetime")]
    public float maxLifetime = 30f; 

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

    
    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.CompareTag("Bombe"))
        {
            
            Destroy(gameObject);
        }
    }
}
