using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventMouseClick : MonoBehaviour
{
   [SerializeField] private UnityEvent OnMouseClickedEvent;

   private void Update()
   {
       if (Input.GetMouseButtonDown(0))
       {
           OnMouseClickedEvent.Invoke();
       }
      
   }
}
