using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkablePerson : MonoBehaviour
{
    public ChoiceButton ConversationManager;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(ConversationManager);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        Debug.Log("click");
        ConversationManager.EnableConversation(gameObject);
    }
}
