using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using TMPro;

public class UIChange : MonoBehaviour
{
    public TextMeshProUGUI Upgrades;
    public TextMeshProUGUI Timer;
    public string upgradeCount = "Upgrades: ";
    double trueStopWatch;
    int timerCount;
    bool dJumpAdded = false;
    bool dashAdded = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.doubleJump == true && dJumpAdded == false)
        {
            upgradeCount += " Double Jump Obtained ";
            dJumpAdded = true;
        }
        if (PlayerMovement.dash == true && dashAdded == false)
        {
            upgradeCount += " Dash Obtained ";
            dashAdded = true;
        }
        trueStopWatch += Time.deltaTime;
        if (trueStopWatch > 1)
        {
            timerCount += 1;
            trueStopWatch = 0;
        }
        Timer.text = "Timer: " + timerCount.ToString();
        Upgrades.text = upgradeCount;
    }
}
