using UnityEngine;
using System.Collections.Generic;

public class PlayerInteractionTrigger : MonoBehaviour {

    public PlayerInteraction pInteraction;
    public List<InteractiveObject> allCurrentInteractiveObjects = new List<InteractiveObject>();
    //public InteractiveObject currentInteractiveObj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.E)
            && allCurrentInteractiveObjects.Count > 0
            && !pInteraction.isInteracting)
        {
            SendInteraction();
        }
	}

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "InteractiveObject")
        {
            allCurrentInteractiveObjects.Remove(col.gameObject.GetComponent<InteractiveObject>());
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "InteractiveObject")
        {
            allCurrentInteractiveObjects.Add(col.gameObject.GetComponent<InteractiveObject>());
        }
    }
    void SendInteraction()
    {
        pInteraction.DoInteraction(allCurrentInteractiveObjects[0]);
        //allCurrentInteractiveObjects.RemoveAt(0);
    }
}
