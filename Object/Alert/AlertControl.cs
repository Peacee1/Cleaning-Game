using UnityEngine;

public class AlertControl : MonoBehaviour
{
    private double Timer;
    private void Start()
    {
        Timer = 0;
        transform.localPosition = new Vector3(0, transform.parent.transform.childCount*50f, 0);
    }
    private void Update()
    {
        Controler();
    }
    private void Controler()
    {
        Timer += Time.deltaTime;
        if (Timer > 1.5f)
        {     
            Destroy(gameObject);
        }
    }

}
