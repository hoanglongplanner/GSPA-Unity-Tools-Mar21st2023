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
using TMPro;
using UnityEngine.EventSystems;

public class GUIElementButton : MonoBehaviour, IGUIElementButton {
    [SerializeField] private IGUIManager m_guiManager;
    [SerializeField] private ENUM_GUIELEMENT_BUTTON_TYPE enum_buttonType; 
    private TextMeshProUGUI m_textMeshProUGUI;    

    void Start() => m_textMeshProUGUI = this.GetComponent<TextMeshProUGUI>();

    public bool IsType(ENUM_GUIELEMENT_BUTTON_TYPE type) { return enum_buttonType == type; }

    public void OnPointerClick(PointerEventData eventData) {
        if (GUIManagerSettings.K_ENABLE_ON_MOUSE_DOWN == false) return; //early-exit
        OnGUIElementButton(this, enum_buttonType, ENUM_GUIELEMENT_BUTTON_POINTER_TYPE.K_ON_MOUSE_DOWN);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if (GUIManagerSettings.K_ENABLE_ON_MOUSE_ENTER == false) return; //early-exit
        OnGUIElementButton(this, enum_buttonType, ENUM_GUIELEMENT_BUTTON_POINTER_TYPE.K_ON_ENTER);
    }

    public void OnPointerExit(PointerEventData eventData) {
        if (GUIManagerSettings.K_ENABLE_ON_MOUSE_EXIT == false) return; //early-exit
        OnGUIElementButton(this, enum_buttonType, ENUM_GUIELEMENT_BUTTON_POINTER_TYPE.K_ON_EXIT);
    }

    public void OnGUIElementButton(IGUIElementButton _button, ENUM_GUIELEMENT_BUTTON_TYPE _buttonType, ENUM_GUIELEMENT_BUTTON_POINTER_TYPE _buttonPointerType) {
        
    }
}
