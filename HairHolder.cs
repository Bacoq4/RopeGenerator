 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairHolder : MonoBehaviour
{
    public Transform FollowTransform;
    public Transform QuadraticVectorC;
    [Range(0,1)]

    [Space(10)]

    public LineRenderer lineRenderer;

    [Space(10)]

    public Transform hairHead;
    public Transform hairStack;
    public Transform hairTail;

    [Space(10)]

    public Transform hairHeadRef;
    public Transform hairTailRef;

    [HideInInspector] public List<Transform> StacksRef = new List<Transform>();
    [HideInInspector] public List<Transform> Stacks = new List<Transform>();
    [HideInInspector] public List<HairBase> Hairs = new List<HairBase>();


    [HideInInspector] public float distBetweenStacks = 1;

    [HideInInspector] public float heightOfStacks = 1;

    [HideInInspector] public float xHead = 1;
    [HideInInspector] public float yHead = 1;
    [HideInInspector] public float zHead = 1;

    [HideInInspector] public float xTail = 1;
    [HideInInspector] public float yTail = 1;
    [HideInInspector] public float zTail = 1;

    [HideInInspector] public float xStack = 1;
    [HideInInspector] public float yStack = 1;
    [HideInInspector] public float zStack = 1;

    public float speed = 10f;
    public float zDiff = 0.1f;

    // [Range(0, 5)]
    // public float stackScale;

    // public float headScale;
    // [Range(0, 5)]
    // public float tailScale;
    //public Transform HeadNext;

    private void Awake() {
        HairBase.speed = speed;
        GiveIndexNumberToStacks();
    }

    public void changeDistBetweenStacks()
    {
        for (int i = 0; i < Stacks.Count; i++)
        {
            if(i == 0){ continue; }
            Stacks[i].localPosition = new Vector3
            (
                Stacks[i].localPosition.x,
                Stacks[i].localPosition.y,
                -i * distBetweenStacks
            );
        }
    }

    public void drawBezierQuadraticCurve(float timer)
    {
        if (hairHeadRef == null || hairTailRef == null){ return; }
        lineRenderer.SetPosition(0, hairHeadRef.position);
        lineRenderer.SetPosition(1, hairTailRef.position);
        Vector3 v = TransformFunctions.BezierQuadraticCurve3D(hairHeadRef.position, QuadraticVectorC.position, hairTailRef.position,timer);
    }

    public float[] getPointsBtw01(int count)
    {
        if(count == 0){ return null; }
        float[] fArr = new float[count];
        float minQuant = (float)1 / (float)count;
        float QuantIndexer = minQuant;

        for (int i = 0; i < count; i++)
        {
            fArr[i] = QuantIndexer;
            QuantIndexer += minQuant;
            
        }

        return fArr;
    }

    public void changeHeightOfStacks()
    {
        print(1);
        // int heightIndex = Stacks.Count;  
        // float heightIndexF = (float)heightIndex-2;
        float[] points = getPointsBtw01(Stacks.Count);

        //float heightHalf = Stacks.Count/2;
        for (int i = 0; i < Stacks.Count; i++)
        {
            if(Stacks[i] == null || Stacks[i] == hairTailRef || Stacks[i] == hairHeadRef){ continue; }

            Stacks[i].position = TransformFunctions.BezierQuadraticCurve3D(hairHeadRef.position, QuadraticVectorC.position, hairTailRef.position, points[i] ); 
            //print(points[i]);
            //print(heightIndexF / 10);
            //new Vector3(v.x,v.y,v.z);
            // Stacks[i].localPosition = new Vector3
            // (
            //     heightOfStacks * TransformFunctions.QuadraticCurve(hairHeadRef.position, hairTailRef.position, QuadraticVectorC.position, heightIndexF / 10).x,
            //     heightOfStacks * TransformFunctions.QuadraticCurve(hairHeadRef.position, hairTailRef.position, QuadraticVectorC.position, heightIndexF / 10).y,
            //     heightOfStacks * TransformFunctions.QuadraticCurve(hairHeadRef.position, hairTailRef.position, QuadraticVectorC.position, heightIndexF / 10).z
            // );
            //print(heightOfStacks * TransformFunctions.QuadraticCurve(hairTailRef.position, hairHeadRef.position, QuadraticVectorC.position, heightIndexF / 10).y);
            //print(heightOfStacks * TransformFunctions.QuadraticCurve(hairTailRef.position, hairHeadRef.position, QuadraticVectorC.position, heightIndexF / 10).z);
            //heightIndexF--;
        }
    }

    //-i* distBetweenStacks
    //heightIndex* heightOfStacks
    // Stacks[i].position.z*Stacks[i].position.z*heightOfStacks+Stacks[i].position.z
    // public float getQuadraticValue(int index,float halfCount, float closeQuantity)
    // {
    //     float x;
    //     x = index >= halfCount ? index * heightOfStacks : index * heightOfStacks;
    //     return x;
    // }
    // public float getQuadraticValue(int index, float halfCount, float closeQuantity)
    // {
    //     float x;
    //     x = index >= halfCount ? index * heightOfStacks : index * heightOfStacks;
    //     return x;
    // }
    // public void changeDistAndHeightOfStacks()
    // {
    //     if (hairHeadRef == null) { return; }
    //     //int heightIndex = Stacks.Count;
    //     Vector3[] poses = TransformFunctions.getPositionsOnYZ(
    //                         TransformFunctions.directions.UpRight,
    //                         Stacks[Stacks.Count - 1].position,
    //                         heightOfStacks,
    //                         -distBetweenStacks,
    //                         Stacks.Count
    //     );

    //     Array.Reverse(poses);

    //     for (int i = 0; i < Stacks.Count; i++)
    //     {
    //         Stacks[i].localPosition = new Vector3
    //         (
    //             Stacks[i].localPosition.x,
    //             poses[i].y,
    //             poses[i].z
    //         );
    //         //heightIndex--;
    //     }
    // }

    // public void changeStacksScale()
    // {
    //     for (int i = 0; i < StacksRef.Count; i++)
    //     {
    //         if(StacksRef[i] == null){ continue; }
    //         StacksRef[i].localScale = new Vector3(stackScale, stackScale, stackScale);
    //     }
    // }
    // public void changeHeadScale()
    // {
    //     if (hairHeadRef == null) { return; }
    //     hairHeadRef.localScale = new Vector3(headScale, headScale, headScale);
    // }
    // public void changeTailScale()
    // {
    //     if (hairTailRef == null) { return; }
    //     hairTailRef.localScale = new Vector3(tailScale, tailScale, tailScale);
    // }

    // void OnValidate()
    // {
    //     changeStacksScale();
    //     changeHeadScale();
    //     changeTailScale();
    // }

    public void createHair()
    {
        if (hairHeadRef != null || hairTailRef != null) { return; }
        //DeleteAllHairs();
        addhairHead();
        addHairTail();
        GiveIndexNumberToStacks();
    }

    public void DeleteAllHairs()
    {
        for (int i = 0; i < Stacks.Count; i++)
        {
            if(Stacks[i] == null){ continue; }
            DestroyImmediate(Stacks[i].gameObject);
        }
        ResetList();
    }
    public void ResetList()
    {       
        Stacks = new List<Transform>();
        StacksRef = new List<Transform>();
    }

    public void addhairStack()
    {
        if(hairHeadRef == null || hairTailRef == null) { return; }
        // create
        Transform go = TransformFunctions.createObject(hairStack.gameObject);
        // change stack position first
        go.transform.position = TransformFunctions.getLastChildFromList(Stacks).position;
        // add it to the parent
        TransformFunctions.addObjectToParent(transform, go);
        // Insert it to the 1 before the last
        Stacks.Insert(Stacks.Count - 1, go);
        // change tail position after
        Stacks[Stacks.Count - 1].position = Stacks[Stacks.Count - 1].position;
        // give next object of it
        StacksRef.Add(go);
        // add go to hairs
        // HairBase hair = go.GetComponent<HairBase>();
        // Hairs.Insert(Stacks.Count - 1, hair);
    }

    public void addhairHead()
    {
        // create
        Transform go = TransformFunctions.createObject(hairHead.gameObject);
        // change position to parent pos
        go.transform.position = transform.position;
        // add to parent
        TransformFunctions.addObjectToParent(transform, go);
        // Insert to list
        Stacks.Insert(0 , go);
        // take it to hairhead
        hairHeadRef = go.transform;
        // add go to hairs
        // HairBase hair = go.GetComponent<HairBase>();
        // Hairs.Insert(0, hair);
    }

    public void addHairTail()
    {
        // create
        Transform go = TransformFunctions.createObject(hairTail.gameObject);
        // change position to back of head // here will be corrected
        go.transform.position = Stacks[Stacks.Count - 1].position;
        // add to parent
        TransformFunctions.addObjectToParent(transform, go);
        // Insert to list
        Stacks.Add(go);
        // take to tail
        hairTailRef = go;
        // add go to hairs
        // HairBase hair = go.GetComponent<HairBase>();
        // Hairs.Add(hair);
    }

    public void GiveIndexNumberToStacks()
    {
        for (int i = 0; i < Stacks.Count ; i++)
        {
            if(Stacks[i] == null){ continue; }

            HairBase hair = Stacks[i].GetComponent<HairBase>();

            if(hair is HairHead) { 
                hair.nextStack = FollowTransform;
                continue; 
            }

            hair.nextStack = Stacks[i - 1];            
        }
    }

//    private void LateUpdate() {
//        transform.position = new Vector3(transform.position.x,transform.position.y,FollowTransform.position.z-zDiff);
//    }
    
}
