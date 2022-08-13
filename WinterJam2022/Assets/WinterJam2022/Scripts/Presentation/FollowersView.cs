using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowersView : MonoBehaviour
{

    [SerializeField]
    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        this.slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateFollowers(int player1Followers, int totalFollowers) 
    {
        float newSliderValue = (float) player1Followers / totalFollowers;
        slider.value = newSliderValue;
    }

}
