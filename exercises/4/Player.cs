using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public Transform referenceObject;
    public float distanceThreshold = 3.0f;
    public delegate void ApproachedObject();
    public static event ApproachedObject OnApproachedReference;

    private bool hasTriggered = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 moveDirection = new(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection.Normalize();
        rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);
        if (!hasTriggered)
        {
            float distance = Vector3.Distance(transform.position, referenceObject.position);
            if (distance <= distanceThreshold)
            {
                hasTriggered = true;
                OnApproachedReference();
            }
        }
    }
}