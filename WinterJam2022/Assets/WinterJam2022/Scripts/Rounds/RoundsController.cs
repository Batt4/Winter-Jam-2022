using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WinterJam2022.Scripts.Presentation;

public class RoundsController : MonoBehaviour
{
    
    int currentRoundId = 0;
    Round initialRound;
    Round currentRound;


    [SerializeField] Round firstRound = new Round(50,100,20,10,5);
    [SerializeField] float totalFollowersIncrement = .1f;
    [SerializeField] float player1FollowersIncrement = -.1f;
    [SerializeField] float playerTimerIncrement = -.1f;
    [SerializeField] float versesIncrement = .1f;

    [SerializeField] EventManager eventManager;
    [SerializeField] GameController gameController;
    [SerializeField] TimerView timerView;
    [SerializeField] FollowersView followersView;

    void Start() {
        this.initialRound = new Round(firstRound);
    }

    void OnEnable() {
        ResetLevels();
    }

    public void NextLevel() {
        Round nextRound = new Round();
        nextRound.player1Followers = CalculateNewLevelValue(initialRound.player1Followers, player1FollowersIncrement);
        nextRound.totalFollowers = CalculateNewLevelValue(initialRound.totalFollowers, totalFollowersIncrement);
        nextRound.timerPlayer = CalculateNewLevelValue(initialRound.timerPlayer, playerTimerIncrement);
        nextRound.quantityOfVerses = CalculateNewLevelValue(initialRound.quantityOfVerses, versesIncrement);
        nextRound.initialCards = initialRound.initialCards;
        this.currentRound = nextRound;
    }

    int CalculateNewLevelValue(int currentValue, float increment) {
        float newValue = currentValue;
        for (int i = 0; i < currentRoundId; i++) {
            newValue = currentValue * (1 + increment/100f);
        }
        return Mathf.FloorToInt(newValue);
    }

    public void ResetLevels() {
        currentRoundId = 1;
        if (initialRound == null) initialRound = new Round(firstRound);
        this.currentRound = new Round(initialRound);
    }

    public void StartRound() {
        Round round = currentRound;
        Debug.Log("INICIANDO ROUND: " + round.player1Followers + " | " + round.totalFollowers + " | " + round.quantityOfVerses + " | " + round.timerPlayer);
        timerView.UpdateTimers(round.timerPlayer, 0.2f);
        gameController.NewRoundInformation(round);
        eventManager.NewRoundInformation(round);
        timerView.RestartTime(true);
        followersView.UpdateFollowers(round.player1Followers, round.totalFollowers);
        gameController.CreateVerse();
        eventManager.ThrowCards();
        eventManager.GetNewCardsFromDeck(round.initialCards);
    }

}
