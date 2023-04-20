using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public static TextManager instance;

    public int leaveCount;

    public int endLeave;

    public AudioSource leafCut;

    public TMP_Text poemText;

    public Animator textAnim;

    public Animator mainMenuPanelAnim;

    public string[] poemTexts;

    public AnimPostProcessing animPostProcessing;

    private List<int> randomNumbersList = new List<int>();

    public int count;

    public int min, max;

    public Animator tutorialAnim;
   

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

        tutorialAnim = GameObject.FindGameObjectWithTag("Tutorial").GetComponent<Animator>();
    }

    

    // Update is called once per frame
    void Update()
    {
        //poemText.text = "Let the light in" + " " + leaveCount;


        /*
        switch (leaveCount)
        {
            case 1:
                poemText.text = "let the light in";
                break;
            case 2:
                poemText.text = "as the sun turns";
                break;
            case 3:
                poemText.text = "for each fallen";
                break;
            case 4:
                poemText.text = "reminiscing hearts chasing";
                break;
            case 5:
                poemText.text = "loving gives perception";
                break;
            case 6:
                poemText.text = "nature and grace fusing";
                break;
        }
        */
    }

    public void AddLeaveCount()
    {
        leaveCount++;
        PickPhrase();
        leafCut.pitch = Random.Range(1, 1.2f);
        leafCut.Play();
    }

    void PickPhrase()
    {

        int randomNumber = -1;

        randomNumber = Random.Range(min, max);

        do
        {
            randomNumber = Random.Range(min, max);
        } while (randomNumbersList.Contains(randomNumber));

        poemText.text = poemTexts[randomNumber];

        randomNumbersList.Add(randomNumber);

        count++;

        if (count >=(max-min))
        {
            count = 0;
            randomNumbersList.Clear();
        }

        
    }


    public void ResetPhrases()
    {
        count = 0;
        randomNumbersList.Clear();
    }

}
