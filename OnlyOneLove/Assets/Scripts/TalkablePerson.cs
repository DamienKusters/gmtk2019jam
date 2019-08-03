using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkablePerson : MonoBehaviour
{
    public ChoiceButton ConversationManager;
    public bool CanBeClicked = true;

    public int HobbyId;
    public int LocationId;
    public int AnimalId;

    public bool personKnowsStranger = false;
    public bool personIsAboutToMatch = false;
    public bool isTrueLove = false;

    public bool knowsHobby = false;
    public bool knowsLocation = false;
    public bool knowsAnimal = false;
    public bool uitgepraat = false;

    public int FavGiftId = 1;
    public string Greeting = "Hallo Pik!";
    public Sprite Sprite;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public string TellAboutHobby()
    {
        string prefix = "My primary hobby is ";

        switch (HobbyId)
        {
            case 0:
                return prefix + "shopping.";
                break;
            case 1:
                return prefix + "cooking.";
                break;
            case 2:
                return prefix + "jogging.";
                break;
            default:
                return "Glitch in the Matrix";
                break;
        }
        knowsHobby = true;
    }

    public string TellAboutLocation()
    {
        string prefix = "I love to go to ";

        switch (LocationId)
        {
            case 0:
                return prefix + "the park.";
                break;
            case 1:
                return prefix + "a forest.";
                break;
            case 2:
                return prefix + "a lake.";
                break;
            default:
                return "Glitch in the Matrix";
                break;

        }
        knowsLocation = true;
    }

    public string TellAboutAnimal()
    {
        string prefix = "I realy like ";

        switch (AnimalId)
        {
            case 0:
                return prefix + "dogs.";
                break;
            case 1:
                return prefix + "cats.";
                break;
            case 2:
                return prefix + "guinea pigs.";
                break;
            default:
                return "Glitch in the Matrix";
                break;
        }
        knowsAnimal = true;
    }

    void OnMouseDown()
    {
        if (CanBeClicked)
        {
            ConversationManager.EnableConversation(gameObject.GetComponent<TalkablePerson>());
            transform.localScale = new Vector3(4F, 4F, 4F);
        }
    }

    void OnMouseEnter()
    {
        if (CanBeClicked)
            transform.localScale += new Vector3(1F, 1F, 1F);
    }

    void OnMouseExit()
    {
        if (CanBeClicked)
            transform.localScale = new Vector3(4F, 4F, 4F);
    }
}
