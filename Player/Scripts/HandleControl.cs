using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleControl : MonoBehaviour
{
    [SerializeField] private GameObject cleaningMachine;
    [SerializeField] private GameObject hand;
    private void Update()
    {
        Control();
    }
    private void Control()
    {
        if (cleaningMachine.activeSelf == true)
        {
            hand.SetActive(false);
        }
    }
}
