using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //This code was inspired from: https://youtu.be/f473C43s8nE

    [Header("Movement")]
    [SerializeField] float moveSpeed;

    [SerializeField] float groundDrag;

    [Header("Jump")]
    [SerializeField] float jumpPower;
    [SerializeField] float jumpCD;
    [SerializeField] float airMulti;
    bool canJump = true;

    [Header("Ground Check")]
    [SerializeField] float playerHeight;
    [SerializeField] LayerMask whatIsGround;
    bool grounded;

    [Header("keybindings")]
    [SerializeField] KeyCode jumpKey = KeyCode.Space;
/*    [SerializeField] KeyCode switchWeapon1 = KeyCode.Alpha1;
    [SerializeField] KeyCode switchWeapon2 = KeyCode.Alpha2;*/

    [SerializeField] Transform orientation;

    [Header("Weapons")]
    [SerializeField] GameObject sword;
    [SerializeField] GameObject gun;

    float horizInput;
    float vertiInput;

    Vector3 moveDirection;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight /** 0.5f*/ + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();

        //handle drag
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gun.SetActive(true);
            sword.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            sword.SetActive(true);
            gun.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        MovePLayer();
    }

    private void MyInput()
    {
        horizInput = Input.GetAxisRaw("Horizontal");
        vertiInput = Input.GetAxisRaw("Vertical");

        //can you jump?
        if (Input.GetKey(jumpKey) && canJump && grounded)
        {
            canJump = false;
            
            Jump();
            
            Invoke(nameof(ResetJump), jumpCD);
        }
    }

    private void MovePLayer()
    {
        //calculate movement direction
        moveDirection = orientation.forward * vertiInput + orientation.right * horizInput;

        //on ground
        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        //in the air
        else if(!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMulti, ForceMode.Force);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatvel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit vel
        if (flatvel.magnitude > moveSpeed)
        {
            Vector3 limitedvel = flatvel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedvel.x, rb.velocity.y, limitedvel.z);
        }
    }

    private void Jump()
    {
        //resetting y vel
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //FroceMode.Impuse cause it's only applied once
        rb.AddForce(transform.up * jumpPower, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        canJump = true;
    }
}
