using Unity.VisualScripting;
using UnityEngine;

public class Cylinder : MonoBehaviour
{
    public delegate void PlayerCollided();
    public event PlayerCollided OnPlayerCollided;
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            OnPlayerCollided();
        }
    }
}
