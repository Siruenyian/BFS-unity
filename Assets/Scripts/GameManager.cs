using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    public int playerHP=3;
    //get enemycount from other script
    public int enemycount;
    [SerializeField] private int enemymax;

    [SerializeField] private GameObject DeadScreen;
    [SerializeField] private GameObject WinScreen;

    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI enemyLeft;

    [SerializeField] private string _nextLevel;
    

    private bool isPaused=false;
    
    private void OnEnable()
    {
        enemycount = 0;
        if(_instance == null) { _instance = this; }
        hpText.text = $"HP: {playerHP}";
    }
    private void Update()
    {
        enemyLeft.text = $"EN: {enemycount}/{enemymax}";
        hpText.text = $"HP: {playerHP}";

        if (enemycount==enemymax)
        {
            WinScreen.SetActive(true);
            Win();
        }
    }


    public void DecreaseHP(int damage)
    {
        if (playerHP-damage>0)
        {
            playerHP -= damage;
        }
        else
        {
            playerHP = 0;
            DeadScreen.SetActive(true);
        }
    }

    public void Win()
    {
        SaveSystem.SavePlayer(1, 100);
    }


    public void LoadNextLevel() {
        SceneManager.LoadScene(_nextLevel);
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
    }
    public void UnpauseGame()
    {
        isPaused = false;
        Time.timeScale = 1;

    }
}
