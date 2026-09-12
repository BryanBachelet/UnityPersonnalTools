using UnityEditor.Rendering;
using UnityEngine;

namespace Cardefense
{
    public class CurveCustom : AnimationCurve
    {
#if UNITY_EDITOR
        //public InspectorCurveEditor inspectorCurveEditor = new InspectorCurveEditor();
        public CurveAnimPreset preset;
#endif
    }
}
