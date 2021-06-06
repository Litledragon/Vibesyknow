using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed_horizontal_maxspeed = 1;
    public float Speed_horizontal_acceleration = 1;
    public float Jump_force;
    [Range(0,1)]
    public float Speed_airmultiplier; // todo
    public Vector3 Ground_check_position;
    public Vector3 Ground_check_size;
    private bool jumped;
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

        force.x = Mathf.Clamp(targetVector.x - rb.velocity.x, -Speed_horizontal_acceleration, Speed_horizontal_acceleration);
        if(Input.GetButton("Jump")&& grounded_if&&!jumped)
        {
            jumped = true;
            force.y = Jump_force;
        }
        else
        {
            force.y = 0f;
        }


    }

    private void FixedUpdate()
    {
        bool was_Grounded = grounded_if;
        grounded_if = false;

        Collider[] colliders = Physics.OverlapBox(transform.position+Ground_check_position,Ground_check_size);
        
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                jumped = false;
                grounded_if = true;

                if (!was_Grounded)
                    //first landing
                i = colliders.Length;
            }
        }


        rb.AddForce(force, ForceMode.Impulse);
    }
}
