using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rbb;
    public Animator animator;
    public GameObject NPC;
    public bool isMoving;
    
    private Vector2 moveDirection;
    private Dialog dLog;

    [SerializeField]
    private float rotationSpeed;

    void Start()
    {
        dLog = NPC.GetComponent<Dialog>();
        isMoving = false;
    }

    void Update()
    {     
            ProcessInputs();

        

    }


    void FixedUpdate()
    {

        if (dLog.playerInDialog == false)
        {
            Move();
        }
        if (isMoving = true && dLog.playerInDialog == true)
        {
            rbb.velocity = Vector2.zero;
            gameObject.GetComponent<Animator>().Rebind();
        }

    }


    void ProcessInputs()
    {
        Vector3 movement = new Vector3((Input.GetAxis("Horizontal")), (Input.GetAxis("Vertical")), 0.0f);

       

            if (movement != Vector3.zero)
            {
                isMoving = true;

                animator.SetFloat("Horizontal", movement.x);
                animator.SetFloat("Vertical", movement.y);
                animator.SetFloat("Magnitude", movement.magnitude);

                float moveX = Input.GetAxisRaw("Horizontal");
                float moveY = Input.GetAxisRaw("Vertical");

                moveDirection = new Vector3(moveX, moveY, 0.0f).normalized;
                



        }

            else
               {
                isMoving = false;
               }





    }

        void Move()
        {
            rbb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        }



    }
