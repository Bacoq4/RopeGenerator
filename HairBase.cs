using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class HairBase : MonoBehaviour
{
    // public GameObject textPrefab;
    // [SerializeField]
    // private Vector3 textAddedPos = new Vector3(0,5,0);
    // public int Index;
    // //public Text hairText;
    public Transform nextStack;
    // public string str;
    public static float speed = 10;

    protected virtual void Awake() {
    //     str = "Index = " + Index;
    //     Vector3 pos = transform.position + textAddedPos;
    //     hairText = TransformFunctions.create3DText(transform,str,pos,textPrefab.transform);
    }
    // public void changeIndex(int index)
    // {
    //     Index = index;
    //     str = "Index = " + Index;
    //     if (hairText != null)
    //     {
    //         changeText(str);
    //     }
    // }
    // public void changeText(string str)
    // {
    //     hairText.text = str;
    // }

    protected virtual void Update() {
        Vector3 correctedPos = new Vector3(nextStack.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position,correctedPos,speed * Time.deltaTime);
        transform.LookAt(new Vector3(nextStack.position.x, nextStack.position.y, nextStack.position.z));
    }

}
