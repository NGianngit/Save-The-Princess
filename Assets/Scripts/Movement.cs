using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector3 direction;
    private Rigidbody rb;
    private Input input;
    public float speed;
    public void Move(Vector3 movement)
    {
        direction = movement;
    }
    // Start is called before the first frame update
    void Start()
    {
        input.Player.Move.performed += ctx => Move(ctx.ReadValue<Vector3>());
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {   //changes the velocity
        rb.velocity = direction * speed;
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
