using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stack : MonoBehaviour
{
    public PlayerControl playerControl;
    public List<GameObject> stackList;
    public GameObject leaven;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            InvokeRepeating("StackLeaven", 1f, 1f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="Player")
        {
            CancelInvoke("StackLeaven");
        }
    }
    public void StackLeaven()
    {
        GameObject obje = Instantiate(leaven, playerControl.transform);
        obje.transform.localPosition = new Vector3(0f, 1f, 1f)+new Vector3(0f,0.1f*stackList.Count,0f);
        stackList.Add(obje);

        if (stackList.Count == 5)
        {
            CancelInvoke("StackLeaven");
        }
    }
}
