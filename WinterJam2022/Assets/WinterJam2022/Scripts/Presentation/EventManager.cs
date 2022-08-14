using System;
using UnityEngine;
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
        [SerializeField] ScreenController screenController;
        [SerializeField] RoundsController roundsController;

        [SerializeField] int TIMEOUT_PENALTY = 8;

        Word lastCorrectWord = new Word(WordType.VERB, "",0,"");

        [SerializeField] Color puntajePositivoColor;
        [SerializeField] Color puntajeNegativoColor;


        void Start() 
        {
        }

        void Update() {
            if (Input.GetKey(KeyCode.Escape)) {
                Debug.Log("Paused game");
                screenController.PauseGame();
            }
        }

        public void NewRoundInformation(Round round) {
            this.round = round;
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
                var rhymeScore = 0;
                scoreMultiplier += round.GetCurrentCombo();

                if (lastCorrectWord.RhymesWith(card.Word))
                {
                    Debug.Log("THE WORDS RHYME");
                    rhymeScore = 15;
                }
                 
                UpdateRoundFollowers(rhymeScore + card.Word.Points * scoreMultiplier);
                round.AddToCombo();
                lastCorrectWord = card.Word;

                /////////////////
                TMPro.TextMeshProUGUI displayPuntaje = currentVerse.gameObject.GetComponentsInChildren<TMPro.TextMeshProUGUI>()[1];
                TMPro.TextMeshProUGUI displayPuntajeSombra = currentVerse.gameObject.GetComponentsInChildren<TMPro.TextMeshProUGUI>()[2];
                var puntaje = rhymeScore + card.Word.Points * scoreMultiplier;
                if ((rhymeScore + card.Word.Points * scoreMultiplier) > 0)
                {
                    displayPuntaje.color = puntajePositivoColor;
                    displayPuntaje.text = "+" + puntaje.ToString();
                    displayPuntajeSombra.text = "+" + puntaje.ToString();
                }
                else
                {
                    displayPuntaje.color = puntajeNegativoColor;
                    displayPuntaje.text = "-" + puntaje.ToString();
                    displayPuntajeSombra.text = "-" + puntaje.ToString();
                }
                /////////////////


            }
            else
            {
                lastCorrectWord = new Word(WordType.VERB, "",0,"");
                UpdateRoundFollowers(-card.Word.Points * scoreMultiplier);
                round.ResetCombo();
            }

            Destroy(cardGameObject);
            PassTurn();
            
            Debug.Log($"Card played: {card}");
        }

        double HandleSpecialCards(Card card)
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

            bool isThePlayerTheWinner = this.round.player1Followers >= this.round.totalFollowers / 2;
            string winnerPlayer = isThePlayerTheWinner ? "PLAYER": "ENEMY";
            Debug.Log($"Finishing round. {winnerPlayer} is the Winner!");
            
            if (isThePlayerTheWinner) {
                roundsController.NextLevel();
                screenController.WinScreen();
            }
            else {
                roundsController.ResetLevels();
                screenController.LoseScreen();
            }
        }

        public void GetNewCardsFromDeck(int quantityOfCards)
        {
            for (int i = 0; i < quantityOfCards; i++) {
                GetNewCardFromDeck();
            }
        }

        public void ThrowCards()
        {
            foreach (Transform child in cardsContainer.transform) {
                GameObject.Destroy(child.gameObject);
            }
        }


        void GetNewCardFromDeck() {
            if (round.currentPlayer == 1) Instantiate(cardViewTemplate, cardsContainer);
        }

        void UpdateRoundFollowers(double points) => UpdateRoundFollowers(Convert.ToInt32(points));

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
}





        


