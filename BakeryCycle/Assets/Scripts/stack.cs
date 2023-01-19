using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class stack : MonoBehaviour
{
    public Image image;
    public GameObject stackparent;
    public Vector3 stackpos;
    public Transform machin;
    float duration;
    public PlayerControl playerControl;
    public List<GameObject> stackList;
    public GameObject leaven;
    public bool set;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (set)
            {
                if (stackList.Count < 5)
                {
                    image.fillAmount = duration;
                    duration += Time.deltaTime;
                    if (duration > 1)
                    {
                        duration = 0;
                        stackList.Add(leaven);
                        GameObject obje = Instantiate(leaven, machin);
                        obje.transform.localPosition = Vector3.zero;
                        obje.transform.DOLocalRotate(new Vector3(0.122252546f, 1.87799597f, 356.276764f), 0.01f);
                        obje.transform.parent = stackparent.transform;
                        obje.transform.DOLocalMove(stackpos, 0.1f);
                        stackpos += new Vector3(0f, 0.1f, 0f);
                        Debug.Log("�al��t�");
                    }
                }
                if (stackList.Count == 5)
                {
                    duration = 0;
                    image.fillAmount = 0;
                    stackpos = Vector3.zero;
                }
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        duration = 0;
        if (stackparent.transform.childCount != 0)
        {
            if (stackparent.transform.GetChild(0).tag == "bake")
            {
                set = false;
            }
            else
            {
                set = true;
            }
        }
        else
        {
            set = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            duration = 0;
            image.fillAmount = 0;
            //stackpos = Vector3.zero;
            Debug.Log("c�k�ld�");
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
