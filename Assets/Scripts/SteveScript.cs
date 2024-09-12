using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteveScript : MonoBehaviour
{
    Vector2 input;
    Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] float castLine;
    [SerializeField] bool onGround;
    [SerializeField] Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        onGround = true;
    }

    private void Update()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        onGround = Physics.Raycast(transform.position, Vector3.down, castLine);
        animator.SetFloat("WalkFloat" , input.normalized.magnitude);
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(onGround)
            {
                onGround = false;
                rb.AddForce(Vector3.up * speed, ForceMode.Impulse);
                animator.SetTrigger("Trigger");
            }
        }
    }

    private void FixedUpdate()
    {
        //var newInput = GetCameraBasedInput(input, Camera.main);
        var newVelocity = new Vector3(input.x * speed, rb.velocity.y, input.y * speed);
        rb.velocity = newVelocity;
    }

    /*Vector3 GetCameraBasedInput(Vector2 input, Camera cam)
    {
        Vector3 camRight = cam.transform.right;
        camRight.y = 0;
        camRight.Normalize();
        
        Vector3 camForward = cam.transform.forward;
        camForward.y = 0;
        camForward.Normalize();

        return input.x * camRight + input.y * camForward;
    }*/
}
