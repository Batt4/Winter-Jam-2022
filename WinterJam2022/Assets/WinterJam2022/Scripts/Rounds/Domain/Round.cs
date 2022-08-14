using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round
{

    public int player1Followers;
    public int totalFollowers;
    public int currentPlayer;
    public bool finished;
    int combo;

    public Round(int player1Followers, int totalFollowers) {
        this.player1Followers = player1Followers;
        this.totalFollowers = totalFollowers;
        this.currentPlayer = 1;
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
