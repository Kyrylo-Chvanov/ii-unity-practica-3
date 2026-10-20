using UnityEngine;

public class Lich : MonoBehaviour
{
    public Transform targetShield;
    Rigidbody rb;
    bool teleport = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Player.OnApproachedReference += () => teleport = true;
    }

    void FixedUpdate()
    {
        if (teleport)
        {
            rb.MovePosition(targetShield.position);
            teleport = false;
        }
    }
}
