using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public float rotationSpeed = 120;
    public float jumpForce = 5;

    bool canJump = true;
    Vector3 initPos;
    Quaternion initRot;
    Rigidbody rb;

    void Start()
    {
        initPos = transform.position;
        initRot = transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && canJump)
        {
            canJump = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.R))
        {
            transform.SetPositionAndRotation(initPos, initRot);
        }
    }

    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = moveVertical * speed * Time.fixedDeltaTime * transform.forward;
        rb.MovePosition(rb.position + movement);

        float turn = Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("HorizontalSurface"))
        {
            canJump = true;
        }
    }
}

