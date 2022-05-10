 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item Database", menuName = "Inventory System/Items/Database")]
public class ItemDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemObject[] item;
    public Dictionary<ItemObject, int> getId = new Dictionary<ItemObject, int>();
    public Dictionary<int, ItemObject> getItem = new Dictionary<int, ItemObject>(); 

    public void OnAfterDeserialize()
    {
        getId = new Dictionary<ItemObject, int>();
        getItem = new Dictionary<int, ItemObject>();
        for (int i = 0; i < item.Length; i++)
        {
            getId.Add(item[i], i);
            getItem.Add(i, item[i]);
        }
    }

    public void OnBeforeSerialize()
    {
        
    }
}
   
