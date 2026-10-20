using UnityEngine;

public class Lich : MonoBehaviour
{
    public delegate void PlayerCollided();
    public static event PlayerCollided OnPlayerCollided;
    public float speed = 10;
    public GameObject target;
    bool goToTarget = false;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Human.OnPlayerCollided += () => goToTarget = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (goToTarget)
        {
            Vector3 moveDirection = target.transform.position - transform.position;
            moveDirection.y = 0;
            moveDirection.Normalize();
            rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            rb.MoveRotation(targetRotation);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            OnPlayerCollided();
        }
    }
}
