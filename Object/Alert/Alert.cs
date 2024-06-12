using TMPro;
using UnityEngine;

public class Alert : MonoBehaviour
{
    private GameObject alert1;
    private GameObject alert;
    private int money = 0;
    public bool isAlert;

    public void MoneyCheck(int money)
    {
        this.money = money;
    }
    public void Update()
    {
        if (money !=  0 && isAlert == false)
        {
            GameObject alert2 = Instantiate(alert1, alert.transform);
            TextMeshProUGUI text = alert2.GetComponent<TextMeshProUGUI>();
            text.text = "+" + money;
            isAlert = true;
            alert2.AddComponent<AlertControl>();
        }
    }
    private void Start()
    {
        alert = GameObject.FindGameObjectWithTag("Alert");
        alert1 = GameObject.FindGameObjectWithTag("Alert1");
        isAlert = false;
    }
}
