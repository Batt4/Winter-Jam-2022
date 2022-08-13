using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WinterJam2022.Scripts.Presentation;

public class Card
{

    public WordType Type;
    public Word Word;
    

    public Card(Word word) => Word = word;
  
    public override string ToString() => $"{Word.Text} vale {Word.Points} puntos";
}
