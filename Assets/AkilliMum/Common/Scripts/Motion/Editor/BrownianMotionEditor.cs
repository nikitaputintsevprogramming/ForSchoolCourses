using UnityEngine;
using UnityEditor;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace AkilliMum.Motion
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(BrownianMotion))]
    public class BrownianMotionEditor : Editor
    {
        SerializedProperty _enablePositionNoise;
        SerializedProperty _enableRotationNoise;
        SerializedProperty _positionFrequency;
        SerializedProperty _rotationFrequency;
        SerializedProperty _positionAmplitude;
        SerializedProperty _rotationAmplitude;
        SerializedProperty _positionScale;
        SerializedProperty _rotationScale;
        SerializedProperty _positionFractalLevel;
        SerializedProperty _rotationFractalLevel;

        static GUIContent _textPositionNoise = new GUIContent("Position Noise");
        static GUIContent _textRotationNoise = new GUIContent("Rotation Noise");
        static GUIContent _textFrequency = new GUIContent("Frequency");
        static GUIContent _textAmplitude = new GUIContent("Amplitude");
        static GUIContent _textScale = new GUIContent("Scale");
        static GUIContent _textFractal = new GUIContent("Fractal");

        // ReSharper disable once UnusedMember.Local
        void OnEnable()
        {
            _enablePositionNoise = serializedObject.FindProperty("_enablePositionNoise");
            _enableRotationNoise = serializedObject.FindProperty("_enableRotationNoise");
            _positionFrequency = serializedObject.FindProperty("_positionFrequency");
            _rotationFrequency = serializedObject.FindProperty("_rotationFrequency");
            _positionAmplitude = serializedObject.FindProperty("_positionAmplitude");
            _rotationAmplitude = serializedObject.FindProperty("_rotationAmplitude");
            _positionScale = serializedObject.FindProperty("_positionScale");
            _rotationScale = serializedObject.FindProperty("_rotationScale");
            _positionFractalLevel = serializedObject.FindProperty("_positionFractalLevel");
            _rotationFractalLevel = serializedObject.FindProperty("_rotationFractalLevel");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_enablePositionNoise, _textPositionNoise);

            if (_enablePositionNoise.hasMultipleDifferentValues || _enablePositionNoise.boolValue)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(_positionFrequency, _textFrequency);
                EditorGUILayout.PropertyField(_positionAmplitude, _textAmplitude);
                EditorGUILayout.PropertyField(_positionScale, _textScale);
                EditorGUILayout.PropertyField(_positionFractalLevel, _textFractal);
                EditorGUI.indentLevel--;
            }

            EditorGUILayout.PropertyField(_enableRotationNoise, _textRotationNoise);

            if (_enableRotationNoise.hasMultipleDifferentValues || _enableRotationNoise.boolValue)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(_rotationFrequency, _textFrequency);
                EditorGUILayout.PropertyField(_rotationAmplitude, _textAmplitude);
                EditorGUILayout.PropertyField(_rotationScale, _textScale);
                EditorGUILayout.PropertyField(_rotationFractalLevel, _textFractal);
                EditorGUI.indentLevel--;
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
