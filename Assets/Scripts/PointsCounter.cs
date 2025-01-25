using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsCounter : MonoBehaviour
{
    TextMeshProUGUI textContainer;
    int collectiblesCount = 0;

    private void Awake()
    {
        textContainer = GetComponent<TextMeshProUGUI>();
        UpdateCounter();
    }
    private void OnEnable()
    {
        BallMovement.OnCollected += OnCollectedExec;
    }
    private void OnDisable()
    {
        BallMovement.OnCollected -= OnCollectedExec;
    }

    void OnCollectedExec(GameObject go)
    {
        collectiblesCount++;
        UpdateCounter();
    }

    void UpdateCounter()
    {
        textContainer.text = "Points: " + collectiblesCount.ToString();
    }
}
