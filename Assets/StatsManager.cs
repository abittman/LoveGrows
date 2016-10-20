using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class LoveRating
{
    public int minValue = 0;
    public int maxValue = 1;
    public string ratingName = "Good";
}

public class StatsManager : MonoBehaviour {

    public int currentLoveStat = 100;

    public Text loveStat;

    public List<LoveRating> allLoveRatings = new List<LoveRating>();

    private LoveRating currentLoveRating;
    public LoveRating CurrentLoveRating
    {
        get { return currentLoveRating; }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddLove(int amount)
    {
        currentLoveStat += amount;
        loveStat.text = currentLoveStat.ToString();

        foreach(LoveRating lr in allLoveRatings)
        {
            if(currentLoveStat < lr.maxValue
                && currentLoveStat >= lr.minValue)
            {
                currentLoveRating = lr;
                break;
            }
        }
    }
}
