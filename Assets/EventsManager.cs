using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class LoveGrowsEvents
{
    public string eventID;
    public List<string> orderedTextResponses;
    public int loveGrowthStat;
    public bool endDayOnEndEvent = false;
}

public class EventsManager : MonoBehaviour {

    public DayTimeManager dayTimeMan;
    public StatsManager statsMan;

    public List<LoveGrowsEvents> allEvents = new List<LoveGrowsEvents>();
    LoveGrowsEvents currentEvent;
    int currentTextID = 0;

    public GameObject dialoguePanelObj;
    public Text interactiveText;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartEvent(string eventID)
    {
        LoveGrowsEvents thisEvent = allEvents.Find(x => x.eventID == eventID);
        if (thisEvent != null)
        {
            currentEvent = thisEvent;
            currentTextID = 0;
            dialoguePanelObj.SetActive(true);
            interactiveText.text = thisEvent.orderedTextResponses[0];
        }
        else
        {
            Debug.Log("Wrong event id - " + eventID);
        }
    }

    public bool CanContinueEvent()
    {
        bool canContinue = false;
        if (currentTextID + 1 < currentEvent.orderedTextResponses.Count)
        {
            canContinue = true;
        }
        return canContinue;
    }

    public void ContinueEvent()
    {
        currentTextID++;
        interactiveText.text = currentEvent.orderedTextResponses[currentTextID];
    }

    public void EndCurrentEvent()
    {
        dialoguePanelObj.SetActive(false);

        if(currentEvent.loveGrowthStat > 0)
        {
            statsMan.AddLove(currentEvent.loveGrowthStat);
        }

        if(currentEvent.endDayOnEndEvent)
        {
            dayTimeMan.EndLastDay();
        }
        else
        {
            currentEvent = null;
        }
    }
}
