using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerActive : MonoBehaviour
{
    private GameObject table;
    public GameObject customer;

    // Update is called once per frame
    void Update()
    {
        table = GameObject.FindGameObjectWithTag("Table");
        if (table != null)
        {
            customer.SetActive(true);
        }
    }
}
