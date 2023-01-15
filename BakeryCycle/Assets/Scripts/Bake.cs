using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bake : MonoBehaviour
{
    public PlayerControl playerControl;
    public GameObject bake_leaven;
    public stack stacks;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            InvokeRepeating("TakeLeaven", 1f, 1f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            CancelInvoke("TakeLeaven");
        }
    }
    public void TakeLeaven()
    {
        GameObject takeobje = Instantiate(bake_leaven, playerControl.transform);
        takeobje.transform.localPosition = new Vector3(0f, 1f, 1f) + new Vector3(0f, 0.1f * stacks.stackList.Count, 0f);
        takeobje.transform.localRotation = Quaternion.Euler(takeobje.transform.localRotation.x, 6f, takeobje.transform.localRotation.z);
        stacks.stackList.Add(takeobje);

        if (stacks.stackList.Count == 5)
        {
            CancelInvoke("TakeLeaven");
        }
    }
}
