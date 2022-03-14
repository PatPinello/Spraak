using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public string dataBaseName = "PlayerDictionary";
    public string column1 = "English";
    public string column2 = "Foreign";
    public InventoryObject inventory;
    // Start is called before the first frame update
    
    void Start()
    {
        DatabaseControl db = ScriptableObject.CreateInstance<DatabaseControl>(); //Getting Databasecontrol Scriptable object
        db.CreateDB(dataBaseName, column1,column2);
        db.AddWord(dataBaseName, column1,column2,"weird", "asdawd");
        db.DisplayDatabase(dataBaseName, column1, column2);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        var item = other.GetComponent<GroundItem>();
        if (item)
        {
            Item _item = new Item(item.item);
            Debug.Log(_item.Id);
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
    //private void OnApplicationQuit()
    //{
    //    inventory.Container.Items = new InventorySlot[28];
    //}

}