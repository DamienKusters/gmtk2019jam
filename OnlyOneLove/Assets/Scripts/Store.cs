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
            transform.localScale = new Vector3(.6F, .6F, .6F);
            Inventory.ItemId = ProductId;
        }
    }

    void OnMouseEnter()
    {
        if (CanBeClicked)
        {
            hoverSoundPlayer.Play();
            transform.localScale += new Vector3(.05F, .05F, .05F);
        }
    }

    void OnMouseExit()
    {
        if (CanBeClicked)
            transform.localScale = new Vector3(.6F, .6F, .6F);
    }
}
