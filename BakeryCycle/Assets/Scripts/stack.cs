using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class stack : MonoBehaviour
{
    public GameObject stackparent;
    public Vector3 stackpos;
    public Transform machin;
    float duration;
    public PlayerControl playerControl;
    public List<GameObject> stackList;
    public GameObject leaven;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (stackList.Count < 5)
            {
                duration += Time.deltaTime;
                if (duration > 1)
                {
                    duration = 0;
                    stackList.Add(leaven);
                    GameObject obje = Instantiate(leaven, machin);
                    obje.transform.parent = stackparent.transform;
                    obje.transform.DOLocalMove(stackpos, 0.5f);
                    stackpos += new Vector3(0f, 0.1f, 0f);
                    Debug.Log("çalýþtý");
                }
            }
            if (stackList.Count==5)
            {
                duration = 0;
                stackpos = Vector3.zero;
            }
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        InvokeRepeating("StackLeaven", 1f, 1f);
    //    }
    //}
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            duration = 0;
            stackpos = Vector3.zero;
            Debug.Log("cýkýldý");
        }
            
    }
    //public void StackLeaven()
    //{
    //    GameObject obje = Instantiate(leaven, playerControl.transform);
    //    obje.transform.parent = GameObject.Find("stack").transform;
    //    obje.transform.localPosition = new Vector3(0f, 1f, 1f) + new Vector3(0f, 0.1f * stackList.Count, 0f);
    //    obje.transform.localRotation = Quaternion.Euler(obje.transform.localRotation.x, 6f, obje.transform.localRotation.z);

    //    stackList.Add(obje);

    //    if (stackList.Count == 5)
    //    {
    //        CancelInvoke("StackLeaven");
    //    }
    //}
}
