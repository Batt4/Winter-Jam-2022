using System.Collections.Generic;

namespace WinterJam2022.Scripts.Verses.Domain
{
    public static class VerseGenerator
    {
        static readonly List<VerseContent> verses = new List<VerseContent>()
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
            new VerseContent("Eso pasa por % mira como quedaste", WordType.VERB),
            new VerseContent("Hechos picadillo, pedacitos, así quedó tu %", WordType.SUBJECT)

            new VerseContent("Si el % no me alcanza", WordType.SUBJECT),
            new VerseContent("Me va a sobar la %", WordType.SUBJECT),
            new VerseContent("Me va a sobrar la %", WordType.ADJECTIVE),
            new VerseContent("El % no interesa", WordType.SUBJECT),
            new VerseContent("Cuando en el medio està el %", WordType.SUBJECT),
            new VerseContent("La diferencia es que yo también % bastante", WordType.VERB),
            new VerseContent("Esa es la diferencia entre mi % y el tuyo", WordType.SUBJECT),
            new VerseContent("Lo normal es que yo te %", WordType.VERB),
            new VerseContent("Es mas fuerte mas %", WordType.ADJECTIVE),
            new VerseContent("Nunca ha batallado antes pero sí sabe %", WordType.VERB),
            new VerseContent("Tú no tienes el nivel para llegar a ser %", WordType.SUBJECT),
            new VerseContent("Yo te ví, estabas en una esquina % en el camarín", WordType.VERB),
            new VerseContent("Si hablas de reciclar mejor que recicles tu %", WordType.VERB),
            new VerseContent("Eso no encaja, desde cuando ser % se volvió una ventaja", WordType.SUBJECT),
            new VerseContent("El rap que yo hago no está hecho para %", WordType.SUBJECT),
            new VerseContent("El nuevito tiene ganas de %", WordType.VERB),
            new VerseContent("Y si tú sigues % de esa forma tan fatal", WordType.VERB),
            new VerseContent("% sin trayectoria no cumple expectativas", WordType.VERB),
            new VerseContent("Me voy a % en tu falso campeonato", WordType.VERB),
            new VerseContent("Tanto me quería arriba de la %", WordType.SUBJECT),
            new VerseContent("Hoy vengo a % y saben que lo maltrato", WordType.VERB),
            new VerseContent("Tanto me quería porque se % la rima", WordType.VERB),

        };

        public static VerseContent GetVerse() => verses.PickOne();
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
}