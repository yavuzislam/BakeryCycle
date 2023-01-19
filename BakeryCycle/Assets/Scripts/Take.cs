using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;
using DG.Tweening;
using static UnityEditor.Progress;
using UnityEngine.UI;

public class Take : MonoBehaviour
{
    //public Image image;
    public GameObject bakeLeaven;
    float duration,takeDuration;
    public Vector3 stackpos;
    public GameObject stackParent, takeParent;
    public GameObject leaven, bakery;
    public stack stacks;
    public bool set, up;
    public PlayerControl player;
    private void Update()
    {
        if (up)
        {
            takeDuration += Time.deltaTime;
            if (takeDuration>1)
            {
                if (player.transform.GetChild(2).childCount != 0)
                {
                    player.transform.GetChild(2).GetChild(0).transform.parent = stackParent.transform;
                    stackParent.transform.GetChild(stackParent.transform.childCount - 1).transform.DOLocalMove(stackpos, 0.1f);
                    stacks.stackList.Clear();
                }
                else
                {
                    set = true;
                    up = false;
                }
            }            
        }
        
        if (set)
        {
            //image.fillAmount = duration;
            duration += Time.deltaTime / 2;
            if (duration > 1)
            {
                duration = 0;
                stackParent.transform.GetChild(0).tag = "bake";
                stackParent.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material=bakeLeaven.GetComponent<SkinnedMeshRenderer>().material;
                stackParent.transform.GetChild(0).transform.parent = takeParent.transform;
                takeParent.transform.GetChild(takeParent.transform.childCount - 1).DOLocalRotate(new Vector3(359.746277f, 92.1784592f, 359.892303f),0.01f);
                takeParent.transform.GetChild(takeParent.transform.childCount - 1).transform.localPosition= stackpos;
                stackpos += new Vector3(0f, 0.3f, 0f);
            }
            if (stackParent.transform.childCount == 0)
            {
                //duration = 0;
                //stackpos = Vector3.zero;
                set = false;
                duration = 0;
                //image.fillAmount = 0;
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.transform.GetChild(2).childCount!=0)
            {
                if (other.transform.GetChild(2).GetChild(0).tag=="bake")
                {
                    up = false;
                }
                else
                {
                    up= true;
                }
            }
            else
            {
                up = false;
            }
            takeDuration = 0;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="Player")
        {
            up = false;
            takeDuration = 0;
        }
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    if (stackParent.transform.childCount != 0)
    //    {
    //        set = true;
    //    }
    //    else
    //    {
    //        return;
    //    }
    //}
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        foreach (var item in stacks.stackList)
    //        {
    //            Destroy(item.gameObject);
    //        }
    //        stacks.stackList.Clear();
    //        InvokeRepeating("bake", 2f, 2f);
    //    }
    //}
    //public void bake()
    //{
    //    Debug.Log(stacks.stackList.Count);
    //    float z = -0.5f;
    //    GameObject bakeobje = Instantiate(leaven);
    //    bakeobje.transform.position = bakery.transform.position + new Vector3(0f, 0f, z);
    //    bakeobje.transform.rotation = Quaternion.Euler(bakeobje.transform.rotation.x, 5.733f, bakeobje.transform.rotation.z);
    //    bakeobje.transform.parent = bakery.transform;
    //    z -= 0.5f;
    //    //5.733
    //    stacks.stackList.Add(bakeobje);

    //    if (stacks.stackList.Count == 5)
    //    {
    //        CancelInvoke("bake");
    //        stacks.stackList.Clear();
    //    }
    //}
}
