using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableClicksOnChildren(bool enabled)
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            var Go = this.gameObject.transform.GetChild(i).GetComponent<Store>().CanBeClicked = enabled;
        }
    }
}
