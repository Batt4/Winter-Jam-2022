using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    
    [SerializeField] GameObject menuScreen;
    [SerializeField] GameObject gameScreen;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject loseScreen;
    [SerializeField] GameObject winScreen;

    public void StartGame() {
        menuScreen.SetActive(false);
        gameScreen.SetActive(true);
    }

    public void BackToGame() {
        gameScreen.SetActive(true);
        loseScreen.SetActive(false);
        winScreen.SetActive(false);
    }

    public void ReturnsMainMenu() {
        menuScreen.SetActive(true);
        gameScreen.SetActive(false);
        pauseScreen.SetActive(false);
        loseScreen.SetActive(false);
        winScreen.SetActive(false);
    }

    public void PauseGame() {
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnpauseGame() {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }

    public void WinScreen() {
        gameScreen.SetActive(false);
        winScreen.SetActive(true);
    }

    public void LoseScreen() {
        gameScreen.SetActive(false);
        loseScreen.SetActive(true);
    }

}
