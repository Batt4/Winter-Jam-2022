using System;
using TMPro;
using UnityEngine;
using WinterJam2022.Scripts.Verses.Domain;

namespace WinterJam2022.Scripts.Presentation
{
    public class GameController : MonoBehaviour
    {

        [SerializeField] RectTransform panel;

        [SerializeField] GameObject versePrefab;

        [SerializeField] TextMeshProUGUI versesText;

        [SerializeField] EventManager eventManager;

        int currentVerse;
        [SerializeField] int totalVerses = 6;
        
        void Start()
        {
            CreateVerse();
        }

        public void CreateVerse()
        {
            Debug.Log($"Verses: {currentVerse}/{totalVerses}.");
            
            if (currentVerse >= totalVerses) {
                eventManager.FinishRound();
                return;
            }

            currentVerse++;
            var newVerse = Instantiate(versePrefab, panel);
            var verse = newVerse.GetComponent<Verse>();
           
            eventManager.SetCurrentVerse(verse);

            versesText.text = $"Verses: {currentVerse}/{totalVerses}";
        }
    }

    
}