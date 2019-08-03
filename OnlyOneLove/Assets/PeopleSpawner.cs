using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawner : MonoBehaviour
{
    public string[] Greetings = new string[6];

    void Start()
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            var Woman = this.gameObject.transform.GetChild(i).GetComponent<TalkablePerson>();
            Woman.Greeting = Greetings[Random.Range(0, 6)];
            Debug.Log(Woman.Greeting);
        }
    }

    void Update()
    {
        
    }

    public void EnableClicksOnChildren(bool enabled)
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            var Go = this.gameObject.transform.GetChild(i).GetComponent<TalkablePerson>().CanBeClicked = enabled;
        }
    }
}
