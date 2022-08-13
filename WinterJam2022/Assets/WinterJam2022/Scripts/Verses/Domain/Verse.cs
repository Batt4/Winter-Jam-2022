using System;
using TMPro;
using UnityEngine;
using WinterJam2022.Scripts.Presentation;

namespace WinterJam2022.Scripts.Verses.Domain
{
    public class Verse : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI text;
        
        WordType wordType;

        
        void OnEnable()
        {
            RandomizeText();
        }

        void RandomizeText()
        {
            text.text = $"{DateTime.Now.Millisecond} this is a random VERB, believe me....";
            wordType = WordType.VERB;
        } 

        public bool VerifyWord(Word word)
        {
            var result = word.Type == wordType;
            Debug.Log(result ? "THE WORD IS CORRECT" : "THE WORD IS WRONG");
            return result;
        }
    }
}
