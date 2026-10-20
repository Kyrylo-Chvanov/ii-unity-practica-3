using UnityEngine;

public class Red : MonoBehaviour
{
    Green green;
    Cylinder cylinder;
    Rigidbody rb;

    bool goToGreen = false;
    float speed = 10;

    void Start()
    {
        green = GameObject.FindWithTag("Tipo 2").GetComponent<Green>();
        cylinder = GameObject.FindWithTag("Target").GetComponent<Cylinder>();
        rb = GetComponent<Rigidbody>();
        cylinder.OnPlayerCollided += () => goToGreen = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (goToGreen)
        {
            Vector3 moveDirection = green.transform.position - transform.position;
            moveDirection.y = 0;
            moveDirection.Normalize();
            rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);
        }
    }
}
