using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ExecuteRefCodeAlways : MonoBehaviour
{
    public HairHolder hairHolder;

    private void Awake() {
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        hairHolder.changeHeightOfStacks();
    }
}
