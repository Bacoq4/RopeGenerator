using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairHead : HairBase
{
    void LateUpdate()
    {
        Vector3 correctedPos = new Vector3(nextStack.position.x, nextStack.position.y, transform.position.z);
        transform.position = correctedPos;
    } 
    protected override void Update()
    {

    }
}
