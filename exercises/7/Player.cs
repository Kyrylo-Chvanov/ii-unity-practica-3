using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    int score = 0;
    Rigidbody rb;
    Text scoreText;
    Text bonusText;
    const int bonusScoreModifier = 100;
    int nextBonusScore = bonusScoreModifier;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        scoreText = GameObject.FindWithTag("Score").GetComponent<Text>();
        bonusText = GameObject.FindWithTag("Bonus").GetComponent<Text>();
        bonusText.enabled = false;
        Shield.OnCollected += CollectedShield;
        scoreText.text = $"Score: {score}";
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
        scoreText.text = $"Score: {score}";
        if (score >= nextBonusScore)
        {
            nextBonusScore += bonusScoreModifier;
            bonusText.enabled = true;
        }
        else
        {
            bonusText.enabled = false;
        }
    }
}