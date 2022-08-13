using System;
using UnityEngine;
using UnityEngine.UI;
using WinterJam2022.Scripts.Verses.Domain;

namespace WinterJam2022.Scripts.Presentation
{
    public class EventManager : MonoBehaviour
    {

        Verse CurrentVerse;
        Round round;
        [SerializeField] GameController gameController;
        [SerializeField] FollowersView followersView;
        [SerializeField] TimerView timerView;
        [SerializeField] RectTransform cardsContainer;
        [SerializeField] GameObject cardViewTemplate;

        private const int TIMEOUT_PENALTY = 8;
        
        private void Start() 
        {
            round = new Round(50, 100); // Mock Round
        }

        public void PlayCard(object sender, EventArgs args)
        {
            var playerThatPlayedTheCard = ((CardPlayedArgs)args).player;
            if (CurrentVerse == null || round.currentPlayer != playerThatPlayedTheCard) {
                Debug.LogWarning("Card wasn't able to be played yet.");
                return;
            }

            var card = ((CardPlayedArgs)args).Card;
            var cardObject = ((CardPlayedArgs)args).cardObject;
            bool cardWasOk = CurrentVerse.VerifyWord(card.Word);
            UpdateRoundFollowers(card.Word.Points * (cardWasOk? 1: -1));
            Destroy(cardObject);
            PassTurn();
            Debug.Log($"Card played: {card}");
        }

        public void SetCurrentVerse(Verse verse)
        {
            CurrentVerse = verse;
            timerView.RestartTime();
            Debug.Log($"Current verse: {verse}");
        }

        public void Timeout() {
            UpdateRoundFollowers(TIMEOUT_PENALTY * (round.currentPlayer != 1? 1: -1));
            PassTurn();
        }

        public void PassTurn() {
            round.PassTurn();
            GetNewCardFromDeck();
            gameController.CreateVerse();
        }

        public void FinishRound()
        {
            string winnerPlayer = "PLAYER";
            if (this.round.player1Followers < this.round.totalFollowers / 2)
                winnerPlayer = "ENEMY";
            Debug.Log($"Finishing round. {winnerPlayer} is the Winner!");
            this.round.currentPlayer = 0;
            //Application.Quit();
        }

        void GetNewCardFromDeck() {
            if (round.currentPlayer == 1) Instantiate(cardViewTemplate, cardsContainer);
        }

        void UpdateRoundFollowers(int points) {
            round.UpdateFollowers(points);
            followersView.UpdateFollowers(round.player1Followers, round.totalFollowers);
            if (round.player1Followers >= round.totalFollowers) {
                FinishRound();
            }
        }
    }
    
    public class CardPlayedArgs : EventArgs
    {
        public readonly GameObject cardObject;
        public readonly Card Card;
        public readonly int player;

        CardPlayedArgs(GameObject cardObject, Card card, int player) {
            this.cardObject = cardObject;
            this.Card = card;
            this.player = player;
        } 

        public static CardPlayedArgs Create(GameObject cardObject, Card card, int player) => new CardPlayedArgs(cardObject, card, player);
    }
}





        


