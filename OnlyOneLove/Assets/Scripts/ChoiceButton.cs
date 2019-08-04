﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceButton : MonoBehaviour
{
    public Text DialogBox;
    public GameObject ConfessBox;
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
    public GameObject DateCard;
    public float DatecardTime = 5;
    public GameObject EndingUI;
        public Text EndingUIHeader;

    public AudioSource AudioPlayer;
    public AudioClip BadAudio;
    public AudioClip GoodAudio;

    public GameObject[] Buttons = new GameObject[6];

    TalkablePerson Stranger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(DateCard.active)
        {
            DateBackground.SetActive(false);
            DatecardTime -= Time.deltaTime;
            if (DatecardTime < 0)
            {
                DatecardTime = 5F;
                DateCard.SetActive(false);
                DateBackground.SetActive(true);
            }
        }
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
        ConfessBox.SetActive(false);

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

                DateCard.SetActive(true);

                GiftTextures.ItemId = 0;
                DialogBox.text = "What a beautiful evening isn't it?";

                PlazaBackground.SetActive(false);

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
                if (Stranger.isTrueLove)
                {
                    if (Stranger.isTrueLove)
                        EndingUIHeader.text = "You ABANDONED your 'true love'";

                    AudioPlayer.clip = BadAudio;
                    AudioPlayer.Play();
                    ConversationUI.SetActive(false);
                    EndingUI.SetActive(true);
                    return;
                }

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
                break;
            case 21://Date about yourself

                if(Stranger.uitgepraat)
                {
                    DialogBox.text = "I think we've already discussed everything.";
                    return;
                }

                DialogBox.text = "What do you want to talk about?";

                EnableTierDateButtons(false);
                EnableTierDate2Buttons(true);
                break;
            case 22://Confess
                ConfessBox.SetActive(true);
                break;
            case 30://Talk hobbies

                if(Stranger.knowsHobby)
                {
                    DialogBox.text = "We've already discussed that...";
                    return;
                }
                Stranger.knowsHobby = true;

                if (Stranger.HobbyId == playerInterests.playerHobbyId)
                {
                    DialogBox.text = "Oh realy?! I like that hobby too!";
                    if (CheckIfUitgepraat())
                        SetIsUitgepraat();
                    return;
                }

                DialogBox.text = "Hmm, I myself aint the right person for that activity.";
                SetIsUitgepraat();
                break;
            case 31://Talk location

                if (Stranger.knowsLocation)
                {
                    DialogBox.text = "You know my preference, we just talked about it...";
                    return;
                }
                Stranger.knowsLocation = true;

                if (Stranger.LocationId == playerInterests.playerLocationId)
                {
                    DialogBox.text = "I agree! I find that outing to be amazing as well!";
                    if (CheckIfUitgepraat())
                        SetIsUitgepraat();
                    return;
                }

                DialogBox.text = "I'd rather go somewhere else. I don't like that place at all!";
                SetIsUitgepraat();
                break;
            case 32://Talk animal
                if (Stranger.knowsAnimal)
                {
                    DialogBox.text = "We've already been over that topic, just a moment ago...";
                    return;
                }
                Stranger.knowsAnimal = true;

                if (Stranger.AnimalId == playerInterests.playerAnimalId)
                {
                    DialogBox.text = "Those creatures are adorable right?!";

                    if (CheckIfUitgepraat())
                        SetIsUitgepraat();

                    return;
                }

                DialogBox.text = "Hate to break it to you, but I absolutely despise those creatures.";
                SetIsUitgepraat();

                break;
            case 40://cancel
                ConfessBox.SetActive(false);
                break;
            case 41://CONFESS!!!!!!!!!!!!!!!!!!!!!

                if (Stranger.isTrueLove)
                {
                    EndingUIHeader.text = "You confessed to your TRUE LOVE!";

                    AudioPlayer.clip = GoodAudio;
                    AudioPlayer.Play();
                }
                else
                {
                    EndingUIHeader.text = "She DECLINED your love!";
                    AudioPlayer.clip = BadAudio;
                    AudioPlayer.Play();
                }

                ConversationUI.SetActive(false);
                EndingUI.SetActive(true);
                break;
            default:
                break;
        }
    }

    void SetIsUitgepraat()
    {
        Stranger.uitgepraat = true;
        EnableTierDate2Buttons(false);
        EnableTierDateButtons(true);
    }

    bool CheckIfUitgepraat()
    {
        return Stranger.knowsHobby && Stranger.knowsLocation && Stranger.knowsAnimal;
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
