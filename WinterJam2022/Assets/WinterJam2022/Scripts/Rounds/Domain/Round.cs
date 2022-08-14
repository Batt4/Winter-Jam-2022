using System;
using UnityEngine;

[Serializable]
public class Round
{

    public int player1Followers;
    public int totalFollowers;
    public int timerPlayer;
    public int quantityOfVerses;
    public int initialCards;


    public int currentPlayer;
    public bool finished;
    int combo;

    public Round(int player1Followers, int totalFollowers, int timerPlayer, int quantityOfVerses, int initialCards) {
        this.player1Followers = player1Followers;
        this.totalFollowers = totalFollowers;
        this.currentPlayer = 1;
        this.finished = false;
        this.timerPlayer = timerPlayer;
        this.quantityOfVerses = quantityOfVerses;
        this.initialCards = initialCards;
    }

    public Round(Round round) {
        this.player1Followers = round.player1Followers;
        this.totalFollowers = round.totalFollowers;
        this.currentPlayer = 1;
        this.finished = false;
        this.timerPlayer = round.timerPlayer;
        this.quantityOfVerses = round.quantityOfVerses;
        this.initialCards = round.initialCards;
    }

    public Round() {
        this.currentPlayer = 1;
        this.finished = false;
    }

    public void AddToCombo() => combo++;

    public void ResetCombo() => combo = 0;

    public double GetCurrentCombo() => combo * 0.2;
    
    public void UpdateFollowers(int deltaFollowers) {
        this.player1Followers += deltaFollowers;
    }

    public void PassTurn() {
        this.currentPlayer = this.currentPlayer == 1? 2: 1;
    }

}
