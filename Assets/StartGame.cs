using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void BeginGame()
    {
        Debug.Log("Starting a new game");
        SceneManager.LoadScene("Level1_2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
