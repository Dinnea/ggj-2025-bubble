using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    [SerializeField] float timer = 180;
    TextMeshProUGUI timerText;
    private void Awake()
    {
        timerText = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        timer -= Time.deltaTime;

        timerText.text = (((Mathf.Floor(timer / 60f)) % 60).ToString("00")) + ":" + (Mathf.Floor(timer % 60f).ToString("00"));
    }
}
