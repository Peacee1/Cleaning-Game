using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    public float leftRight;
    public float upDown;
    public float verticalSpeed;
    public float horizontalSpeed;
    private Animator anim;
    public FloatingJoystick joystick;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>(); 
        verticalSpeed = 10f;
        horizontalSpeed = 10f;
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
        rotatePlayer();
    }
    private void Move()
    {
        if (rb != null)
        {
            leftRight = joystick.Horizontal;
            upDown = joystick.Vertical;
            rb.velocity = new Vector3(leftRight * horizontalSpeed,rb.velocity.y, upDown*verticalSpeed);
        }
        anim.SetFloat("run", Mathf.Abs(leftRight+upDown));
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


}
