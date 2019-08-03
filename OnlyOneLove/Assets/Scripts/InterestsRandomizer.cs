using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterestsRandomizer : MonoBehaviour
{
    public int playerHobbyId;
    public int playerLocationId;
    public int playerAnimalId;

    public Text playerHobbyText;
    public Text playerLocationText;
    public Text playerAnimalText;

    public TalkablePerson[] strangers;

    public string[] hobbies;
    public string[] locations;
    public string[] animals;

    void Start()
    {
        /*
        //Initialize player interests
        playerHobbyId = Random.Range(0,3);
        playerLocationId = Random.Range(0,3);
        playerAnimalId = Random.Range(0,3);
        */

        //Render player interest on screen
        RenderPlayerInterests();

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

    void RenderPlayerInterests()
    {
        switch (playerHobbyId)
        {
            case 0:
                playerHobbyText.text = "Shopping";
                break;
            case 1:
                playerHobbyText.text = "Cooking";
                break;
            case 2:
                playerHobbyText.text = "Jogging";
                break;
            default:
                break;
        }
        switch (playerLocationId)
        {
            case 0:
                playerLocationText.text = "The Park";
                break;
            case 1:
                playerLocationText.text = "The Forest";
                break;
            case 2:
                playerLocationText.text = "A Lake";
                break;
            default:
                break;
        }
        switch (playerAnimalId)
        {
            case 0:
                playerAnimalText.text = "Dog";
                break;
            case 1:
                playerAnimalText.text = "Cat";
                break;
            case 2:
                playerAnimalText.text = "Guinea pig";
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
