using UnityEngine;
using WinterJam2022.Scripts.Verses.Domain;

namespace WinterJam2022.Scripts.Presentation
{
    public class GameController : MonoBehaviour
    {

        [SerializeField] RectTransform panel;
        [SerializeField] GameObject versePrefab;
        
        void OnEnable()
        {
            CreateVerse();
        }

        void CreateVerse()
        { 
           var newVerse = Instantiate(versePrefab, panel);
           var verse = newVerse.GetComponent<Verse>();

           verse.VerifyWord(new Word(WordType.SUBJECT));
           verse.VerifyWord(new Word(WordType.ADJECTIVE));
           verse.VerifyWord(new Word(WordType.VERB));
        }
    }
}