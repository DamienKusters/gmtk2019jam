using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsDisplay : MonoBehaviour
{
    public GameObject Hud;
    public float timeLeft = 4;
    public PeopleSpawner PeopleManager;
    public BuildingsManager BuildingManager;
    // Start is called before the first frame update
    void Start()
    {
        PeopleManager.EnableClicksOnChildren(false);
        BuildingManager.EnableClicksOnChildren(false);
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Hud.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
