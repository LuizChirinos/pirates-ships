using UnityEditor;
using UnityEngine;

namespace PiratesShip.Score
{
    [CustomEditor(typeof(ScriptableNumber))]
    public class ScriptableNumberEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            ScriptableNumber scoreController = target as ScriptableNumber;

            EditorGUILayout.LabelField($"{nameof(scoreController.SavedValue)} = {scoreController.SavedValue}");

            EditorGUILayout.BeginVertical("box");
            
            EditorGUILayout.BeginHorizontal("box");
            if (GUILayout.Button("Add Score"))
                scoreController.Add(1);
            if (GUILayout.Button("Remove Score"))
                scoreController.Remove(1);
            EditorGUILayout.EndHorizontal();
            
            if (GUILayout.Button("Reset Score"))
                scoreController.Reset();


            EditorGUILayout.EndVertical();
        }
    }
}
