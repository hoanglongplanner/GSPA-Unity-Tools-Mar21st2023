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

public enum ENUM_GUIELEMENT_OBJECT_TYPE {
    SOMETHING
}

public enum ENUM_GUIELEMENT_BUTTON_POINTER_TYPE {
    K_ON_MOUSE_DOWN,
    K_ON_MOUSE_HOLD,
    K_ON_MOUSE_UP,
    K_ON_ENTER,
    K_ON_OVER,
    K_ON_EXIT,        
}

public enum ENUM_GUIELEMENT_BUTTON_TYPE {
    SOMETHING
}

public enum ENUM_GUIELEMENT_TEXT_TYPE {
    HIGHSCORE,
    LIFE,
    SOMETHING
}

public enum ENUM_GUIELEMENT_DROPDOWN_TYPE {
    DISPLAY_SETTINGS
}

public class GUIManagerSettings {
    public const bool K_ENABLE_ON_MOUSE_DOWN = true; //def: true
    public const bool K_ENABLE_ON_MOUSE_HOLD = false; //def: false
    public const bool K_ENABLE_ON_MOUSE_UP = true; //def: false
    public const bool K_ENABLE_ON_MOUSE_ENTER = true; //def: true
    public const bool K_ENABLE_ON_MOUSE_HOVER = false; //def: false    
    public const bool K_ENABLE_ON_MOUSE_EXIT = true; //def: true    

    public static readonly int[] K_DISPLAY_RESO_HORIZONTAL_ALL = { 600, 720, 1080, 640, 800, 1280, 1366, 1920, 2560 };
    public static readonly int[] K_DISPLAY_RESO_VERTICAL_ALL = { 800, 1280, 1920, 480, 600, 720, 768, 1080, 1440 };
}

public class GUIManager : MonoBehaviour, IGUIManager {

    [SerializeField] private List<GUIElementObject> list_m_guiElementObject;
    [SerializeField] private List<GUIElementText> list_m_guiElementText;
    [SerializeField] private List<GUIElementButton> list_m_guiElementButton;
    [SerializeField] private List<GUIElementSlider> list_m_guiElementSlider;
    [SerializeField] private List<GUIElementDropdown> list_m_guiElementDropdown;    

    void Start() {

    }

    void Update() {

    }

    public List<GUIElementText> GetAllGUIElementTextOfType(ENUM_GUIELEMENT_TEXT_TYPE _type) {
        List<GUIElementText> temp = new List<GUIElementText>();
        foreach (GUIElementText text in list_m_guiElementText) { if (text.IsType(_type)) temp.Add(text); }
        return temp; //return-result
    }

    public List<GUIElementButton> GetAllGUIElementButtonOfType(ENUM_GUIELEMENT_BUTTON_TYPE _type) {
        List<GUIElementButton> temp = new List<GUIElementButton>();
        foreach (GUIElementButton button in list_m_guiElementButton) { if (button.IsType(_type)) temp.Add(button); }
        return temp; //return-result
    }

    public void InitGUI() { }

    public void SetupGUIManager(Transform targetTransform = null, bool isItself = false) {
        if (isItself) targetTransform = this.transform;
        if (targetTransform == null) return; //early-exit

        foreach (Transform item in targetTransform) {
            CheckGUIElementLists(item);
            if (item.childCount > 0) SetupGUIManager(item, false); //WARNING-RECCURSIVE            
        }
    }

    private void CheckGUIElementLists(Transform target) {
        GUIElementObject guiObject = target.GetComponent<GUIElementObject>();
        if (guiObject != null) { list_m_guiElementObject.Add(guiObject); 
            return; //early-exit
        }

        GUIElementText guiText = target.GetComponent<GUIElementText>();
        if (guiText != null) { list_m_guiElementText.Add(guiText); 
            return; //early-exit
        }

        GUIElementButton guiButton = target.GetComponent<GUIElementButton>();
        if (guiButton != null) { list_m_guiElementButton.Add(guiButton); 
            return; //early-exit
        }
    }

    public void TryGUIElementObject(ENUM_GUIELEMENT_OBJECT_TYPE _type) {
        foreach (GUIElementObject item in list_m_guiElementObject) {
            if (item.IsType(_type)) continue; //skip-if-not-correct-type            
        }

        OnGUIElementObject(_type); //call-function            
    }

    public void OnGUIElementObject(ENUM_GUIELEMENT_OBJECT_TYPE _type) {
        switch (_type) {            
            default:
                break;
        }
    }

    public void UpdateText(ENUM_GUIELEMENT_TEXT_TYPE type) {
        switch (type) {
            case ENUM_GUIELEMENT_TEXT_TYPE.HIGHSCORE: break;
            case ENUM_GUIELEMENT_TEXT_TYPE.LIFE: break;
            case ENUM_GUIELEMENT_TEXT_TYPE.SOMETHING: break;
            default: break;
        }

        OnGUIElementText(type);
    }

    public void OnGUIElementText(ENUM_GUIELEMENT_TEXT_TYPE type) {
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

    public void OnGUIElementSlider() { }    

    public void CreateSlider() {
        throw new System.NotImplementedException();
    }

    public void OnGUIElementButton() {
        throw new System.NotImplementedException();
    }

    public void DoGUIElementButton(GUIElementButton guiButton, ENUM_GUIELEMENT_BUTTON_TYPE buttonType, ENUM_GUIELEMENT_BUTTON_POINTER_TYPE _buttonPointerType) {
        switch (_buttonPointerType) {
            case ENUM_GUIELEMENT_BUTTON_POINTER_TYPE.K_ON_MOUSE_DOWN: break;
            case ENUM_GUIELEMENT_BUTTON_POINTER_TYPE.K_ON_MOUSE_HOLD: break;
            case ENUM_GUIELEMENT_BUTTON_POINTER_TYPE.K_ON_MOUSE_UP: break;
            case ENUM_GUIELEMENT_BUTTON_POINTER_TYPE.K_ON_ENTER: break;
            case ENUM_GUIELEMENT_BUTTON_POINTER_TYPE.K_ON_OVER: break;
            case ENUM_GUIELEMENT_BUTTON_POINTER_TYPE.K_ON_EXIT: break;
            default: break;
        }
    }

    
}



