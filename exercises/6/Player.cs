using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    int score = 0;
    Rigidbody rb;
    Text text;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        text = GameObject.FindWithTag("Score").GetComponent<Text>();
        Shield.OnCollected += CollectedShield;
        text.text = $"Score: {score}";
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
        text.text = $"Score: {score}";
    }
}