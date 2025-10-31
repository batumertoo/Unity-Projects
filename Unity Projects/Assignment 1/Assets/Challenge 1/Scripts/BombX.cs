using UnityEngine;

public class BombX : MonoBehaviour
{
    public float lifetime = 10f;
    public float explosionRadius = 5f;
    public float explosionForce = 500f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter(Collision col)
    {
        ExplodePhysics();
        TryDestroyEnemy(col.collider);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        ExplodePhysics();
        TryDestroyEnemy(other);
        Destroy(gameObject);
    }

    void ExplodePhysics()
    {
        foreach (Collider hit in Physics.OverlapSphere(transform.position, explosionRadius))
        {
            var rb = hit.attachedRigidbody;
            if (rb != null) rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
        }
    }

    void TryDestroyEnemy(Collider hitCollider)
    {
        Transform root = hitCollider.attachedRigidbody ? hitCollider.attachedRigidbody.transform : hitCollider.transform.root;
        if (root.CompareTag("Enemy"))
        {
            Destroy(root.gameObject);
        }
    }
}
