/*
Copyright 2023 hoanglongplanner
Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.

You may obtain a copy of the License at
http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public static readonly int[] K_DISPLAY_RESO_HORIZONTAL_ALL = { 600, 720, 1080, 640, 800, 1280, 1366, 1920, 2560 };
    public static readonly int[] K_DISPLAY_RESO_VERTICAL_ALL = { 800, 1280, 1920, 480, 600, 720, 768, 1080, 1440 };
}

public class GUIManager : MonoBehaviour, IGUIManager {

    GUIElementObject[] sz_m_guiElementObject;
    GUIElementText[] sz_m_guiElementText;
    GUIElementSlider[] sz_m_guiElementSlider;
    GUIElementDropdown[] sz_m_guiElementDropdown;
    
    void Start() {

    }

    void Update() {

    }

    public List<GUIElementText> GetAllTypeGUIElementText(ENUM_GUIELEMENT_TEXT_TYPE type) {
        List<GUIElementText> temp = new List<GUIElementText>();
        foreach(GUIElementText text in sz_m_guiElementText) {
            if (text.IsType(type)) temp.Add(text);
        }
        return temp; 
    }

    public void InitGUI() { }    

    public void UpdateText(ENUM_GUIELEMENT_TEXT_TYPE type) {
        switch (type) {
            case ENUM_GUIELEMENT_TEXT_TYPE.HIGHSCORE: break;
            case ENUM_GUIELEMENT_TEXT_TYPE.LIFE: break;
            case ENUM_GUIELEMENT_TEXT_TYPE.SOMETHING: break;
            default: break;
        }

        OnTextChange(type);
    }

    public void OnTextChange(ENUM_GUIELEMENT_TEXT_TYPE type) {
        switch (type) {
            case ENUM_GUIELEMENT_TEXT_TYPE.HIGHSCORE: break;
            case ENUM_GUIELEMENT_TEXT_TYPE.LIFE: break;
            case ENUM_GUIELEMENT_TEXT_TYPE.SOMETHING: break;
            default: break;
        }
    }

    public void CreateDropdown(GUIElementDropdown elementDropdown, ENUM_GUIELEMENT_DROPDOWN_TYPE type) {
        switch (type) {
            case ENUM_GUIELEMENT_DROPDOWN_TYPE.DISPLAY_SETTINGS: 
                for(int i = 0; i < GUIManagerSettings.K_DISPLAY_RESO_HORIZONTAL_ALL.Length; i++) {
                    for(int j = 0; j < GUIManagerSettings.K_DISPLAY_RESO_VERTICAL_ALL.Length; j++) {

                    }
                }
                break;
            default: break;
        }

        OnDropdownSelected(elementDropdown, type); //run-behavior
    }

    public void OnDropdownSelected(GUIElementDropdown elementDropdown, ENUM_GUIELEMENT_DROPDOWN_TYPE type) {
        switch (type) {
            case ENUM_GUIELEMENT_DROPDOWN_TYPE.DISPLAY_SETTINGS: break;
            default: break;
        }
    }    

    public void OnSliderChange() { }    

    public void CreateSlider() {
        throw new System.NotImplementedException();
    }

    public void OnButtonBehavior() {
        throw new System.NotImplementedException();
    }
}



