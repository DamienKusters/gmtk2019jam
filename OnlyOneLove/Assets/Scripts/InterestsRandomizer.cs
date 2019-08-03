using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterestsRandomizer : MonoBehaviour
{
    public int playerHobbyId;
    public int playerLocationId;
    public int playerAnimalId;

    public TalkablePerson[] strangers;

    public string[] hobbies;
    public string[] locations;
    public string[] animals;

    void Start()
    {
        //Initialize player interests
        playerHobbyId = Random.Range(0,3);
        playerLocationId = Random.Range(0,3);
        playerAnimalId = Random.Range(0,3);
        
        for (int i = 0; i < strangers.Length; i++)
        {
            strangers[i].HobbyId = Random.Range(0, 3);
            strangers[i].LocationId = Random.Range(0, 3);
            strangers[i].AnimalId = Random.Range(0, 3);
        }
    }
    
    List<TalkablePerson> GetDuplicateStrangers()
    {
        List<TalkablePerson> duplicates = new List<TalkablePerson>();

        for (int i = 0; i < duplicates.Capacity; i++)
        {

        }
        return duplicates;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
