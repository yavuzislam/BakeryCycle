using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take : MonoBehaviour
{
    public stack stacks;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
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

    }
}
