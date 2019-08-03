using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsDisplay : MonoBehaviour
{
    public GameObject StatsPanel;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleStats()
    {
        if(StatsPanel.active)
        {
            StatsPanel.SetActive(false);
            text.text = "Information";
        }
        else
        {
            StatsPanel.SetActive(true);
            text.text = "Close";
        }
    }
}
