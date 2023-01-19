using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bake : MonoBehaviour
{
    public Vector3 pos;
    public GameObject stackParent,takeParent;
    public Take take;
    public stack stacks;
    bool set;
    int count, stackCount;
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            stackCount = stackParent.transform.childCount;
            if (stackParent.transform.childCount != 0)
            {
                for (int i = 0; i < stackCount; i++)
                {
                    if (stackParent.transform.GetChild(i).tag != "bake")
                    {
                        set = false;
                    }
                    else
                    {
                        set = true;
                    }
                }
            }
            else
            {
                set = true;
            }
            
            if (set)
            {
                count = takeParent.transform.childCount;
                for (int i = 0; i < count; i++)
                {
                    takeParent.transform.GetChild(0).transform.parent = stackParent.transform;
                    stackParent.transform.GetChild(stackParent.transform.childCount - 1).DOLocalMove(pos, 0.05f);
                    pos += new Vector3(0f, 0.1f, 0f);
                }
                take.stackpos = Vector3.zero;
            }            
        }
    }
}
