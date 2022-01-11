using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HairHolder))]
public class HairDrawer : Editor
{
    

    public override void OnInspectorGUI()
    {
        HairHolder hairHolder = (HairHolder)target;

        DrawDefaultInspector();
        
        if (GUILayout.RepeatButton("Add Stack"))
        {
            hairHolder.addhairStack();
        }

        GUILayout.Space(20);

        if (GUILayout.Button("Create Hair"))
        {
            hairHolder.createHair();
        }

        GUILayout.Space(20);

        if (GUILayout.Button("Delete All Hairs"))
        {
            hairHolder.DeleteAllHairs();
        }

        // EditorGUI.BeginChangeCheck();
        EditorGUILayout.LabelField("Head Scale");
        hairHolder.xHead = EditorGUILayout.Slider(hairHolder.xHead, 0, 5);
        hairHolder.yHead = EditorGUILayout.Slider(hairHolder.yHead, 0, 5);
        hairHolder.zHead = EditorGUILayout.Slider(hairHolder.zHead, 0, 5);

        EditorGUILayout.LabelField("Tail Scale");
        hairHolder.xTail = EditorGUILayout.Slider(hairHolder.xTail, 0, 5);
        hairHolder.yTail = EditorGUILayout.Slider(hairHolder.yTail, 0, 5);
        hairHolder.zTail = EditorGUILayout.Slider(hairHolder.zTail, 0, 5);

        EditorGUILayout.LabelField("Stack Scale");
        hairHolder.xStack = EditorGUILayout.Slider(hairHolder.xStack, 0, 5);
        hairHolder.yStack = EditorGUILayout.Slider(hairHolder.yStack, 0, 5);
        hairHolder.zStack = EditorGUILayout.Slider(hairHolder.zStack, 0, 5);

        EditorGUILayout.LabelField("Distance Between Stacks");
        hairHolder.distBetweenStacks = EditorGUILayout.Slider(hairHolder.distBetweenStacks, 0, 10);

        //hairHolder.changeDistBetweenStacks();

        EditorGUILayout.LabelField("Height of Stacks");
        hairHolder.heightOfStacks = EditorGUILayout.Slider(hairHolder.heightOfStacks, 0, 10);

        //hairHolder.changeHeightOfStacks();

        if(hairHolder.hairHeadRef == null) { return; }

        hairHolder.hairHeadRef.localScale = new Vector3(
            hairHolder.xHead,
            hairHolder.yHead,
            hairHolder.zHead
        );

        if (hairHolder.hairTailRef == null) { return; }

        hairHolder.hairTailRef.localScale = new Vector3(
            hairHolder.xTail,
            hairHolder.yTail,
            hairHolder.zTail
        );
        
        for (int i = 0; i < hairHolder.StacksRef.Count; i++)
        {
            if (hairHolder.StacksRef[i] == null) { continue; }
            hairHolder.StacksRef[i].localScale = new Vector3(
                hairHolder.xStack, 
                hairHolder.yStack,
                hairHolder.zStack
            );
        }
        


        // if (EditorGUI.EndChangeCheck())
        // {
        //     hairHolder.changeHeadScale();
        // }
        //EditorGUILayout.FloatField("Change Head Scale",hairHolder.headScale);
    }
}
