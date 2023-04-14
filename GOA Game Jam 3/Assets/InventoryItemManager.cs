using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItemManager : MonoBehaviour
{
    public int index;
    public bool isSelected = false;
    private RectTransform selector;
    private InventoryManager manager;

    public Image image;
    public TextMeshProUGUI text;
   

    private void Start()
    {
        selector = GameObject.FindWithTag("UISelector").GetComponent<RectTransform>();
        manager = transform.parent.GetComponent<InventoryManager>();
    }

    private void Update()
    {
        
    }
    public void OnClick()
    {
        if (!isSelected)
        {
            Select();
        }
        else
        {
            Deselect();
        }
    }

    public void Select()
    {
        selector.gameObject.GetComponent<Image>().enabled = true;
        selector.position = this.GetComponent<RectTransform>().position;
        manager.SelectItem(index);
        isSelected = true;
    }

    public void Deselect()
    {
        selector.gameObject.GetComponent<Image>().enabled = false;
        manager.SelectItem(-1);
        isSelected = false;
    }

}
