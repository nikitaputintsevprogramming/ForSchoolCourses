using UnityEngine;
using UnityEditor;

// ReSharper disable once CheckNamespace
namespace AkilliMum.Motion
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(ConstantMotion))]
    public class ConstantMotionEditor : Editor
    {
        SerializedProperty _translationMode;
        SerializedProperty _translationVector;
        SerializedProperty _translationSpeed;

        SerializedProperty _rotationMode;
        SerializedProperty _rotationAxis;
        SerializedProperty _rotationSpeed;

        SerializedProperty _useLocalCoordinate;

        static GUIContent _textLocalCoordinate = new GUIContent("Local Coordinate");
        static GUIContent _textRotation = new GUIContent("Rotation");
        static GUIContent _textSpeed = new GUIContent("Speed");
        static GUIContent _textTranslation = new GUIContent("Translation");
        static GUIContent _textVector = new GUIContent("Vector");

        // ReSharper disable once UnusedMember.Local
        void OnEnable()
        {
            _translationMode = serializedObject.FindProperty("_translationMode");
            _translationVector = serializedObject.FindProperty("_translationVector");
            _translationSpeed = serializedObject.FindProperty("_translationSpeed");

            _rotationMode = serializedObject.FindProperty("_rotationMode");
            _rotationAxis = serializedObject.FindProperty("_rotationAxis");
            _rotationSpeed = serializedObject.FindProperty("_rotationSpeed");

            _useLocalCoordinate = serializedObject.FindProperty("_useLocalCoordinate");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_translationMode, _textTranslation);

            EditorGUI.indentLevel++;

            if (_translationMode.hasMultipleDifferentValues ||
                _translationMode.enumValueIndex == (int)ConstantMotion.TranslationMode.Vector)
                EditorGUILayout.PropertyField(_translationVector, _textVector);

            if (_translationMode.hasMultipleDifferentValues ||
                _translationMode.enumValueIndex != 0)
                EditorGUILayout.PropertyField(_translationSpeed, _textSpeed);

            EditorGUI.indentLevel--;

            EditorGUILayout.PropertyField(_rotationMode, _textRotation);

            EditorGUI.indentLevel++;

            if (_rotationMode.hasMultipleDifferentValues ||
                _rotationMode.enumValueIndex == (int)ConstantMotion.RotationMode.Vector)
                EditorGUILayout.PropertyField(_rotationAxis, _textVector);

            if (_rotationMode.hasMultipleDifferentValues ||
                _rotationMode.enumValueIndex != 0)
                EditorGUILayout.PropertyField(_rotationSpeed, _textSpeed);

            EditorGUI.indentLevel--;

            EditorGUILayout.PropertyField(_useLocalCoordinate, _textLocalCoordinate);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
