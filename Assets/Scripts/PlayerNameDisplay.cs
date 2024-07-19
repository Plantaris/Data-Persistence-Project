using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class PlayerNameDisplay : MonoBehaviour
{

    public TMP_Text playerNameText;  // reference to the TextMEshPro text entry element
    public MainManager mainManager;

    
    // Start is called before the first frame update
    void Start()
    {
        playerNameText.text = GameData.PlayerName +"'s High Score:";  // Sets the text to the entered player name

        if (mainManager != null)
        {
            mainManager = FindAnyObjectByType<MainManager>();
        }
        mainManager.AddPoint(0);
        // subscribe to Main Manager Score change method
        if (mainManager != null)
        {
            mainManager.OnScoreChanged += UpdateScoreDisplay;
            mainManager.AddPoint(0);
        }

    }

    private void UpdateScoreDisplay(int newScore)
    {
        playerNameText.text = GameData.PlayerName + "'s High Score: " + newScore;
    }

    private void OnDestroy()
    {
        if (mainManager != null)
        {
            mainManager.OnScoreChanged -= UpdateScoreDisplay;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

   
}
