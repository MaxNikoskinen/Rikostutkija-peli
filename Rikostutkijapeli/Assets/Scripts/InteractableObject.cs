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
    public Animator doorAnim = null;
    private bool doorOpen = false;


    public void DecideObject()
    {
        if(objectStyle == 0)
        {
            TrollFaceConversation();
        }
        else if (objectStyle == 2)
        {
            DoDoor();
        }
    }

    public void DecideObjectIndicator()
    {
        if (objectStyle == 0)
        {
            TrollFaceConversationIndicator();
        }
        else if (objectStyle == 2)
        {
            DoDoorIndicator();
        }
    }



    
    public void TrollFaceConversation()
    {
        trollFaceDialogue.SetActive(true);
        cursorChangeScript.ShowCursor();
        playerMovementScript.allowLooking = false;
        playerMovementScript.allowMovement = false;
    }

    public void TrollFaceConversationIndicator()
    {
        interactIndicatorScript.speakIndicator.SetActive(true);
    }




    public void DoDoor()
    {
        if(doorOpen == false)
        {
            doorAnim.Play("DoorOpen", 0, 0.0f);
            doorOpen = true;
        }
        else
        {
            doorAnim.Play("DoorClose", 0, 0.0f);
            doorOpen = false;
        }
    }

    public void DoDoorIndicator()
    {

    }
}
