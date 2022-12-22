using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 5f;
    [SerializeField] float jump = 5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    [SerializeField] AudioSource jumpS;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(hor * speed, rb.velocity.y, ver * speed);

        if (Input.GetButtonDown("Jump")&&IsGrounded())
        {
            Jump();
        }

    }
    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
        jumpS.Play();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head")) 
        {
        Destroy (collision.transform.parent.gameObject);
            Jump();
        }
    }
    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);

    }
}