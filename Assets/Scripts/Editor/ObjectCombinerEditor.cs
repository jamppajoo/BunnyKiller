using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ObjectCombiner))]
[CanEditMultipleObjects]
public class ObjectCombinerEditor : Editor
{
    ObjectCombiner objectCombiner;

    SerializedObject GetTarget;
    SerializedProperty ThisList;
    int ListSize;

    private void OnEnable()
    {
        objectCombiner = (ObjectCombiner)target;

        GetTarget = new SerializedObject(objectCombiner);
        ThisList = GetTarget.FindProperty("MyList");

    }

    public override void OnInspectorGUI()
    {
        GetTarget.Update();

        EditorGUILayout.Space();
        EditorGUILayout.Space();


        for (int i = 0; i < ThisList.arraySize; i++)
        {
            
            SerializedProperty MyListRef = ThisList.GetArrayElementAtIndex(i);
            SerializedProperty MyTag1 = MyListRef.FindPropertyRelative("AnTag1");
            SerializedProperty MyTag2 = MyListRef.FindPropertyRelative("AnTag2");
            SerializedProperty MyOutput = MyListRef.FindPropertyRelative("AnOutput");

            // Choose to display automatic or custom field types. This is only for example to help display automatic and custom fields.
            EditorGUILayout.LabelField("Two tags that makes the gameobject when combined");
            EditorGUILayout.BeginHorizontal();
            MyTag1.stringValue = EditorGUILayout.TagField(MyTag1.stringValue).ToString();
            MyTag2.stringValue = EditorGUILayout.TagField(MyTag2.stringValue).ToString();
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUIUtility.labelWidth = 50;
            MyOutput.objectReferenceValue =  EditorGUILayout.ObjectField("Output", MyOutput.objectReferenceValue, typeof( GameObject), true);
            //EditorGUILayout.PropertyField(MyOutput);
            
            if (GUILayout.Button("Remove This Index (" + i.ToString() + ")", GUILayout.Width(200)))
            {
                ThisList.DeleteArrayElementAtIndex(i);
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
            
        }

        EditorGUILayout.Space();
        //Or add a new item to the List<> with a button
        EditorGUILayout.LabelField("Add a new item with a button");

        if (GUILayout.Button("Add New"))
        {
            objectCombiner.MyList.Add(new ObjectCombiner.MyClass());
        }
        //Apply the changes to our list
        GetTarget.ApplyModifiedProperties();
    }
}
