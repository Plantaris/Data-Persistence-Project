using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // TextMeshPro namespace

public class UIManager : MonoBehaviour
{

    public TMP_InputField nameInputField; // reference to input field
    public Button startButton; // reference to start button


    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(OnStartButtonClicked); // add listener tom button
    }

    void OnStartButtonClicked()
    {
        string playerName = nameInputField.text; // gets text from inpuit field

        GameData.PlayerName = playerName;  //stores player name

        SceneManager.LoadScene("main");

        Debug.Log("Player Name: " + playerName);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
