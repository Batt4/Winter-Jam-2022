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

    [SerializeField] RoundsController roundsController;

    public void StartGame() {
        Time.timeScale = 1;
        menuScreen.SetActive(false);
        roundsController.ResetLevels();
        roundsController.StartRound();
    }

    public void BackToGame() {
        Time.timeScale = 1;
        roundsController.StartRound();
        loseScreen.SetActive(false);
        winScreen.SetActive(false);
    }

    public void ReturnsMainMenu() {
        Time.timeScale = 1;
        roundsController.ResetLevels();
        menuScreen.SetActive(true);
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
        roundsController.NextLevel();
        winScreen.SetActive(true);
    }

    public void LoseScreen() {
        roundsController.ResetLevels();
        loseScreen.SetActive(true);
    }

    public void QuitGame() {
        Debug.Log("Salió el juegazo");
        Application.Quit();
    }

}
