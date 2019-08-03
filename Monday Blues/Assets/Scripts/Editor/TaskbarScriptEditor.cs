using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TaskbarScript))]
public class TaskbarScriptEditor : Editor
{

    public override void OnInspectorGUI()
    {

        TaskbarScript baseScript = (TaskbarScript)target;

        DrawDefaultInspector();

        if (GUILayout.Button ("Set Front Window"))
        {
            baseScript.SetFrontWindow(baseScript.selectedWindow);
        }

    }

}
