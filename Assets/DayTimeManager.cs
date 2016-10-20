using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DayTimeManager : MonoBehaviour {

    public Image fadeInOutPanelImage;
    public Text dayCounterText;

    public int dayCounter;

    [Header("References")]
    public GameObject playerObject;
    public Transform startPos;

    bool fadeIn = false;
    public float fadeInTime = 0f;
    bool fadeOut = false;
    public float fadeOutTime = 0f;
    float fadeTimer = 0f;

	// Use this for initialization
	void Start ()
    {
        dayCounter = 0;

        Color c = fadeInOutPanelImage.color;
        c.a = 1f;
        fadeInOutPanelImage.color = c;

        StartNewDay();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (fadeIn)
        {
            fadeTimer += Time.deltaTime;
            Color c = fadeInOutPanelImage.color;
            c.a = Mathf.Lerp(1f, 0f, (fadeTimer / fadeInTime));
            fadeInOutPanelImage.color = c;
            if (fadeTimer >= fadeInTime)
            {
                fadeIn = false;
                fadeTimer = 0f;
                DayStarts();
            }
        }
        else if (fadeOut)
        {
            fadeTimer += Time.deltaTime;

            Color c = fadeInOutPanelImage.color;
            c.a = Mathf.Lerp(0f, 1f, (fadeTimer / fadeOutTime));
            fadeInOutPanelImage.color = c;

            if (fadeTimer >= fadeOutTime)
            {
                fadeOut = false;
                fadeTimer = 0f;
                StartNewDay();
            }
        }
	}

    public void EndLastDay()
    {
        playerObject.GetComponent<PlayerMover>().PauseMover();
        fadeOut = true;
    }

    public void StartNewDay()
    {
        dayCounter++;
        dayCounterText.text = "Day " + dayCounter.ToString();

        SetUpRoom();
        ResetPlayer();

        fadeIn = true;
    }

    public void DayStarts()
    {
        playerObject.GetComponent<PlayerMover>().RestartMover();
    }

    void SetUpRoom()
    {

    }

    void ResetPlayer()
    {
        playerObject.transform.position = startPos.position;
    }

    
}
