using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SnowmanClickText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _clickCounter;
    private float count;
    private void Start()
    {
        _clickCounter.color = Color.black;
        _clickCounter.fontSize = 44;
    }

    
     public void setCount (float value)
     {
         count += value;
         _clickCounter.text = count.ToString();
     }

   
}
