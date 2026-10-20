
using UnityEngine;

public class Human : MonoBehaviour
{
    public Transform lookTarget;
    private Rigidbody rb;
    bool lookAtTarget = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Player.OnApproachedReference += () => lookAtTarget = true;
    }
    void FixedUpdate()
    {
        if (lookAtTarget)
        {
            Vector3 direction = lookTarget.position - transform.position;
            direction.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            rb.MoveRotation(targetRotation);
            lookAtTarget = false;
        }
    }
}