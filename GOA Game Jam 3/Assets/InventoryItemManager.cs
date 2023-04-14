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
    private ScrapData data;

    public GameObject visScrap;

    private Transform player;

    public bool selectable;
   

    private void Awake()
    {
        data = gameObject.GetComponent<ScrapData>();
    }

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        selector = GameObject.FindWithTag("UISelector").GetComponent<RectTransform>();
        manager = transform.parent.GetComponent<InventoryManager>();
    }

    private void Update()
    {
        
    }
    public void OnClick()
    {
        if (selectable)
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
    }

    public void Select()
    {
        Setup();
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

    public void Setup()
    {
        data = GetComponent<ScrapData>();
        
        if (data != null)
        {
            image.enabled = true;
            text.enabled = true;
            selectable = true;
            image.sprite = data.sprite;
            text.text = data.Name();
        }
        else
        {
            image.enabled = false;
            text.enabled = false;
            selectable = false;
        }
    }

    public void Drop()
    {
        GameObject obj = Instantiate(visScrap, player.position, new Quaternion(0f,0f,0f,0f));
        ScrapData odata = obj.GetComponent<ScrapData>();
        odata.Copy(data);
        Deselect();
        Destroy(data);
        Setup();
        image.enabled = false;
        text.enabled = false;
        selectable = false;
    }
}
