using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkablePerson : MonoBehaviour
{
    public ChoiceButton ConversationManager;
    public bool CanBeClicked = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (CanBeClicked)
        {
            ConversationManager.EnableConversation(gameObject);
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
