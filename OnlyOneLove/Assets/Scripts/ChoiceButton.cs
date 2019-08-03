﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceButton : MonoBehaviour
{
    public GameObject ConversationUI;
    public GameObject HudUI;
    public GameObject[] Buttons = new GameObject[6];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
                EnableTier1Buttons(true);
                EnableTierQuestion2Buttons(false);
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
