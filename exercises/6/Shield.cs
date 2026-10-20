using Unity.Mathematics;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public int score;
    public delegate void Collected(int score);
    public static event Collected OnCollected;
    bool stopDetection = false;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Player") && !stopDetection)
        {
            stopDetection = true;
            OnCollected?.Invoke(score);
            Destroy(gameObject);
        }
    }
}
