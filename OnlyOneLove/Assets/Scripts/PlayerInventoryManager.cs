using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryManager : MonoBehaviour
{
    public int ItemId = 0;
    public Image GiftImage;
    public Sprite[] GiftSprites;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GiftImage.sprite = GiftSprites[ItemId];
    }
}
