using System.Collections.Generic;
using TMPro;
using UnityEngine;
using WinterJam2022.Scripts.Verses.Domain;

namespace WinterJam2022.Scripts.Presentation
{
    public class NameGenerator : MonoBehaviour
    {
        [SerializeField] 
        TextMeshProUGUI opponentName;

        readonly List<string> availableNames = new List<string>()
        {
            "Lanza Stanza",
            "Hudson Judson",
            "AitchYouDeeEssOhEn",
            "Homer Sarcoma",
            "Ol Hudson",
            "Homer Homer Hoo",
            "Adam Madame",
            "Tots-Adam",
            "Sapper Simpson",
            "AyAreDeeAyElAy",
            "Simpson Simpson Soo",
            "Kindness Adam",
            "Ardalastic A H",
            "Big Alex",
            "Homer Misnomer",
            "Tots-Wide",
            "A.H. Lanza",
            "Lanza Bonanza",
            "Abs-Wide",
            "Kindness Lanza",
            "Alex Lanza",
            "Ardalormous H",
            "Happer Homer",
            "Ardala-H",
            "Da Real Ardala",
            "Hud$on",
            "Alex Adam",
            "Wideman",
            "Widedoc",
            "Lanza Extravaganza",
            "CooloHudson",
            "AyAitch",
            "Adam Madam",
            "Ardalulous H",
            "Ardala Ardala H.",
            "Tots-Lanza",
            "Inspectah Wide",
            "Wideface Ardala",
            "A.H. Adam",
            "Ardaladonna",
            "TeeTee",
            "Teresastic T T",
            "Thomp$on",
            "Big Rocky",
            "Teresa Lisa",
            "Teresa Mesa",
            "Ted Read",
            "T.T. Kaczynski",
            "Rocky Ted",
            "Scully Sully",
            "Ol Thompson",
            "Tere$a",
            "Thompson Thomson",
            "Scapper Scully",
            "Teresa Teresa T.",
            "TeeEeAreEeEssAy",
            "Funnyman",
            "Tots-Kaczynski",
            "Inspectah Funny",
            "Dapper Dana",
            "Teresormous T",
            "Ted Lead",
            "Dana Irena",
            "Scully Scully Scoo",
            "Funnydoc",
            "Dana Elena",
            "Dana Dana Doo",
            "Scully Gully",
            "Teresulous T",
            "Kaczynski Stravinsky",
            "Lead Ted",
            "Abs-Funny",
            "TeeAitchOhEmPeeEssOhEn",
            "Tots-Funny",
            "Teresadonna",
            "Teresa-T",
            "T.T. Ted",
            "Rocky Kaczynski",
            "Funnyface Teresa",
            "Da Real Teresa",
            "Tots-Ted",
            "CooloThompson",
            "Cotton Ted",
            "Cotton Kaczynski",
        };

        void OnEnable()
        {
            opponentName.text = availableNames.PickOne();
        }
        
    }
}