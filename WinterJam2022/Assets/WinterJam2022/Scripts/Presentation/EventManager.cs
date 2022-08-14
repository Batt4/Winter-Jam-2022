using System;
using UnityEngine;
using UnityEngine.UI;
using WinterJam2022.Scripts.Verses.Domain;

namespace WinterJam2022.Scripts.Presentation
{
    public class EventManager : MonoBehaviour
    {

        Verse currentVerse;
        Round round;
        [SerializeField] GameController gameController;
        [SerializeField] FollowersView followersView;
        [SerializeField] TimerView timerView;
        [SerializeField] RectTransform cardsContainer;
        [SerializeField] GameObject cardViewTemplate;

        [SerializeField] int TIMEOUT_PENALTY = 8;
        
        void Start() 
        {
            round = new Round(10, 20); // Mock Round
        }

        public void PlayCard(object sender, EventArgs args)
        {
            var playedCard = (CardPlayedArgs)args;
            var currentPlayer = playedCard.Player;
           
            if (CantPlayCard(currentPlayer)) {
                Debug.LogWarning("Card wasn't able to be played yet.");
                return;
            }
            var card = playedCard.Card;
            var cardGameObject = playedCard.CardObject;

            var scoreMultiplier = HandleSpecialCards(card);
            
            if (currentVerse.VerifyWord(card.Word))
            {
                UpdateRoundFollowers(card.Word.Points * scoreMultiplier);
            }
            else
            {
                UpdateRoundFollowers(-card.Word.Points * scoreMultiplier);
            }

            Destroy(cardGameObject);
            PassTurn();
            
            Debug.Log($"Card played: {card}");
        }

        int HandleSpecialCards(Card card)
        {
            switch (card.Special)
            {
                case Effect.None:
                    break;
                case Effect.x2:
                    return 2;
                case Effect.x3:
                    return 3;
                case Effect.DrawOneExtra:
                    GetNewCardFromDeck();
                    break;
                case Effect.DrawTwoExtra:
                    GetNewCardFromDeck();
                    GetNewCardFromDeck();
                    break;
                
            }

            return 1;
        }

        bool CantPlayCard(int playerThatPlayedTheCard)
        {
            return currentVerse == null || round.currentPlayer != playerThatPlayedTheCard;
        }

        public void SetCurrentVerse(Verse verse)
        {
            currentVerse = verse;
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
            if (IsThePlayerRound()) 
                gameController.CreateVerse();
            
            if (!round.finished) 
            {
                timerView.RestartTime(IsThePlayerRound());
            }
        }

        public void FinishRound()
        {
            this.round.currentPlayer = 0;
            this.round.finished = true;
            timerView.CloseTime();

            string winnerPlayer = this.round.player1Followers < this.round.totalFollowers / 2 ? "ENEMY": "PLAYER";
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
        public readonly GameObject CardObject;
        public readonly Card Card;
        public readonly int Player;

        CardPlayedArgs(GameObject cardObject, Card card, int player) {
            CardObject = cardObject;
            Card = card;
            Player = player;
        } 

        public static CardPlayedArgs Create(GameObject cardObject, Card card, int player) => new CardPlayedArgs(cardObject, card, player);
    }
}





        


