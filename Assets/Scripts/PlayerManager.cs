using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text bowlingText;
    [SerializeField] TMP_Text pizzaText;
    [SerializeField] TMP_Text takeoutText;
    float score = 0;
    float available = 0;
    // Start is called before the first frame update
    void Start()
    {
        available = GameObject.FindGameObjectsWithTag("Pickup").Length;
        UpdateScoreUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup")) {
            score++;
            other.gameObject.SetActive(false);
            UpdateScoreUI();
        }

        if (other.CompareTag("Bowling Ball")) {
            other.BroadcastMessage("FixBall");
            UpdateBowlingUI();
        }

        if (other.CompareTag("Pizza")) {
            other.BroadcastMessage("FixPizza");
            UpdatePizzaUI();
        }

        if (other.CompareTag("Takeout")) {
            other.BroadcastMessage("FixTakeout");
            UpdateTakeOutUI();
        }
    }

    private void UpdateScoreUI()
    {
        scoreText.text = $"Donuts Collected: {score}/{available}";
    }

    private void UpdateBowlingUI()
    {
        bowlingText.text = $"Fix Bowling Decor: Done";
    }

    private void UpdatePizzaUI()
    {
        pizzaText.text = $"Fix Pizza Decor: Done";
    }

    private void UpdateTakeOutUI()
    {
        takeoutText.text = $"Fix Takeout Decor: Done";
    }
}
