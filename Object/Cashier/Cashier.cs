using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cashier : MonoBehaviour
{
    [SerializeField] private GameObject Table;

    private void Start()
    {
        if (Table == null)
        {
            Debug.LogError("Table is not assigned!");
            return;
        }

        for (int i = 0; i < Table.transform.childCount; i++)
        {
            Transform child = Table.transform.GetChild(i);
            child.gameObject.SetActive(true);
        }
    }
}
