using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{

    public float moveSpeed;
    public bool isWalking;
    public float walkTime;
    public float waitTime;
    public Rigidbody2D myRigidbody;
    public Collider2D walkZone;
    public Dialog dLog;
    public Animator animator;

    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;
    private int WalkDirection;
    private float waitCounter;
    private float walkCounter;
    private bool hasWalkZone;

    public bool facingRight;







    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        dLog = GetComponent<Dialog>();
        waitCounter = waitTime;
        walkCounter = waitTime;
       

        ChooseDirection();
        
        if (walkZone != null)
        {
            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
            hasWalkZone = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dLog.playerInDialog == false)
        {

            animator.SetFloat("Horizontal", myRigidbody.velocity.x);
            animator.SetFloat("Vertical", myRigidbody.velocity.y);
            animator.SetFloat("Speed", myRigidbody.velocity.magnitude);


             if (myRigidbody.velocity.x >= 0.01f)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
                facingRight = false;
                
            }
            if (myRigidbody.velocity.x <= -0.01f)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
           

                if (isWalking)
            {
                walkCounter -= Time.deltaTime;
                


                switch (WalkDirection)
                {
                    case 0:
                        myRigidbody.velocity = new Vector2(0, moveSpeed);

                        if (hasWalkZone && transform.position.y > maxWalkPoint.y)
                        {
                            isWalking = false;
                            waitCounter = waitTime;
                        }
                        break;

                    case 1:
                        myRigidbody.velocity = new Vector2(moveSpeed, 0);

                        if (hasWalkZone && transform.position.x > maxWalkPoint.x)
                        {
                            isWalking = false;
                            waitCounter = waitTime;
                            

                        }

                        break;

                    case 2:
                        myRigidbody.velocity = new Vector2(0, -moveSpeed);

                        if (hasWalkZone && transform.position.y < minWalkPoint.y)
                        {
                            isWalking = false;
                            waitCounter = waitTime;
                        }
                        break;

                    case 3:
                        myRigidbody.velocity = new Vector2(-moveSpeed, 0);

                        if (hasWalkZone && transform.position.x < minWalkPoint.x)
                        {
                            isWalking = false;
                            waitCounter = waitTime;
                        }

                        break;
                }

                if (walkCounter < 0)
                {
                    isWalking = false;
                    waitCounter = waitTime;
                }

            }
            else
            {
                waitCounter -= Time.deltaTime;
                myRigidbody.velocity = Vector2.zero;

                if (waitCounter < 0)
                {
                    ChooseDirection();
                }



            }
        }
        else
        {
            myRigidbody.velocity = Vector2.zero;
        }
    }


    public void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }
}
