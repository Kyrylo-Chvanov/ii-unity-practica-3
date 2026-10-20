using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    int score = 0;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Shield.OnCollected += CollectedShield;
    }

    void OnDestroy()
    {
        Shield.OnCollected -= CollectedShield;
    }

    void FixedUpdate()
    {
        Vector3 moveDirection = new(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection.Normalize();
        rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);
    }

    void CollectedShield(int s)
    {
        score += s;
        Debug.Log($"Current score: {score}");
    }
}