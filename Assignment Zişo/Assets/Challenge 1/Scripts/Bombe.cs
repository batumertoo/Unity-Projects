using UnityEngine;

public class Bombe : MonoBehaviour
{
    public float lifetime = 10f;
    public float explosionRadius = 5f;
    public float explosionForce = 500f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Handles non-trigger collisions
    void OnCollisionEnter(Collision col)
    {
        ExplodePhysics();
        TryDestroyEnemy(col.collider);
        Destroy(gameObject);
    }

    // Handles trigger volumes (if any collider is set to IsTrigger)
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
        // Get the top-most object (or the rigidbody host) and check its tag
        Transform root = hitCollider.attachedRigidbody ? hitCollider.attachedRigidbody.transform : hitCollider.transform.root;
        if (root.CompareTag("Enemy"))
        {
            Destroy(root.gameObject);
            // Optional: Debug.Log("Enemy destroyed by bomb.");
        }
    }
}
