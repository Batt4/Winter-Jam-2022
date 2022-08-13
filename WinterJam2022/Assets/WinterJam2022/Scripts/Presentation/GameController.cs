using System;
using UnityEngine;
using WinterJam2022.Scripts.Verses.Domain;

namespace WinterJam2022.Scripts.Presentation
{
    public class GameController : MonoBehaviour
    {

        [SerializeField] RectTransform panel;
        [SerializeField] GameObject versePrefab;

        [SerializeField] EventManager eventManager;
        
        void OnEnable()
        {
            CreateVerse();
        }

        void CreateVerse()
        { 
           var newVerse = Instantiate(versePrefab, panel);
           var verse = newVerse.GetComponent<Verse>();
           
           eventManager.SetCurrentVerse(verse);
         
        }
    }

    
}