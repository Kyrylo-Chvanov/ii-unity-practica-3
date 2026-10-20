using UnityEngine;

public class Green : MonoBehaviour
{
    Cylinder cylinder;
    Rigidbody rb;
    bool goToCylinder = false;
    float speed = 10;
    void Start()
    {
        cylinder = GameObject.FindWithTag("Target").GetComponent<Cylinder>();
        rb = GetComponent<Rigidbody>();
        cylinder.OnPlayerCollided += () => goToCylinder = true;
    }

    void FixedUpdate()
    {
        if (goToCylinder)
        {
            Vector3 moveDirection = cylinder.transform.position - transform.position;
            moveDirection.y = 0;
            moveDirection.Normalize();
            rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);
        }
    }
}
