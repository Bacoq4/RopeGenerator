using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ExecuteRefCodeAlways : MonoBehaviour
{
    public HairHolder hairHolder;

    // Update is called once per frame
    void Update()
    {
        hairHolder.changeHeightOfStacks();
    }
}
