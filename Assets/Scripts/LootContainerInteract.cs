using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootContainerInteract : Interactable
{
    public GameObject chestInventory;
    [SerializeField] GameObject closedChest;
    [SerializeField] GameObject openedChest;
    [SerializeField] bool opened;

   public override void Interact(Player player)
    {
        if(opened == false)
        {
            opened = true;
            closedChest.SetActive(false);
            openedChest.SetActive(true);

            OpenInventory();
        }
    }

    void OpenInventory()
    {
        if (chestInventory.activeInHierarchy == false)
        {


            Debug.Log("Chest inventory Open");
            chestInventory.SetActive(true);

        }
        else if (chestInventory.activeInHierarchy == true)
        {
            chestInventory.SetActive(false);
        }
    }
}
