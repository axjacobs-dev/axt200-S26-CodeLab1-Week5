using UnityEngine;

public class WASDController : MonoBehaviour
{
    public KeyCode keyUp;
    public KeyCode keyDown;
    public KeyCode keyLeft;
    public KeyCode keyRight;
    public int forceAmount;

    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyUp))
        {
            rb.AddForce(Vector3.up * forceAmount);
        }

        if (Input.GetKeyDown(keyDown))
        {
            rb.AddForce(Vector3.down * forceAmount);
        }

        if (Input.GetKeyDown(keyLeft))
        {
            rb.AddForce(Vector3.left * forceAmount);
        }

        if (Input.GetKeyDown(keyRight))
        {
            rb.AddForce(Vector3.right * forceAmount);
        }

    }
}