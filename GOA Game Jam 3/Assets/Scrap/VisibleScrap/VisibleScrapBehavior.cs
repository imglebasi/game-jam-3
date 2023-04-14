using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleScrapBehavior : MonoBehaviour
{
    private ScrapData data;
    private SpriteRenderer render;
    private float timer = 1f;
    private InventoryManager manager;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        data = GetComponent<ScrapData>();
        render.sprite = data.sprite;
        manager = GameObject.FindWithTag("InventoryManager").GetComponent<InventoryManager>();
    }
    private void Update()
    {
        if (timer > 0) timer -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && timer < 0f)
        {
            //if(manager.Add(this.gameObject)) Destroy(this.gameObject);
        }
    }
}
