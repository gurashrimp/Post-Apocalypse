using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;
    Dictionary<InventorySlot, GameObject> itemDisplayed = new Dictionary<InventorySlot, GameObject>();
    public int X_START;
    public int Y_START;
    public int X_SPACE_BETWEEM_ITEM;
    public int NUMBER_OF_COLUMN;
    public int Y_SPACE_BETWEEM_ITEM;
    // Start is called before the first frame update
    void Start()
    {
        createDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        updateDisplay();
    }
    public void createDisplay()
    {
        for(int i = 0; i< inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = getPosition(i);

        }
    }
    public void updateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemDisplayed.ContainsKey(inventory.Container[i]))
            {

            }
            else {
                var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = getPosition(i);
                itemDisplayed.Add(inventory.Container[i], obj);
            }
            
        }
    }
    public Vector3 getPosition(int i)
    {
        return new Vector3(X_START + (X_SPACE_BETWEEM_ITEM * (i % NUMBER_OF_COLUMN)), Y_START + (Y_SPACE_BETWEEM_ITEM * (i % NUMBER_OF_COLUMN)), 0f);
    }
}
