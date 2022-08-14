using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace WinterJam2022.Scripts.Presentation
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] EventManager eventManager;
        [SerializeField] TextMeshProUGUI text;
        [SerializeField] TextMeshProUGUI points;
        [SerializeField] TextMeshProUGUI special;

        List<Word> availableWords;
        
        event EventHandler OnCardPlayed;

        Card card;
        
        void Start()
        {
            availableWords = new List<Word>
            {
                new Word(WordType.VERB, "Correr", Random.Range(1, 15),"er"),
                new Word(WordType.VERB, "Comer", Random.Range(1, 15),"er"),
                new Word(WordType.VERB, "Dormir", Random.Range(1, 15),"ir"),
                new Word(WordType.SUBJECT, "Casa", Random.Range(1, 15),"sa"),
                new Word(WordType.SUBJECT, "Perro", Random.Range(1, 15),"rro"),
                new Word(WordType.SUBJECT, "Botella", Random.Range(1, 15),"lla"),
                new Word(WordType.ADJECTIVE, "Feo", Random.Range(1, 15),"o"),
                new Word(WordType.ADJECTIVE, "Roto", Random.Range(1, 15),"to"),
                new Word(WordType.ADJECTIVE, "Aburrido", Random.Range(1, 15),"do"),
                new Word(WordType.ADJECTIVE, "Hermoso", Random.Range(1, 15),"so")
            };
            
            card = GetCardFromDeck();
            text.text = card.Word.Text;
            points.text = card.Word.Points.ToString();
            special.text = SpecialToString(card.Special);
        }

        string SpecialToString(Effect cardSpecial)
        {
            switch (cardSpecial)
            {
                case Effect.None:
                    return "";
                case Effect.x2:
                    return "X2";
                case Effect.x3:
                    return "X3";
                case Effect.DrawOneExtra:
                    return "+1 Xtra";
                case Effect.DrawTwoExtra:
                    return "+2 Xtra";
            }
            return "";
        }

        Card GetCardFromDeck()
        {
            var word = availableWords[Random.Range(0, availableWords.Count)];
            return new Card(word);
        }
        void OnEnable() {
            eventManager = FindObjectOfType<EventManager>();
            OnCardPlayed += eventManager.PlayCard;
        }

        void OnDestroy() => OnCardPlayed -= eventManager.PlayCard;

        public void SelectCard()
        {
            int PLAYER_ID = 1;
            OnCardPlayed?.Invoke(this, CardPlayedArgs.Create(gameObject, card, PLAYER_ID));
        }
    }
}