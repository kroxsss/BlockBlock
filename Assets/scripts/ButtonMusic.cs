using System;
using UnityEngine;

public class ButtonMusic : MonoBehaviour
{
    public GameObject slider;
    private bool slideron = false;

    public void Start()
    {
        slider.SetActive(false);
        slideron = false;
        
    }

    public void SliderOpen()
    {
        if (slideron==false)
        {
            slider.SetActive(true);
            slideron = true;
        }
        else
        {
            slider.SetActive(false);
            slideron = false;
        }
    }

    public void SliderClose()
    {
        slider.SetActive(false);
        slideron = false;
        
    }
    
}
