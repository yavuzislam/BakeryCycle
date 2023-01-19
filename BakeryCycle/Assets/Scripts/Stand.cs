using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Stand : MonoBehaviour
{
    public stack stack;
    int index = 0, count = 1, customer = 2;
    public bool set, active, newpos, takestand;
    float duration;
    public GameObject stackparent;
    public Transform standPos;
    public List<Vector3> targetpos;
    public Vector3 pos, customerParent;
    public List<GameObject> customers;
    private void Update()
    {
        if (active)
        {
            if (index == 0)
            {                        //3
                for (int i = 0; i < customers.Count; i++)
                {
                    Debug.Log(i);
                    targetpos.Add(customers[i].transform.localPosition);
                    Debug.Log(targetpos[i]);
                }
                active = false;
            }
            else
            {
                for (int i = count; i < customers.Count; i++)
                {
                    targetpos.Add(customers[i].transform.localPosition);
                }
                active = false;
            }
        }
        if (newpos)
        {
            Debug.Log("index" + index);
            if (index == 0)
            {
                for (int i = 1; i < customers.Count; i++)
                {Debug.Log("girdi");
                    customers[i].transform.DOLocalMove(targetpos[i - 1], 1f);
                }
                index++;
                newpos = false;
            }
            else
            {
                for (int i = count + 1; i < customers.Count; i++)
                {
                    customers[i].transform.DOLocalMove(targetpos[i - customer], 1f);
                }
                customer++;
                index++;
                count++;
                newpos = false;
            }

        }

        if (set)
        {
            duration += Time.deltaTime / 2;
            if (duration > 1)
            {
                duration = 0;
                if (index == 0)
                {
                    active = true;
                    standPos.GetChild(0).parent = customers[index].transform.GetChild(2);
                    customers[index].transform.GetChild(2).GetChild(0).DOLocalMove(customerParent, 0.1f);
                    newpos = true;
                    customers[0].transform.DOLocalMove(customerParent, 20f);                   
                    targetpos.Clear();

                }
                else
                {
                    active = true;
                    if (standPos.childCount != 0)
                    {
                        standPos.GetChild(0).parent = customers[index].transform.GetChild(2);
                        customers[index].transform.GetChild(2).GetChild(0).DOLocalMove(customerParent, 0.1f);
                        newpos = true;
                        customers[index].transform.DOLocalMove(customerParent, 20f);
                        
                        targetpos.Clear();
                    }
                    else
                    {
                        set = false;
                        stack.stackList.Clear();
                        pos = Vector3.zero;
                    }

                }

            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (stackparent.transform.childCount!=0)
            {
                for (int i = 0; i < stackparent.transform.childCount; i++)
                {
                    if (stackparent.transform.GetChild(i).tag=="bake")
                    {
                        takestand = true;
                    }
                }
            }
            if (takestand)
            {
                int count = stackparent.transform.childCount;
                for (int i = 0; i < count; i++)
                {
                    stackparent.transform.GetChild(0).parent = standPos;
                    standPos.GetChild(standPos.childCount - 1).transform.DOLocalMove(pos, 0.5f);
                    pos += new Vector3(0f, 0f, 0.01f);
                }
                if (standPos.childCount != 0)
                {
                    set = true;
                }
            }
            
        }
    }
}
