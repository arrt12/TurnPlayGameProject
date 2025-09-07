using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HomingBullet : MonoBehaviour
{
    public Transform Target;

    [SerializeField] private float speed = 10f;
    [SerializeField] private GameObject hitEffect;
    private Vector3 contactPoint;
    private Quaternion lookAt;
    [SerializeField] private LayerMask monsterLayerMask;
    private Rigidbody rb;


    private void Awake() => rb = GetComponent<Rigidbody>();

    void Start()
    {
        MoveTowardsTarget();
        UpdateLookAtTarget();
    }

    private void OnTriggerEnter(Collider other)
    {
        int otherLayer = other.gameObject.layer;
        if (((1 << otherLayer) & monsterLayerMask.value) != 0)
        {
            LookAtContactPoint(other, out contactPoint, out lookAt);
            Instantiate(hitEffect, contactPoint, lookAt);
            Destroy(gameObject);
        }
    }

    private void MoveTowardsTarget()
    {
        if (Target == null)
            return;

        Vector3 dir = (Target.position - transform.position).normalized;
        rb.velocity = dir * speed;
    }

    private void UpdateLookAtTarget()
    {
        if (rb.velocity == Vector3.zero)
            return;
        transform.rotation = Quaternion.LookRotation(-rb.velocity);
    }

    private void LookAtContactPoint(Collider other, out Vector3 contactPoint, out Quaternion lookAt)
    {
        contactPoint = other.ClosestPoint(transform.position);
        Vector3 lookDirection = (contactPoint - transform.position).normalized;
        lookAt = Quaternion.LookRotation(lookDirection);
    }
}
