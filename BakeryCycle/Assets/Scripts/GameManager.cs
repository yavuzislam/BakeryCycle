using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform[] leaven_machine;
    private void Update()
    {
        leaven_machine[0].Rotate(0f, 0f, 1f);
        leaven_machine[1].Rotate(0f, 0f, 0.5f);
    }
}
