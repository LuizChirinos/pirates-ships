using UnityEditor;
using UnityEngine;

namespace PiratesShip.Score
{
    [CustomEditor(typeof(ScoreController))]
    public class ScoreControllerEditor : Editor
    {
        private SerializedProperty scoreProperty;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            ScoreController scoreController = target as ScoreController;

            EditorGUILayout.LabelField($"{nameof(scoreProperty.name)} = {scoreController.SavedScore}");

            EditorGUILayout.BeginVertical("box");
            
            EditorGUILayout.BeginHorizontal("box");
            if (GUILayout.Button("Add Score"))
                scoreController.Add(1);
            if (GUILayout.Button("Remove Score"))
                scoreController.Remove(1);
            EditorGUILayout.EndHorizontal();
            
            if (GUILayout.Button("Reset Score"))
                scoreController.ResetScore();


            EditorGUILayout.EndVertical();
        }
    }
}
