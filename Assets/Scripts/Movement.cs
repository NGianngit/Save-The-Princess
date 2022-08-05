using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector3 direction;
    private Rigidbody rb;
    private Input input;
    private float turnSmoothVelocity;
    public float turnTime;
    /// <summary>
    /// Speed of player
    /// </summary>
    public float speed;
    public float spSpeed;
    private float currentSpeed;

    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        //call animator//
        animator = GetComponent<Animator>();
        normalSpeed();
        //read the value of the input the player pressed//
        input.Player.Move.performed += ctx => Move(ctx.ReadValue<Vector3>());
        //input button for sprint//
        input.Player.Sprint.performed += ctx => Sprint();
        input.Player.Sprint.canceled += ctx => normalSpeed();
        //get ridgetbody //
        rb = GetComponent<Rigidbody>();
        

    }

    // Update is called once per frame
    void Update()
    {   //changes the velocity
        rb.velocity = direction * currentSpeed;
        //find the angle the player need to rotate
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        //set the angle of the direction the player will be turning
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnTime);
        //set the transform of the player on the angle that received above
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        //the player is idle and not walking
        if (direction.x == 0 && direction.y == 0 && direction.z == 0)
        {
            animator.SetBool("IsWalking", false);
        }
        else
        {   //player is walking
            animator.SetBool("IsWalking", true);
        }
        
    }
    private void normalSpeed()
    {
        currentSpeed = speed;
        animator.SetBool("IsRunning", false);
    }
    private void Sprint()
    {   
        if (!animator.GetBool("IsWalking"))
        {
            currentSpeed = 0f;
            animator.SetBool("IsRunning", false);
        }
        animator.SetBool("IsRunning", true);
        currentSpeed = spSpeed;

    }
    public void Move(Vector3 movement)
    {
        direction = movement;
        
    }
    private void Awake()
    {
        input = new Input();
    }
    private void OnEnable()
    {
        input.Enable();
       
    }
    private void OnDisable()
    {
        input.Disable();
        
    }
}
