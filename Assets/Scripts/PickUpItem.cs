using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
     public Transform player;
    [SerializeField] float speed = 5f;
    [SerializeField] float pickUpDistance = 1.5f;
    //[SerializeField] float ttl = 10f;

    public void Awake()
    {
        //player = GameManager.instance.player.transform;
    }


    private void Update()
    {
        //ttl -= Time.deltaTime;
        //if (ttl < 0)
        //{
        //    Destroy(gameObject);
        //}
        
        
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > pickUpDistance)
        {
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if(distance < .1f)
        {
            Destroy(gameObject);
        }
    }

}
