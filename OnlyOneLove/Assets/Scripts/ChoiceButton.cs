using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceButton : MonoBehaviour
{
    public Text DialogBox;
    public Image StrangerImage;
    public Image StrangerFavItem;

    public InterestsRandomizer playerInterests;

    public GameObject PlazaBackground;
    public GameObject DateBackground;

    public AudioSource Player;
    public AudioClip PlazaBgm;
    public AudioClip DatingBgm;

    public PlayerInventoryManager GiftTextures;

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
        //Reset background
        PlazaBackground.SetActive(true);
        DateBackground.SetActive(false);

        //Disable clicking on people & buildings
        PeopleManager.EnableClicksOnChildren(false);
        BuildingManager.EnableClicksOnChildren(false);

        Stranger = person;

        DialogBox.text = Stranger.Greeting;
        StrangerFavItem.sprite = GiftTextures.GiftSprites[Stranger.FavGiftId];
        StrangerImage.sprite = Stranger.Sprite;

        //Reset buttons
        EnableTier1Buttons(true);
        EnableTierQuestionButtons(false);
        EnableTierDateButtons(false);
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
                PeopleManager.EnableClicksOnChildren(true);
                BuildingManager.EnableClicksOnChildren(true);
                ConversationUI.SetActive(false);
                HudUI.SetActive(true);
                break;
            case 1://Question

                if (Stranger.personKnowsStranger)
                {
                    DialogBox.text = "Sorry, but I don't have time for so many questions.";
                    return;
                }
                DialogBox.text = "What do you want to ask?";

                EnableTier1Buttons(false);
                EnableTierQuestionButtons(true);
                break;
            case 2://Date
                if(!Stranger.personKnowsStranger)
                {
                    DialogBox.text = "What?! No WAY! You don't even know me.";
                    return;
                }
                if (!Stranger.personIsAboutToMatch)
                {
                    DialogBox.text = "Sorry, but no. I don't think we fit for each other.";
                    return;
                }
                if(Stranger.FavGiftId != GiftTextures.ItemId)
                {
                    DialogBox.text = "Nah, if you bring me something nice, I'll reconsider.";
                    return;
                }

                GiftTextures.ItemId = 0;
                DialogBox.text = "What a beautiful evening isn't it?";

                PlazaBackground.SetActive(false);
                DateBackground.SetActive(true);

                Player.enabled = true;
                Player.clip = DatingBgm;
                Player.Play();

                EnableTierDateButtons(true);

                break;
            case 10://Question 1
                EnableTierQuestionButtons(false);
                EnableTierQuestion2Buttons(true);
                DialogBox.text = Stranger.TellAboutHobby();
                Stranger.personKnowsStranger = true;
                if (playerInterests.playerHobbyId == Stranger.HobbyId)
                    Stranger.personIsAboutToMatch = true;
                break;
            case 11://Question 2
                EnableTierQuestionButtons(false);
                EnableTierQuestion2Buttons(true);
                DialogBox.text = Stranger.TellAboutLocation();
                Stranger.personKnowsStranger = true;
                if (playerInterests.playerLocationId == Stranger.LocationId)
                    Stranger.personIsAboutToMatch = true;
                break;
            case 12://Question 3
                EnableTierQuestionButtons(false);
                EnableTierQuestion2Buttons(true);
                DialogBox.text = Stranger.TellAboutAnimal();
                Stranger.personKnowsStranger = true;
                if (playerInterests.playerAnimalId == Stranger.AnimalId)
                    Stranger.personIsAboutToMatch = true;
                break;
            case 13://Question Exit
                PeopleManager.EnableClicksOnChildren(true);
                BuildingManager.EnableClicksOnChildren(true);
                ConversationUI.SetActive(false);
                HudUI.SetActive(true);
                break;
            case 20://Date leave
                PlazaBackground.SetActive(true);
                DateBackground.SetActive(false);

                Player.enabled = true;
                Player.clip = PlazaBgm;
                Player.Play();

                PeopleManager.EnableClicksOnChildren(true);
                BuildingManager.EnableClicksOnChildren(true);
                ConversationUI.SetActive(false);
                HudUI.SetActive(true);

                Stranger.gameObject.SetActive(false);

                if (Stranger.isTrueLove)
                    Debug.Log("GAME OVER - You dumped your true love");

                break;
            case 21://Date about yourself
                DialogBox.text = "What do you want to talk about?";

                EnableTierDateButtons(false);
                EnableTierDate2Buttons(true);
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

    void EnableTierDateButtons(bool enabled)
    {
        Buttons[7].SetActive(enabled);
        Buttons[8].SetActive(enabled);
        Buttons[9].SetActive(enabled);
    }

    void EnableTierDate2Buttons(bool enabled)
    {
        Buttons[10].SetActive(enabled);
        Buttons[11].SetActive(enabled);
        Buttons[12].SetActive(enabled);
    }

    void EnableTierQuestion2Buttons(bool enabled)
    {
        Buttons[6].SetActive(enabled);
    }
}
