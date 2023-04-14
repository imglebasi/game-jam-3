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
            obj.GetComponent<ScrapData>().Randomize();
            obj.GetComponent<InventoryItemManager>().index = i;
            obj.GetComponent<InventoryItemManager>().Setup();
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

    public void Drop()
    {
        if (selected != -1) inventoryItems[selected].GetComponent<InventoryItemManager>().Drop();
        MoveDown();
    }

    public void MoveDown()
    {
        bool loop = true;
        int loops = 0;
        while (loop && loops < 20)
        {
            loop = false;
            loops++;
            Debug.Log("Looping");
            for (int i = 0; i < inventoryItems.Length - 1; i++)
            {
                
                if (inventoryItems[i].GetComponent<InventoryItemManager>().selectable == false && inventoryItems[i+1].GetComponent<InventoryItemManager>().selectable == true)
                {
                    Debug.Log(i);
                    ScrapData data = inventoryItems[i].AddComponent<ScrapData>();
                    data.Copy(inventoryItems[i + 1].GetComponent<ScrapData>());
                    Destroy(inventoryItems[i + 1].GetComponent<ScrapData>());
                    inventoryItems[i].AddComponent<InventoryItemManager>().Setup();
                   // inventoryItems[i+1].AddComponent<InventoryItemManager>().Setup();
                    loop = true;
                    break;
                }
            }

        }

    }
    public bool Add(GameObject go)
    {
        //FINISH
        ScrapData data;
        if ((data = go.GetComponent<ScrapData>()) == null) return false;
        return true;
    }

}
