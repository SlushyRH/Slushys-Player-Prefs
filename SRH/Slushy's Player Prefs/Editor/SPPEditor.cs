using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SRH
{
    public class SPPEditor : EditorWindow
    {
        [MenuItem("SRH/Player Prefs Editor")]
        private static void Init()
        {
            SPPEditor editor = GetWindow(typeof(SPPEditor), false, "Player Prefs Editor") as SPPEditor;
            editor.name = "Slushy's Player Prefs Editor";
        }   
    }
}