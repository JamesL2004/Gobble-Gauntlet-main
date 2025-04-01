using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HungryMan : MonoBehaviour
{
    //In the game there are now speed power ups exist and added two new levels
    //I also made it so the score and speed values now transfer over each time a level changes and resets after finishing Level 3
    public Text scoreUI;
    public Text livesUI;
    public int localScore;
    public float localSpeed;
    public GameObject bulletPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreUI = GameObject.Find("ScoreUI").GetComponent<Text>();
        livesUI = GameObject.Find("LivesText").GetComponent<Text>();
        scoreUI.text = "Score: " + GameManager.score.ToString();
        livesUI.text = "Lives: " + GameManager.lives.ToString();
        localScore = GameManager.score;
        localSpeed = GameManager.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position -= new Vector3(GameManager.speed, 0f, 0f);
            this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            this.transform.position -= new Vector3(0f, 0f, GameManager.speed);
            this.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += new Vector3(0f, 0f, GameManager.speed);
            this.transform.rotation = Quaternion.Euler(0f, 270f, 0f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            this.transform.position += new Vector3(GameManager.speed, 0f, 0f);
            this.transform.rotation = Quaternion.Euler(0f, 360f, 0f);
        }
        else if(Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.name.StartsWith("ScorePickup"))
        {
            Debug.Log("Ate a score pickup");
            GameManager.score += 100;
            scoreUI.text = "Score: " + GameManager.score.ToString();
            Destroy(other.gameObject);
        }
        else if (other.transform.gameObject.name.StartsWith("Speed")){
            Debug.Log("Speed increased");
            GameManager.speed += 0.001f;
            Destroy(other.gameObject);
        }
        else if (other.transform.gameObject.name.StartsWith("1Up"))
        {
            Debug.Log("+1 Lives");
            GameManager.lives += 1;
            Destroy(other.gameObject);
            livesUI.text = "Lives: " + GameManager.lives.ToString();
        }
        else if (other.transform.gameObject.name.StartsWith("Follow") || other.transform.gameObject.name.StartsWith("Seek"))
        {
            Scene currentScene = SceneManager.GetActiveScene();
            if (GameManager.lives == 1)
            {
                if (currentScene != null)
                {
                    if (currentScene.name == "Level1")
                    {
                        Debug.Log("Ded... GAME OVER");
                        GameManager.score = 0;
                        GameManager.speed = 0.007f;
                        SceneManager.LoadScene("Menu");
                    }
                    else if (currentScene.name == "Level2")
                    {
                        Debug.Log("Ded... GAME OVER");
                        GameManager.score = 0;
                        GameManager.speed = 0.007f;
                        SceneManager.LoadScene("Menu");
                    }
                    else if (currentScene.name == "Level3")
                    {
                        Debug.Log("Ded... GAME OVER");
                        GameManager.score = 0;
                        GameManager.speed = 0.007f;
                        SceneManager.LoadScene("Menu");
                    }
                    else if (currentScene.name == "Level1_2")
                    {
                        Debug.Log("Ded... GAME OVER");
                        GameManager.score = 0;
                        GameManager.speed = 0.007f;
                        SceneManager.LoadScene("Level1_2");
                    }
                }
            }
            else if(GameManager.lives > 1)
            {
                if (currentScene.name == "Level1")
                {
                    Debug.Log("Ded... restart level");
                    GameManager.lives -= 1;
                    GameManager.score = localScore;
                    GameManager.speed = localSpeed;
                    SceneManager.LoadScene("Level1");
                }
                else if (currentScene.name == "Level2")
                {
                    Debug.Log("Ded... restart level");
                    GameManager.lives -= 1;
                    GameManager.score = localScore;
                    GameManager.speed = localSpeed;
                    SceneManager.LoadScene("Level2");
                }
                else if (currentScene.name == "Level3")
                {
                    Debug.Log("Ded... restart level");
                    GameManager.lives -= 1;
                    GameManager.score = localScore;
                    GameManager.speed = localSpeed;
                    SceneManager.LoadScene("Level3");
                }
                else if (currentScene.name == "Level1_2")
                {
                    Debug.Log("Ded... restart level");
                    GameManager.lives--;
                    GameManager.score = 0;
                    GameManager.speed = 0.007f;
                    SceneManager.LoadScene("Level1_2");
                }
            }
        }
        else if (other.transform.gameObject.name.StartsWith("Goal"))
        {
            Scene currentScene = SceneManager.GetActiveScene();
            if (currentScene != null)
            {
                if(currentScene.name == "Level1_2")
                {
                    Debug.Log("Reached end of level, go to next one");
                    SceneManager.LoadScene("Menu");
                    GameManager.score = 0;
                    GameManager.speed = 0.007f;
                }
                else if(currentScene.name == "Level2")
                {
                    Debug.Log("Reached end of level, go to next one");
                    SceneManager.LoadScene("Level3");
                }
                else if(currentScene.name == "Level3")
                {
                    Debug.Log("Reached end of level, go to next one");
                    SceneManager.LoadScene("Menu");
                    GameManager.score = 0;
                    GameManager.speed = 0.007f;
                }
            }
        }
    }
}
