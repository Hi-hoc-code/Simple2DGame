using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverUI;
    private bool isGameOverUI;
    void Start()
    {
        UpdateScore();
        gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void AddScore(int point)
    {
        if (!isGameOverUI)
        {
        score += point;
        UpdateScore();
        }
    }
    private void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
    public void GameOver()
    {
        isGameOverUI = true;
        score = 0;
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
    }
    public void RestartGame()
    {
        isGameOverUI = false;
        score = 0;
        UpdateScore();
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }
    public bool IsGameOver()
    {
        return isGameOverUI;
    }
}
