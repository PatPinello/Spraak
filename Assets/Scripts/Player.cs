using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
   
    public InventoryObject inventory;
    // Start is called before the first frame update
    
    void Start()
    {
        DatabaseControl db = ScriptableObject.CreateInstance<DatabaseControl>(); //Getting DatabaseControl Scriptable object
        Acquistion acq = ScriptableObject.CreateInstance<Acquistion>();

        db.CreateDB("PlayerDictionary", "English","Foreign");
        //db.AddWord("PlayerDictionary", "English","Foreign","weird", "asdawd");
        //db.DisplayDatabase("PlayerDictionary", "English", "Foreign");

        db.CreateInventoryDB("InventoryDB", "ItemID", "Item Name", "Item Amount", "Item Attribute");
        // if(db.RowExists("InventoryDB", "ItemID", 1))
        // {
        //     Debug.Log("OK!");
        // }
        
        acq.AddWordToDictionary(1,"Hello");
       
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        var item = other.GetComponent<GroundItem>();
        if (item)
        {
            Item _item = new Item(item.item);
            inventory.AddItem(_item, 1);
            Destroy(other.gameObject);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inventory.Save();
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            inventory.Load();
        }

        
    }
    private void OnApplicationQuit()
    {
       inventory.Container.Items = new InventorySlot[28];
    }
}