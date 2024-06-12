using UnityEngine;

public class CustomerMove : MonoBehaviour
{
    private GameObject doorIn;
    private GameObject doorOut;
    private GameObject cashier;
    private GameObject table;
    private bool doorInFlag = false;
    private bool doorOutFlag = false;
    private bool cashierFlag = false;
    private bool tableFlag = false;
    private bool spawnFlag = true;
    private bool isDone = false;
    private Vector3 direction;
    private Rigidbody rb;
    private float speed = 6f;
    private float timeInCashier = 3f;
    private float timeInTable;
    private double Timer = 0;
    private double Timer1 = 0;
    private Animator anim;
    private GameObject player;
    private bool Paying;
    private bool Paid = false;
    private void Start()
    {
        rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.freezeRotation = true;
        doorIn = GameObject.FindGameObjectWithTag("DoorIn");
        doorOut = GameObject.FindGameObjectWithTag("DoorOut");
        cashier = GameObject.FindGameObjectWithTag("Cashier");
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        Paying = false;
    }
    private void Update()
    {
        anim.SetFloat("run",Mathf.Abs(rb.velocity.x+rb.velocity.z));
        Move();
        rotatePlayer();
        SelectTable();
        if (Paying)
        {
            PlayerStats stats = player.GetComponent<PlayerStats>();
            stats.Money += 10;
            GetAlert(10);
            Paying = false;
            Paid = true;
        }
    }
    private void Move()
    {
        if (spawnFlag)
        {
            direction = doorOut.transform.position - transform.position;
            direction.y = 0;
            rb.velocity = direction.normalized * speed;
        }
        if (doorOutFlag)
        {
            direction = doorIn.transform.position - transform.position;
            direction.y = 0;
            rb.velocity = direction.normalized * speed;
        }
        if (doorInFlag)
        {
            direction = cashier.transform.position - transform.position;
            direction.y = 0;
            rb.velocity = direction.normalized * speed;
        }
        if (cashierFlag)
        {
            rb.velocity = Vector3.zero;
            Timer += Time.deltaTime;
            if (Timer > timeInCashier)
            {
                if (table != null)
                {
                    if (Paid == false)
                    {
                        Paying = true;
                    }
                    direction = table.transform.position - transform.position;
                    direction.y = 0;
                    rb.velocity = direction.normalized * speed;

                }
            }
        }
        if (tableFlag)
        {
            rb.velocity = Vector3.zero;
            Timer1 += Time.deltaTime;
            timeInTable = 15;
            if (Timer1 > timeInTable)
            {
                direction = doorIn.transform.position - transform.position;
                rb.velocity = direction.normalized * speed;
                direction.y = 0;
                isDone = true;
                tableFlag = false;
                GameObject trash = Resources.Load<GameObject>("Trash/Trash");
                GameObject trashCopy = Instantiate(trash, gameObject.transform.position, Quaternion.identity);
                trashCopy.transform.parent = GameObject.FindGameObjectWithTag("Dirt").transform;
                trashCopy.transform.localScale = new Vector3(0.25f, 1, 0.1666667f);
            }
        }
        if (isDone == true)
        {
            Timer1 += Time.deltaTime;
            if (Timer1 > 30)
            {
                Destroy(gameObject);
            }
        }

    
    }
    private void OnTriggerStay(Collider collision)
    {
        if (isDone == false)
        {
            if (collision.tag == "DoorIn")
            {
                doorInFlag = true;
                spawnFlag = false;
                doorOutFlag = false;
                cashierFlag = false;
                tableFlag = false;

            }
            if (collision.tag == "DoorOut")
            {
                doorInFlag = false;
                spawnFlag = false;
                doorOutFlag = true;
                cashierFlag = false;
                tableFlag = false;

            }
            if (collision.tag == "Cashier")
            {
                doorInFlag = false;
                spawnFlag = false;
                doorOutFlag = false;
                cashierFlag = true;
                tableFlag = false;
            }
            if (collision.tag == "Table")
            {
                if (table != null && table == collision.gameObject)
                {
                    doorInFlag = false;
                    spawnFlag = false;
                    doorOutFlag = false;
                    cashierFlag = false;
                    tableFlag = true;
                }  
            }
        }
       
    }
    private void rotatePlayer()
    {
        Vector3 direction = rb.velocity;
        if (direction != Vector3.zero)
        {
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
        }
    }

    private void SelectTable()
    {
        if (table == null)
        {
            GameObject[] Tables = GameObject.FindGameObjectsWithTag("Table");
            foreach (GameObject t in Tables)
            {
                TableStats stats = t.GetComponent<TableStats>();
                if (stats.isTarget == false && stats.inUse == false)
                {
                    stats.isTarget = true;
                    table = t;
                    break;
                }
            }
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
