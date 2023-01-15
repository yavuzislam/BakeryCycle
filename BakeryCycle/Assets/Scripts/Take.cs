using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;
using DG.Tweening;
using static UnityEditor.Progress;

public class Take : MonoBehaviour
{
    public GameObject leaven, bakery;
    public stack stacks;
    float duration;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (stacks.stackList.Count < 5)
            {
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (var item in stacks.stackList)
            {
                Destroy(item.gameObject);
            }
            stacks.stackList.Clear();
            InvokeRepeating("bake", 2f, 2f);
        }
    }
    public void bake()
    {
        Debug.Log(stacks.stackList.Count);
        float z = -0.5f;
        GameObject bakeobje = Instantiate(leaven);
        bakeobje.transform.position = bakery.transform.position + new Vector3(0f, 0f, z);
        bakeobje.transform.rotation = Quaternion.Euler(bakeobje.transform.rotation.x, 5.733f, bakeobje.transform.rotation.z);
        bakeobje.transform.parent = bakery.transform;
        z -= 0.5f;
        //5.733
        stacks.stackList.Add(bakeobje);

        if (stacks.stackList.Count == 5)
        {
            CancelInvoke("bake");
            stacks.stackList.Clear();
        }
    }
}
