using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public playerStats stats;
    public TextMeshProUGUI scrap;
    
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onScrapTriggerEnter += updateScore;
    }

    public void updateScore()
    {
        scrap.SetText("" + stats.scrap);
    }
}
