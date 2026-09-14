using UnityEngine;
using System;

namespace Cardefense
{
    [System.Serializable]
    public enum CurveAnimPreset
    {
        NONE = 0,
        CONSTANT = 1,
        LINEAR = 2,
        EasyInOut = 3,
    }

    [System.Serializable]
    public class DetailsCurves : PropertyAttribute
    {

        public CurveAnimPreset preset;
   //     public InspectorCurveEditor inspectorCurveEditor = new InspectorCurveEditor();
        public DetailsCurves()
        {

        }

        //public DetailsCurves(bool applyToCollection) : base(applyToCollection)
        //{
        //}
    }
}
