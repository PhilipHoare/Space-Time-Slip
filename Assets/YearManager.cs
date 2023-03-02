using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class YearManager : MonoBehaviour
{

    public GameObject rocket;
    public GameObject yearTextDisplayObject;
    private TextMeshProUGUI yearTextDisplay;
    private int year;
    private string yearToDisplay;
    private bool ce;

    private int clock;

    // Start is called before the first frame update
    void Start()
    {
        yearTextDisplay = yearTextDisplayObject.GetComponent<TextMeshProUGUI>();
        year = 100;
        clock = 0;
        ce = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rocket.transform.position.y > 50 && clock > 100)
        {
            clock = 0;

            if (ce)
            {
                year += 1;
                yearToDisplay = year + "CE";
            } else
            {
                year -= 1;
                yearToDisplay = year + "BCE";
                if (year == 1) { ce = true; }
            }

            yearTextDisplay.SetText(yearToDisplay);
        } else
        {
            clock += 1;
        }
    }
}
