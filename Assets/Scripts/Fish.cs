using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
        public Rigidbody2D rbb;
    public float moveSpeed = 1f;
    private Vector2 moveDirection;

    private float waitTime = 2.0f;
    private float timer = 0.0f;

    void Start()
    {
        lastPosition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(0.0f, (Input.GetAxis("Mouse ScrollWheel")), 0.0f);
        timer += Time.deltaTime;


        if (movement != Vector3.zero)
        {


            //animator.SetFloat("Horizontal", movement.x);
            //animator.SetFloat("Vertical", movement.y);
            //animator.SetFloat("Magnitude", movement.magnitude);



            float moveY = Input.GetAxis("Mouse ScrollWheel");
            moveDirection = new Vector3(0.0f, moveY, 0.0f).normalized;
            Debug.Log(moveDirection.y);



        }

        

        //    if (fishing.isFishing == true)
        //{
        //   mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        //}



    }
    void FixedUpdate()
    {
       
            Move();
        
    }

    Vector3 lastPosition;

    void Move()
    {
        if (moveDirection.y == 1) {
            if (timer > waitTime)
            {
                transform.Translate(0, 1, 0);
                timer = timer - waitTime;
                moveDirection.y = 0;
            }
        }
       else
        {
            rbb.velocity = new Vector2(0.0f, 0.0f);
            
        }
    }
}

