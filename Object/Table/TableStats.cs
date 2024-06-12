using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableStats : MonoBehaviour
{
    public bool inUse;
    public bool isTarget;
    private void Start()
    {
        inUse = false;
        isTarget = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Customer")
        {
            inUse = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Customer")
        {
            inUse = false ;
            isTarget = false ;
        }
    }
}
