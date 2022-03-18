using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool playerInRange;
    public bool playerInDialog = false;

    void Update()
    {
        Acquistion acq = ScriptableObject.CreateInstance<Acquistion>();
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            //thePlayer.canMove = false;
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
                playerInDialog = false;
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
                playerInDialog = true;

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            //Debug.Log("Player in Range");
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player left Range");
            //dialogBox.SetActive(false);
        }
    }

}
