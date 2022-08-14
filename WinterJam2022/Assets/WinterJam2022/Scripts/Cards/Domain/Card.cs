using WinterJam2022.Scripts.Presentation;
using WinterJam2022.Scripts.Verses.Domain;

public class Card
{
    public Word Word;
    public Effect Special;
    
    public Card(Word word)
    {
        Word = word;
        AssignSpecial();
    }

    void AssignSpecial()
    {
        var dice =ProbabilityHelper.Random.Next(100);
        if (ProbabilityHelper.IsBetween(0, 5, dice))
        {
            Special = Effect.DrawTwoExtra;
        }

        if (ProbabilityHelper.IsBetween(6, 15, dice))
        {
            Special = Effect.DrawOneExtra;
        }
        
        if (ProbabilityHelper.IsBetween(16, 25,dice))
        {
            Special = Effect.x2;
        }
        
        if (ProbabilityHelper.IsBetween(26, 30,dice))
        {
            Special = Effect.x3;
        }
    }

    public override string ToString() => $"{Word.Text} vale {Word.Points} puntos";
}
