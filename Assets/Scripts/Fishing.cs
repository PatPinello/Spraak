using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    public bool isFishing = false;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            if (isFishing == false)
            {
                isFishing = true;
                Debug.Log("You really do be fishin' ");
            }
            else
            {
                isFishing = false;
                Debug.Log("You must be crazy");
            }
        }
    }
}
