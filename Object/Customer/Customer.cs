using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    private double Timer;
    private float timeToSpawn;
    private GameObject customer;
    public RuntimeAnimatorController anim;
    public GameObject table;
    private void Start()
    {
        Timer = 0;
        timeToSpawn = 10f;
        customer = Resources.Load<GameObject>("Internship_BT4_MoveStopMove/3D/Character/Character_Optimieze2");
        
    }
    private void Update()
    {
        Spawn();
    }
    private void Spawn()
    {
        Timer += Time.deltaTime;
        timeToSpawn = 10f - table.transform.childCount;
        if (Timer > timeToSpawn)
        {
            Timer = 0;
            if (customer != null)
            {
                GameObject ct = Instantiate(customer, transform.position, Quaternion.identity);
                ct.AddComponent<CustomerMove>();
                ct.tag = "Customer";
                ct.AddComponent<CapsuleCollider>();
                ct.GetComponent<CapsuleCollider>().isTrigger = true;
                Animator a = ct.GetComponent<Animator>();
                if (anim != null)
                {
                    a.runtimeAnimatorController = anim;
                }
            }
            else
            {
                Debug.Log(1);
            }
        }
    }

}
