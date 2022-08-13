using System;
using UnityEngine;
using WinterJam2022.Scripts.Verses.Domain;

namespace WinterJam2022.Scripts.Presentation
{
    public class EventManager : MonoBehaviour
    {

        Verse CurrentVerse;
        
        public void PlayCard(object sender, EventArgs args)
        {
            var card = ((CardPlayedArgs)args).Card;
            
            if(CurrentVerse != null)
                CurrentVerse.VerifyWord(card.Word);
            
            Debug.Log($"Card played: {card}");
        }

        public void SetCurrentVerse(Verse verse)
        {
            CurrentVerse = verse;
            Debug.Log($"Current verse: {verse}");
        }
    }
    
    public class CardPlayedArgs : EventArgs
    {
        public readonly Card Card;

        CardPlayedArgs(Card card) => Card = card;

        public static CardPlayedArgs Create(Card card) => new CardPlayedArgs(card);
    }
    
    
    public class OnVerseCreatedArgs : EventArgs
    {
        public readonly Verse Verse;
        
        OnVerseCreatedArgs(Verse verse) => Verse = verse;

        public static OnVerseCreatedArgs Create(Verse verse) => new OnVerseCreatedArgs(verse);
    }
}





        


