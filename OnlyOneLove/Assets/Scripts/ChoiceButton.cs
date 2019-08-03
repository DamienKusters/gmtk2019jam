using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceButton : MonoBehaviour
{
    public Text DialogBox;
    public PeopleSpawner PeopleManager;
    public BuildingsManager BuildingManager;
    public GameObject ConversationUI;
    public GameObject HudUI;
    public GameObject[] Buttons = new GameObject[6];

    TalkablePerson Stranger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableConversation(TalkablePerson person)
    {
        //Disable clicking on people & buildings
        PeopleManager.EnableClicksOnChildren(false);
        BuildingManager.EnableClicksOnChildren(false);

        Stranger = person;

        DialogBox.text = Stranger.Greeting;

        //Reset buttons
        EnableTier1Buttons(true);
        EnableTierQuestionButtons(false);
        EnableTierQuestion2Buttons(false);

        //Switch out Hud with Conversation UI
        ConversationUI.SetActive(true);
        HudUI.SetActive(false);
    }

    public void ClickConversationButton(int id)
    {
        switch (id)
        {
            case 0://Introduction
                EnableTier1Buttons(false);
                break;
            case 1://Question
                EnableTier1Buttons(false);
                EnableTierQuestionButtons(true);
                break;
            case 2://Date
                Debug.Log("Ask on date");
                break;
            case 10://Question 1
                EnableTierQuestionButtons(false);
                EnableTierQuestion2Buttons(true);
                break;
            case 11://Question 2
                EnableTierQuestionButtons(false);
                EnableTierQuestion2Buttons(true);
                break;
            case 12://Question 3
                EnableTierQuestionButtons(false);
                EnableTierQuestion2Buttons(true);
                break;
            case 13://Question Exit
                PeopleManager.EnableClicksOnChildren(true);
                BuildingManager.EnableClicksOnChildren(true);
                ConversationUI.SetActive(false);
                HudUI.SetActive(true);
                break;
            default:
                break;
        }
    }

    void EnableTier1Buttons(bool enabled)
    {
        Buttons[0].SetActive(enabled);
        Buttons[1].SetActive(enabled);
        Buttons[2].SetActive(enabled);
    }

    void EnableTierQuestionButtons(bool enabled)
    {
        Buttons[3].SetActive(enabled);
        Buttons[4].SetActive(enabled);
        Buttons[5].SetActive(enabled);
    }

    void EnableTierQuestion2Buttons(bool enabled)
    {
        Buttons[6].SetActive(enabled);
    }
}
