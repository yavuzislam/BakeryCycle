using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Control : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public bool gameStart = false;
    public float smoothx = 0.02f;

    public void OnPointerDown(PointerEventData eventData)
    {
        gameStart = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        gameStart = false;
    }
}
