using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject inventory;
    public float moveSpeed = 5f;
    public Rigidbody2D rbb;
    public Animator animator;
    public GameObject NPC;
    public bool moving;
    
    private Vector2 moveDirection;
    private Dialog dLog;
    private Fishing fishing;
    public Vector2 movement;
    public Vector2 lastMotionVector;

    [SerializeField]
    private float rotationSpeed;

    void Start()
    {
        dLog = NPC.GetComponent<Dialog>();
        moving = false;
    }

    void Update()
    {     
            ProcessInputs();


            OpenInventory();
    }


    void FixedUpdate()
    {

        if (dLog.playerInDialog == false)
        {
            Move();
        }
        if (moving = true && dLog.playerInDialog == true)
        {
            rbb.velocity = Vector2.zero;
            gameObject.GetComponent<Animator>().Rebind();
        }


        //Vector2 lookDir = mousePos - rbb.position;
        //float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        //rbb.rotation = angle;
        
       
    }

    //public Camera cam;
    //Vector2 mousePos;

    void ProcessInputs()
    {
        //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
        //Debug.Log(mousePos);

        movement = new Vector2((Input.GetAxis("Horizontal")), (Input.GetAxis("Vertical")));

       

            if (movement != Vector2.zero)
            {
                moving = true;

                animator.SetFloat("Horizontal", movement.x);
                animator.SetFloat("Vertical", movement.y);
                animator.SetFloat("Magnitude", movement.magnitude);

                float moveX = Input.GetAxisRaw("Horizontal");
                float moveY = Input.GetAxisRaw("Vertical");

                moveDirection = new Vector2(moveX, moveY);
            animator.SetBool("moving", moving);

            moving = moveX != 0 || moveY != 0;

            if (moveX != 0 || moveY != 0)
            {
                lastMotionVector = new Vector2(moveX, moveY).normalized;
                animator.SetFloat("lastHorizontal", moveX);
                animator.SetFloat("lastVertical", moveY);
            }


        }

            else
               {
                moving = false;
               }

        //    if (fishing.isFishing == true)
        //{
        //   mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        //}



    }



    void OpenInventory()
    {
        if (inventory.activeInHierarchy == false && Input.GetKeyDown("e"))
        {


            Debug.Log("Pressed E");
            inventory.SetActive(true);

        }
        else if (inventory.activeInHierarchy == true && Input.GetKeyDown("e"))
        {
            inventory.SetActive(false);
        }
    }

    void Move()
        {
            rbb.velocity = movement * moveSpeed;
        }



    }
