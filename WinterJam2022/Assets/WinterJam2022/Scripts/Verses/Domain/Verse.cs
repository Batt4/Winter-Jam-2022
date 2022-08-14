using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WinterJam2022.Scripts.Presentation;

namespace WinterJam2022.Scripts.Verses.Domain
{
    public class Verse : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI text;
        
        WordType wordType;

        [SerializeField] Color puntajePositivoColor;
        [SerializeField] Color puntajeNegativoColor;
        [SerializeField] TMPro.TextMeshProUGUI displayPuntaje;
        [SerializeField] TMPro.TextMeshProUGUI displayPuntajeSombra;
        [SerializeField] RawImage overlay;
        [SerializeField] Color verbColor;
        [SerializeField] Color subjectColor;
        [SerializeField] Color adjectiveColor;

        
        void OnEnable()
        {
            RandomizeText();
        }

        void RandomizeText()
        {
            VerseContent newVerse = VerseGenerator.GetVerse();
            text.text = newVerse.Text.Replace("%", "......");
            wordType = newVerse.RequiredWord;
            if (wordType.Equals(WordType.VERB)) {
                overlay.color = verbColor;
            }
            if (wordType.Equals(WordType.SUBJECT)) {
                overlay.color = subjectColor;
            }
            if (wordType.Equals(WordType.ADJECTIVE)) {
                overlay.color = adjectiveColor;
            }
        } 

        public bool VerifyWord(Word word)
        {
            var result = word.Type == wordType;
            Debug.Log(result ? "THE WORD IS CORRECT" : "THE WORD IS WRONG");
            return result;
        }

        public void ShowPoints(int puntaje) {
            if (puntaje >= 0) {
                displayPuntaje.color = puntajePositivoColor;
                displayPuntaje.text = "+" + puntaje.ToString();
                displayPuntajeSombra.text = "+" + puntaje.ToString();
            } else {
                displayPuntaje.color = puntajeNegativoColor;
                displayPuntaje.text = puntaje.ToString();
                displayPuntajeSombra.text = puntaje.ToString();
            }
        }

        public void UpdateHiddenText(string word) {
            text.text = text.text.Replace("......", word.ToLower());
        }
    }
}
