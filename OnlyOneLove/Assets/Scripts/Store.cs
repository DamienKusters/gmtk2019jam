using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public PlayerInventoryManager Inventory;
    public bool CanBeClicked = true;
    public int ProductId;

    public AudioSource hoverSoundPlayer;
    public AudioSource clickoverSoundPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (CanBeClicked)
        {
            clickoverSoundPlayer.Play();
            transform.localScale = new Vector3(2F, 2F, 2F);
            Inventory.ItemId = ProductId;
        }
    }

    void OnMouseEnter()
    {
        if (CanBeClicked)
        {
            hoverSoundPlayer.Play();
            transform.localScale += new Vector3(.1F, .1F, .1F);
        }
    }

    void OnMouseExit()
    {
        if (CanBeClicked)
            transform.localScale = new Vector3(2F, 2F, 2F);
    }
}
