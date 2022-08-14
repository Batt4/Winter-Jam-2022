using System;
using UnityEngine;

namespace WinterJam2022.Scripts.Presentation
{
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