namespace WinterJam2022.Scripts.Presentation
{
    public class Word
    {
        public readonly WordType Type;
        public readonly string Text;
        public readonly int Points;
        readonly string rhyme;
        

        public Word(WordType type, string text, int points, string rhyme)
        {
            Type = type;
            Text = text;
            Points = points;
            this.rhyme = rhyme;
        }

        public bool RhymesWith(Word other) => other.rhyme.ToLower() == rhyme.ToLower();
    }
}