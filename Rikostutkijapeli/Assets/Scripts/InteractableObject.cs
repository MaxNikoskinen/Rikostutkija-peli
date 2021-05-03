using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public int objectStyle;
    public GameObject trollFaceDialogue = null;
    public CursorChange cursorChangeScript = null;
    public PlayerMovement playerMovementScript = null;
    public InteractIndicator interactIndicatorScript = null;

    public void DecideObject()
    {
        if(objectStyle == 0)
        {
            TrollFaceConversation();
        }
    }

    public void DecideObjectIndicator()
    {
        if (objectStyle == 0)
        {
            TrollFaceConversationIndicator();
        }
    }
    
    public void TrollFaceConversation()
    {
        trollFaceDialogue.SetActive(true);
        cursorChangeScript.ShowCursor();
        playerMovementScript.allowLooking = false;
        playerMovementScript.allowLooking = false;
    }

    public void TrollFaceConversationIndicator()
    {
        interactIndicatorScript.speakIndicator.SetActive(true);
    }
}
