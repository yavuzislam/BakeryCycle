using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bake : MonoBehaviour
{
    public Vector3 pos;
    public GameObject stackParent,takeParent;
    //public GameObject bake_leaven;
    public stack stacks;
    int count;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            count = stackParent.transform.childCount;
            if (count!=stacks.stackList.Count)
            {
                takeParent.transform.GetChild(0).transform.parent = stackParent.transform;
                stackParent.transform.GetChild(stackParent.transform.childCount - 1).DOLocalMove(pos, 0.5f);
                pos += new Vector3(0f, 0.1f, 0f);
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        count = stacks.stackList.Count;
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        InvokeRepeating("TakeLeaven", 1f, 1f);
    //    }
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        CancelInvoke("TakeLeaven");
    //    }
    //}
    //public void TakeLeaven()
    //{
    //    GameObject takeobje = Instantiate(bake_leaven, playerControl.transform);
    //    takeobje.transform.localPosition = new Vector3(0f, 1f, 1f) + new Vector3(0f, 0.1f * stacks.stackList.Count, 0f);
    //    takeobje.transform.localRotation = Quaternion.Euler(takeobje.transform.localRotation.x, 6f, takeobje.transform.localRotation.z);
    //    stacks.stackList.Add(takeobje);

    //    if (stacks.stackList.Count == 5)
    //    {
    //        CancelInvoke("TakeLeaven");
    //    }
    //}
}
