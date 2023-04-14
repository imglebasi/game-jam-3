using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public GameObject[] inventoryItems = new GameObject[6];
    public GameObject itemPrefab;
    public GameObject selector;
    public TextMeshProUGUI description;
    public int selected = -1;

    void Start()
    {
        InitializeInventory();
    }
    
    void Update()
    {

    }

    void InitializeInventory()
    {
        ClearInventory();
        for(int i = 0; i < 6; i++)
        {
            GameObject obj = Instantiate(itemPrefab);
            obj.transform.SetParent(transform);
            inventoryItems[i] = obj;
            obj.GetComponent<InventoryItemManager>().index = i;            
        }
    }

    public void SelectItem(int index)
    {
        if(selected!=-1) inventoryItems[selected].GetComponent<InventoryItemManager>().isSelected = false;
        selected = index;
        if (index != -1)
        {
            description.text = inventoryItems[index].GetComponent<ScrapData>().Description();
        }
        else
        {
            description.text = "";
        }
    }

    void ClearInventory()
    {
        for (int i = 0; i < 6; i++)
        {
            if(inventoryItems[i] != null) Destroy(inventoryItems[i]);
        }
    }

}
