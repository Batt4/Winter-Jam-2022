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

        List<Word> availableWords;
        
        event EventHandler OnCardPlayed;

        Card card;
        
        void Start()
        {
            availableWords = new List<Word>
            {
                new Word(WordType.VERB, "Correr", Random.Range(1, 15)),
                new Word(WordType.VERB, "Comer", Random.Range(1, 15)),
                new Word(WordType.VERB, "Dormir", Random.Range(1, 15)),
                new Word(WordType.SUBJECT, "Casa", Random.Range(1, 15)),
                new Word(WordType.SUBJECT, "Perro", Random.Range(1, 15)),
                new Word(WordType.SUBJECT, "Botella", Random.Range(1, 15)),
                new Word(WordType.ADJECTIVE, "Feo", Random.Range(1, 15)),
                new Word(WordType.ADJECTIVE, "Roto", Random.Range(1, 15)),
                new Word(WordType.ADJECTIVE, "Aburrido", Random.Range(1, 15)),
                new Word(WordType.ADJECTIVE, "Hermoso", Random.Range(1, 15))
            };
            
            card = GetCardFromDeck();
            text.text = card.Word.Text;
            points.text = card.Word.Points.ToString();
        }

        Card GetCardFromDeck()
        {
            var word = availableWords[Random.Range(0, availableWords.Count)];
            return new Card(word);
        }

        void OnEnable() => OnCardPlayed += eventManager.PlayCard;

        void OnDestroy() => OnCardPlayed -= eventManager.PlayCard;

        public void SelectCard()
        {
            OnCardPlayed?.Invoke(this, CardPlayedArgs.Create(card));
            Destroy(gameObject);
        }
    }
}