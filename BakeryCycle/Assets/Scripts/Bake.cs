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
            int count = takeParent.transform.childCount;
            for (int i = 0; i < count; i++)
            {
                takeParent.transform.GetChild(0).transform.parent = stackParent.transform;
                stackParent.transform.GetChild(stackParent.transform.childCount - 1).DOLocalMove(pos, 0.5f);
                pos += new Vector3(0f, 0.1f, 0f);
            }
            
        }
    }
}
