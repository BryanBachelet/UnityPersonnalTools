//using UnityEngine;
//using UnityEditor;
//using UnityEditor.Rendering;
//using static UnityEditor.Rendering.InspectorCurveEditor;
//using UnityEngine.UIElements;


//namespace Cardefense
//{

//    [CustomPropertyDrawer(typeof(DetailsCurves))]
//    public class DetailCurveDrawer : PropertyDrawer
//    {

//        string curvePropertyRegister;
//        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
//        {
//            float height = base.GetPropertyHeight(property, label);

//            if (property.propertyType == SerializedPropertyType.AnimationCurve)
//            {
//                height += (EditorGUIUtility.singleLineHeight * 10);
//                height += (EditorGUIUtility.singleLineHeight + 5);
//                height += (EditorGUIUtility.singleLineHeight * 10);
//                height += property.animationCurveValue.length * (EditorGUIUtility.singleLineHeight + 5);
//            }

//            return height;
//        }
//        public override VisualElement CreatePropertyGUI(SerializedProperty property)
//        {


//            return base.CreatePropertyGUI(property);
//        }


//        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
//        {

//            if (property.propertyType != SerializedPropertyType.AnimationCurve) return;

//            DetailsCurves range = attribute as DetailsCurves;

//            property.serializedObject.Update();
//            position.height = EditorGUIUtility.singleLineHeight;

//            EditorGUI.BeginChangeCheck();
//            EditorGUI.BeginProperty(position, label, property);

//            EditorGUI.PropertyField(position, property);

//            position.y += position.height + EditorGUIUtility.singleLineHeight + 5;


//            System.Enum enumPreset = range.preset;
//            enumPreset = EditorGUI.EnumPopup(position, enumPreset);
//            position.y += position.height + EditorGUIUtility.singleLineHeight + 5;
//            if (GUI.Button(position, "+"))
//            {
//                AddCurve(property);
//            }
//            position.y += position.height + EditorGUIUtility.singleLineHeight + 5;
//            position.height *= 10;
//            Cardefense.CurveAnimPreset newValuePreset = (Cardefense.CurveAnimPreset)enumPreset;


//            if (property.propertyPath == curvePropertyRegister && range.inspectorCurveEditor.OnGUI(position))
//            {


//                GUI.changed = true;
//                if (EditorGUI.EndChangeCheck())
//                {
//                    property.serializedObject.ApplyModifiedProperties();
//                    property.serializedObject.Update();
//                    return;
//                }
//            }

//            position.y += position.height;
//            position.height /= 10;

//            if (range.preset != newValuePreset)
//            {
//                AnimationCurve newAnimationCurve = new AnimationCurve();


//                switch (newValuePreset)
//                {

//                    case CurveAnimPreset.NONE:
//                        newAnimationCurve = new AnimationCurve();
//                        break;
//                    case CurveAnimPreset.CONSTANT:
//                        newAnimationCurve = AnimationCurve.Constant(0, 1, 1);
//                        break;
//                    case CurveAnimPreset.LINEAR:
//                        newAnimationCurve = AnimationCurve.Linear(0, 0, 1, 1);
//                        break;
//                    case CurveAnimPreset.EasyInOut:
//                        newAnimationCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
//                        break;
//                    default:
//                        newAnimationCurve = new AnimationCurve();
//                        break;
//                }

//                range.preset = newValuePreset;
//                property.animationCurveValue = newAnimationCurve;
//                if (EditorGUI.EndChangeCheck())
//                {
//                    property.serializedObject.ApplyModifiedProperties();
//                    property.serializedObject.Update();
//                }
//                return;
//            }


//            System.Span<Keyframe> keyframes = new System.Span<Keyframe>(new Keyframe[property.animationCurveValue.length]);
//            property.animationCurveValue.GetKeys(keyframes);
//            AnimationCurve animationCurve = new AnimationCurve();

//            for (int i = 0; i < keyframes.Length; i++)
//            {
//                GUIContent labelKeys = new GUIContent("Key :" + i.ToString());
//                position.y += EditorGUIUtility.singleLineHeight + 5;


//                Rect positionLabel = new Rect(position.x, position.y, 100, position.height);

//                EditorGUI.LabelField(positionLabel, labelKeys);

//                Rect positionField = new Rect(position.x + positionLabel.width + 10, position.y, 200, position.height);
//                keyframes[i].time = EditorGUI.FloatField(positionField, GUIContent.none, keyframes[i].time);
//                positionField.x += positionField.width + 10;
//                keyframes[i].value = EditorGUI.FloatField(positionField, GUIContent.none, keyframes[i].value, EditorStyles.numberField);

//                Rect positionButton = new Rect(positionField.x + positionField.width + 10, positionField.y, (positionField.width - 10) / 4, positionField.height);

//                if (GUI.Button(positionButton, "+"))
//                {
//                    Keyframe keyframe = new Keyframe();
//                    keyframe.value = keyframes[i].value;
//                    keyframe.time = keyframes[i].time + 0.1f;
//                    keyframe.inTangent = -1;
//                    keyframe.outTangent = 0.5f;
//                    animationCurve.SetKeys(keyframes);
//                    animationCurve.AddKey(keyframes[i].time + 0.1f, keyframes[i].value);
//                    AnimationUtility.SetKeyLeftTangentMode(animationCurve, i + 1, AnimationUtility.TangentMode.Linear);
//                    property.animationCurveValue = animationCurve;
//                    if (EditorGUI.EndChangeCheck())
//                    {
//                        property.serializedObject.ApplyModifiedProperties();
//                        property.serializedObject.Update();
//                        return;
//                    }
//                }
//                positionButton.x += positionButton.width;
//                if (GUI.Button(positionButton, "-"))
//                {
//                    animationCurve.SetKeys(keyframes);
//                    animationCurve.RemoveKey(i);
//                    property.animationCurveValue = animationCurve;
//                    if (EditorGUI.EndChangeCheck())
//                    {
//                        property.serializedObject.ApplyModifiedProperties();
//                        property.serializedObject.Update();
//                        return;
//                    }
//                }
//            }



//            animationCurve.SetKeys(keyframes);
//            property.animationCurveValue = animationCurve;
//            if (EditorGUI.EndChangeCheck())
//            {
//                property.serializedObject.ApplyModifiedProperties();
//                property.serializedObject.Update();
//            }
//;


//            property.serializedObject.ApplyModifiedProperties();
//            property.serializedObject.Update();
//            EditorGUI.EndProperty();



//        }

//        public void AddCurve(SerializedProperty property)
//        {
//            DetailsCurves range = attribute as DetailsCurves;

//            var state = CurveState.defaultState;
//            state.color = Color.rebeccaPurple;
//            state.visible = true;
//            state.minPointCount = 10;
//            state.onlyShowHandlesOnSelection = true;
//            //state.zeroKeyConstantValue = 0.5f;
//            state.loopInBounds = false;
//            state.editable = true;

//            range.inspectorCurveEditor.RemoveAll();
//            range.inspectorCurveEditor.Add(property, state);
//            curvePropertyRegister = property.propertyPath;
//            Debug.Log("Bool");

//        }
//    }

//}
