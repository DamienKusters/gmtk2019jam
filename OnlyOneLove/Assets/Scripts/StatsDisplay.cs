using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsDisplay : MonoBehaviour
{
    public GameObject StatsPanel;
    public Text text;
    public PeopleSpawner PeopleManager;
    public BuildingsManager BuildingManager;

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

            PeopleManager.EnableClicksOnChildren(true);
            BuildingManager.EnableClicksOnChildren(true);
        }
        else
        {
            StatsPanel.SetActive(true);
            text.text = "Close";

            PeopleManager.EnableClicksOnChildren(false);
            BuildingManager.EnableClicksOnChildren(false);
        }
    }
}
