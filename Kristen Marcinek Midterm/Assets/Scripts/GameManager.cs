using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Collectible c;
    public PlayerController pc;
    public static int score;
    public GameObject collectible;
    public GameObject enemy;
    public float timer = 60;
    public float timerAlt;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI finalScoreText;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            Instantiate(enemy, new Vector3(Random.Range(-200f, 200f), 10, Random.Range(-250f, 250f)), Quaternion.identity);
            Instantiate(collectible, new Vector3(Random.Range(-200f, 200f), 10, Random.Range(-250f, 250f)), Quaternion.identity);
        }
        
        score = 0;

        gameOverText.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
        finalScoreText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        timerAlt = Mathf.Round(timer);
        timerText.text = "Time: " + timerAlt.ToString();

        if (timer <= 0 && score < 20)
        {
            gameOverText.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(false);
            timerText.gameObject.SetActive(false);
            finalScoreText.gameObject.SetActive(true);
            StartCoroutine(RestartScene());
        }

        if (timer <= 0 && score >= 20)
        {
            winText.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(false);
            timerText.gameObject.SetActive(false);
            finalScoreText.gameObject.SetActive(true);
            StartCoroutine(RestartScene());
        }

        finalScoreText.text = "Final Score: " + score.ToString();
        scoreText.text = "Score: " + score.ToString();
    }

    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }
}
