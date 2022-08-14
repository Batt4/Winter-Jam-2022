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

        [SerializeField] int TIMEOUT_PENALTY = 8;
        
        private void Start() 
        {
            round = new Round(10, 20); // Mock Round
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

            UpdateRoundFollowers(cardWasOk? card.Word.Points: -card.Word.Points);
            Destroy(cardObject);
            PassTurn();
            Debug.Log($"Card played: {card}");
        }

        public void SetCurrentVerse(Verse verse)
        {
            CurrentVerse = verse;
            timerView.RestartTime(IsThePlayerRound());
            Debug.Log($"Current verse: {verse}");
        }

        public void Timeout() {
            if (IsThePlayerRound()) UpdateRoundFollowers(-TIMEOUT_PENALTY);
            PassTurn();
        }

        void PassTurn() {
            if (this.round.finished) {
                return;
            }

            round.PassTurn();
            GetNewCardFromDeck();
            if (IsThePlayerRound()) gameController.CreateVerse();
            if (!this.round.finished) {
                timerView.RestartTime(IsThePlayerRound());
            }
        }

        public void FinishRound()
        {
            this.round.currentPlayer = 0;
            this.round.finished = true;
            timerView.CloseTime();

            string winnerPlayer = this.round.player1Followers < this.round.totalFollowers / 2? "ENEMY": "PLAYER";
            Debug.Log($"Finishing round. {winnerPlayer} is the Winner!");
        }

        void GetNewCardFromDeck() {
            if (round.currentPlayer == 1) Instantiate(cardViewTemplate, cardsContainer);
        }

        void UpdateRoundFollowers(int points) {
            round.UpdateFollowers(points);
            followersView.UpdateFollowers(round.player1Followers, round.totalFollowers);
            bool winLoseCondition = round.player1Followers <= 0 || round.player1Followers >= round.totalFollowers;
            if (winLoseCondition) {
                FinishRound();
            }
        }

        bool IsThePlayerRound() {
            return this.round == null || this.round.currentPlayer == 1;
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





        


