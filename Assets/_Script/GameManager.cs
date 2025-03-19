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
    [SerializeField] private GameObject gameWinUI;
    private bool isGameWinUI;
    private bool isGameOverUI;
    void Start()
    {
        UpdateScore();
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);
    }


    public void AddScore(int point)
    {
        if (!isGameOverUI && !isGameWinUI)
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
    public void GameWin()
    {
        isGameWinUI = true;
        Time.timeScale = 0;
        gameWinUI.SetActive(true);
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
    public bool IsgameWin()
    {
        return isGameWinUI;
    } 
    public void GameMenuLoad()
    {
        SceneManager.LoadScene("Menu");
    }
}
