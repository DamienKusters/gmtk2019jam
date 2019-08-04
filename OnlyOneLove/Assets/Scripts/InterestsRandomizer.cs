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
        

        //Randomize stranger interests
        for (int i = 0; i < strangers.Length; i++)
        {
            GiveStrangerRandomInterests(strangers[i]);
        }

        MakeStrangersUnique(strangers);

        int trueLoveId = Random.Range(0,5);
        strangers[trueLoveId].isTrueLove = true;//Set true love

        //Initialize player interests
        playerHobbyId = strangers[trueLoveId].HobbyId;
        playerLocationId = strangers[trueLoveId].LocationId;
        playerAnimalId = strangers[trueLoveId].AnimalId;

        Debug.Log(strangers[trueLoveId].strangerId + " is the ONE");// D E B U G ###############################

        //Render player interest on screen
        RenderPlayerInterests();
    }
    
    void MakeStrangersUnique(TalkablePerson[] _strangers)
    {
        for (int i = 0; i < _strangers.Length; i++)
        {
            do
            {
                GiveStrangerRandomInterests(_strangers[i]);
                SetFlagIfDuplicate(_strangers[i], _strangers);//This method marks the current stranger as duplicate
            } while (_strangers[i].isDuplicate);
        }
    }

    void GiveStrangerRandomInterests(TalkablePerson _stranger)
    {
        _stranger.HobbyId = Random.Range(0, 3);
        _stranger.LocationId = Random.Range(0, 3);
        _stranger.AnimalId = Random.Range(0, 3);
    }

    void SetFlagIfDuplicate(TalkablePerson _stranger, TalkablePerson[] _strangers)
    {
        foreach (var person in _strangers)
        {
            //Check if one of the duplicates matches 
            if (person.HobbyId == _stranger.HobbyId &&
                person.LocationId == _stranger.LocationId &&
                person.AnimalId == _stranger.AnimalId)
            {
                if(person.strangerId != _stranger.strangerId)//If the person is not checking herself
                {
                    _stranger.isDuplicate = true;//Set flag
                    return;//Cancel method
                }
            }
        }
        _stranger.isDuplicate = false;//If the person doesn't match it means it's unique
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
