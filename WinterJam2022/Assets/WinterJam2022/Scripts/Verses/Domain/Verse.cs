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
            VerseContent newVerse = VerseGenerator.GetVerse();
            text.text = newVerse.Text.Replace("%", "......");
            wordType = newVerse.RequiredWord;
        } 

        public bool VerifyWord(Word word)
        {
            var result = word.Type == wordType;
            Debug.Log(result ? "THE WORD IS CORRECT" : "THE WORD IS WRONG");
            return result;
        }
    }
}
