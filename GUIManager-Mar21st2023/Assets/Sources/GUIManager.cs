using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ADD LIBRARY
using GUIManagerV00_Mar21st2023;

namespace GUIManagerV00_Mar21st2023 {
    public enum ENUM_GUIELEMENT_TEXT_TYPE {
        HIGHSCORE,
        LIFE,
        SOMETHING
    }

    public enum ENUM_GUIELEMENT_DROPDOWN_TYPE {
        DISPLAY_SETTINGS
    }

    public class GUIManagerSettings {
        public const bool K_ENABLE_TOUCH = false; //def: false
    }

    public class GUIManager : MonoBehaviour, IGUIManager {
        void Start() {

        }

        void Update() {

        }

        public void InitGUI() { }

        public void OnDropdownSelected() { }

        public void OnTextChange() { }

        public void OnSliderChange() { }
    }
}


