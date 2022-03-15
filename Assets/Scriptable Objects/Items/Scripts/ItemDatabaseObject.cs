using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Database", menuName = "Inventory System/Items/Database")]
public class ItemDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemObject[] Items;
    public Dictionary<int, ItemObject> GetItem = new Dictionary<int, ItemObject>();

    void OnEnable ()
    {
        for (int i = 0; i < Items.Length; i++)
        {
            Debug.Log(Items[i]);
        }
    }
    public void OnAfterDeserialize()
    {
        for (int i = 0; i < Items.Length; i++)
        {
            
            Items[i].Id = i;
            GetItem.Add(i, Items[i]);
        }
    }

    public void OnBeforeSerialize()
    {
        GetItem = new Dictionary<int, ItemObject>();
    }
}