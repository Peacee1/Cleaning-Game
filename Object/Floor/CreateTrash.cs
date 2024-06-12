using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTrash : MonoBehaviour
{
    private int cout;
    private GameObject trash;
    private void Start()
    {
        trash = Resources.Load<GameObject>("Trash/Trash");
        TrashCreate();
    }
    private void TrashCreate()
    {
        while (cout < 50)
        {
            cout++;
            GameObject trashCopy = Instantiate(trash,new Vector3(Random.Range(-15,15),0,Random.Range(-25,25)), Quaternion.identity);
            trashCopy.transform.parent = GameObject.FindGameObjectWithTag("Dirt").transform;
            trashCopy.transform.localScale = new Vector3(0.25f, 1, 0.1666667f);
        }
    }

}
