using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed_horizontal_maxspeed = 1;
    public float Speed_horizontal_acceleration = 1;
    [Range(0,1)]
    public float Speed_airmultiplier;
    private Rigidbody rb;
    private bool grounded_if;
    private float input_horizontal;
    private Vector3 targetVector;
    private Vector3 force;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        input_horizontal = Input.GetAxisRaw("Horizontal");
        targetVector = new Vector3(input_horizontal * Speed_horizontal_maxspeed, 0, 0);

        force = Vector3.ClampMagnitude(targetVector-rb.velocity,Speed_horizontal_acceleration);



    }

    private void FixedUpdate()
    {
        rb.AddForce(force, ForceMode.Impulse);
    }
}
