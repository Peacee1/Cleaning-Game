using System;
using UnityEngine;

public class Clean : MonoBehaviour
{
    public GameObject cashier;
    private void Update()
    {
        if (gameObject.transform.childCount == 0)
        {
            if (cashier.activeSelf == false) 
            {
                cashier.SetActive(true);
            }
        }
    }
}
