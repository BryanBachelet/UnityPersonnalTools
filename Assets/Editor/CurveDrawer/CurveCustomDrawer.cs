//using UnityEditor;
//using UnityEngine;
//using static UnityEditor.Rendering.InspectorCurveEditor;
//using UnityEngine.UIElements;
//using UnityEditor.Rendering;

//namespace Cardefense
//{
//    [CustomPropertyDrawer(typeof(CurveCustom))]
//    public class CurveCustomDrawer : PropertyDrawer
//    {
//        //public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
//        //{
//        //    float height = base.GetPropertyHeight(property, label);

//        //    if (property.propertyType == SerializedPropertyType.AnimationCurve)
//        //    {
//        //        height += (EditorGUIUtility.singleLineHeight * 10);
//        //        height += (EditorGUIUtility.singleLineHeight + 5);
//        //        height += (EditorGUIUtility.singleLineHeight * 10);
//        //        height += property.animationCurveValue.length * (EditorGUIUtility.singleLineHeight + 5);
//        //    }

//        //    return height;
//        //}

//        //public override VisualElement CreatePropertyGUI(SerializedProperty property)
//        //{
//        //    InspectorCurveEditor inspectorCurveEditor = (InspectorCurveEditor)property.FindPropertyRelative("inspectorCurveEditor").;
//        //    inspectorCurveEditor.Remove(property);
//        //    var state = CurveState.defaultState;
//        //    state.color = Color.rebeccaPurple;
//        //    state.visible = true;
//        //    state.minPointCount = 10;
//        //    state.onlyShowHandlesOnSelection = true;
//        //    //state.zeroKeyConstantValue = 0.5f;
//        //    state.loopInBounds = false;
//        //    state.editable = true;
//        //    Debug.Log("Bool");

//        //    inspectorCurveEditor.Add(property, state);
//        //    return base.CreatePropertyGUI(property);
//        //}

//        //public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
//        //{
            
//        //}

//        }
//    }
