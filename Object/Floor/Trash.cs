using UnityEngine;

public class Trash : MonoBehaviour
{
    private bool inHand = false;
    private GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cleaner")
        {
            Destroy(gameObject);
            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerStats>().Money += 1;
            GetAlert(1);
        }
        if (other.tag == "Hand")
        {
            GameObject Handle = GameObject.FindGameObjectWithTag("Handle");
            HandleStats stats = Handle.GetComponent<HandleStats>();
            if (stats != null && stats.coutSlot <= stats.maxSlot)
            {
                inHand = true;
                gameObject.transform.parent = Handle.transform;
                transform.localPosition = new Vector3(0, stats.coutSlot*0.15f, 0);
                stats.coutSlot++;
            }
            
        }
        if(other.tag == "TrashCan" && inHand == true)
        {
            Destroy(gameObject);
            GameObject Handle = GameObject.FindGameObjectWithTag("Handle");
            Handle.GetComponent<HandleStats>().coutSlot -= 1;
            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerStats>().Money += 1;
            GetAlert(1);
        }
    }
    private void GetAlert(int money)
    {
        GameObject alert = GameObject.FindGameObjectWithTag("Alert");
        Alert al = alert.GetComponent<Alert>();
        al.MoneyCheck(money);
        al.isAlert = false;
        
    }
}
