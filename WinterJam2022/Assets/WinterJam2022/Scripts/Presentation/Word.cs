namespace WinterJam2022.Scripts.Presentation
{
    public class Word
    {
        public readonly WordType Type;
        public readonly string Text;
        public readonly int Points;
        

        public Word(WordType type, string text, int points)
        {
            Type = type;
            Text = text;
            Points = points;
        }
    }
}