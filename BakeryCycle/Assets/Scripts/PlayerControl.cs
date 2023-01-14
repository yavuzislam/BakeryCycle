using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PlayerControl : MonoBehaviour
{
    public UI_Control control;
    public PathCreator creator;
    public float moveSpeed;
    float distanceTravelled;
    private void Update()
    {
        if (control.gameStart)
        {
            distanceTravelled += moveSpeed * Time.deltaTime;
            transform.position = creator.path.GetPointAtDistance(distanceTravelled);
            transform.rotation = creator.path.GetRotationAtDistance(distanceTravelled);
        }
            
        
    }
}
