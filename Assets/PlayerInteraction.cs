using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour {

    public EventsManager eventMan;
    public PlayerMover pMover;

    public bool isInteracting = false;
    bool canExitInteraction = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Single frame delay on hitting interact key
        if(canExitInteraction == false)
        {
            canExitInteraction = true;
            isInteracting = true;
            return;
        }

	    if(Input.GetKeyDown(KeyCode.E)
            && isInteracting)
        {
            NextInteraction();
        }
	}

    public void DoInteraction(InteractiveObject intObj)
    {
        if (!isInteracting)
        {
            Debug.Log(intObj.name);
            pMover.PauseMover();
            eventMan.StartEvent(intObj.eventID);
            canExitInteraction = false;
            //isInteracting = true;
        }
    }

    public void NextInteraction()
    {
        if(eventMan.CanContinueEvent())
        {
            eventMan.ContinueEvent();
        }
        else
        {
            StopInteraction();
        }
    }

    public void StopInteraction()
    {
        eventMan.EndCurrentEvent();
        pMover.RestartMover();
        isInteracting = false;
    }
}
