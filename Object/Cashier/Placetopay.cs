using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placetopay : MonoBehaviour
{
    private bool isPaying = false;
    private double Timer;
    public GameObject Cashier;
    private GameObject player;
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == player)
        {
            isPaying = true;
        }
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (isPaying)
        {
            Timer += Time.deltaTime;
            if (Timer > 3)
            {
                if (player.GetComponent<PlayerStats>().Money <= 100)
                {
                    Debug.Log("Khong du tien");
                }
                else
                {
                    player.GetComponent<PlayerStats>().Money -= 100;
                    Cashier.SetActive(true);
                    Destroy(gameObject);
                }
            }
        }
    }
}
