using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkablePerson : MonoBehaviour
{
    public ChoiceButton ConversationManager;
    public bool CanBeClicked = true;

    public string Hobby = "Shopping";
    public string Location = "The Park";
    public string Animal = "Dogs";
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
        return "My primary hobby is " + Hobby;
    }

    public string TellAboutLocation()
    {
        return "I love to go to " + Hobby;
    }

    public string TellAboutAnimal()
    {
        return "I realy like " + Animal;
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
