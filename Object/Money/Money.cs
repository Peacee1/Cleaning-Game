using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        UpdateText();
    }
    private void UpdateText()
    {
        TextMeshProUGUI text = gameObject.GetComponent<TextMeshProUGUI>();
        PlayerStats stats = player.GetComponent<PlayerStats>();
        text.text = stats.Money.ToString();
    }
}
