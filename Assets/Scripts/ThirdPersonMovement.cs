using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;
    public Transform camera;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public Vector3 moveDir;
    Vector3 jumpVelocity;

    bool isGrounded;
    public float jumpHeight = 20f;
    public float gravity = 9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(hor, 0f, ver).normalized;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && jumpVelocity.y < 0)
        {
            jumpVelocity.y = -2f;
            animator.SetBool("isAirborn", false);
        }

        jumpVelocity.y -= gravity * Time.deltaTime;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        // Jump function
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            float product = jumpHeight * 2f * gravity;
            jumpVelocity.y = Mathf.Sqrt(product);
            animator.SetBool("isAirborn", true);
        }

        if (hor != 0 || ver != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        controller.Move(jumpVelocity * Time.deltaTime);
    }
}
