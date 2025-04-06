using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{

    public Text highScoreUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highScoreUI = GameObject.Find("HighScoreUI").GetComponent<Text>();
        highScoreUI.text = "Your Final Score is: " + GameManager.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
