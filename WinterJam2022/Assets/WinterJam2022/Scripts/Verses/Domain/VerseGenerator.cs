using System;
using System.Collections.Generic;

namespace WinterJam2022.Scripts.Verses.Domain
{
    public class VerseGenerator
    {
        readonly List<VerseContent> verses = new List<VerseContent>()
        {
            new VerseContent("Creo que les va a gustar esta %", WordType.SUBJECT),
            new VerseContent("Quiero que % cuando suene esta canción ", WordType.VERB),
            new VerseContent("Mi % los va a a enloquecer", WordType.SUBJECT),
            new VerseContent("Quisieron % esta canción", WordType.VERB),
            new VerseContent("No quieren jugar con mi %", WordType.SUBJECT),
            new VerseContent("Pero te gusta comer todo el día, %", WordType.ADJECTIVE),
            new VerseContent("Quién te % a vos?", WordType.VERB),
            new VerseContent("Vengo de la costa % para vos", WordType.ADJECTIVE),
            new VerseContent("Te crees la gran cosa pero sos %", WordType.ADJECTIVE),
            new VerseContent("Les damos a los malitos para que no sean %", WordType.ADJECTIVE),
            new VerseContent("Mira como te % la cabeza", WordType.VERB),
            new VerseContent("Seguimos llegando, aplastando %", WordType.SUBJECT),
            new VerseContent("Siempre suelto listo para % ", WordType.VERB),
            new VerseContent("Eso pasa por % mira como quedaste", WordType.ADJECTIVE),
            new VerseContent("Hechos picadillo, pedacitos, así quedó tu %", WordType.SUBJECT)
        };

        public VerseContent GetVerse() => verses.PickOne();
    }

    public class VerseContent
    {
        public readonly string Text;
        public readonly WordType RequiredWord;

        public VerseContent(string text, WordType requiredWord)
        {
            Text = text;
            RequiredWord = requiredWord;
        }
    }

    public static class ListExtensions
    {
        static readonly Random random = new Random();
        
        public static T PickOne<T>(this List<T> source) => source[random.Next(source.Count)];
    } 
}