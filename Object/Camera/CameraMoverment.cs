using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 offset = new Vector3(0,17,-8);
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
