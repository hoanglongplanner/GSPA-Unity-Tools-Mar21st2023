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
using UnityEngine.EventSystems;

public class GUIElementButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler {
    [SerializeField] private GUIManager m_guiManager;
    [SerializeField] private ENUM_GUIELEMENT_BUTTON_TYPE enum_type;
    private bool isMouseHover;
    public void SetGUIManager(GUIManager _guiManager) => m_guiManager = _guiManager;
    public bool IsType(ENUM_GUIELEMENT_BUTTON_TYPE _type) { return _type == enum_type; }
    public ENUM_GUIELEMENT_BUTTON_TYPE GetTypeButton() { return enum_type; }

    private void Update() {
        if (isMouseHover && GUISettings.K_ENABLE_POINTER_ON_MOUSE_HOVER) {
            m_guiManager.OnGUIElementButton(this, enum_type, ENUM_GUIELEMENT_POINTER_STATUS.ON_MOUSE_HOLD);
        }
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (GUISettings.K_ENABLE_POINTER_ON_MOUSE_DOWN == false) return; //Check-functionality
        m_guiManager.OnGUIElementButton(this, enum_type, ENUM_GUIELEMENT_POINTER_STATUS.ON_MOUSE_DOWN);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if (GUISettings.K_ENABLE_POINTER_ON_MOUSE_ENTER == false) return; //Check-functionality
        isMouseHover = true;
        m_guiManager.OnGUIElementButton(this, enum_type, ENUM_GUIELEMENT_POINTER_STATUS.ON_ENTER);
    }

    public void OnPointerExit(PointerEventData eventData) {
        if (GUISettings.K_ENABLE_POINTER_ON_MOUSE_EXIT == false) return; //Check-functionality        
        isMouseHover = false;
        m_guiManager.OnGUIElementButton(this, enum_type, ENUM_GUIELEMENT_POINTER_STATUS.ON_EXIT);
    }

    public void OnPointerDown(PointerEventData eventData) {
        if (GUISettings.K_ENABLE_POINTER_ON_MOUSE_HOLD == false) return; //Check-functionality
        m_guiManager.OnGUIElementButton(this, enum_type, ENUM_GUIELEMENT_POINTER_STATUS.ON_MOUSE_HOLD);
    }

    public void OnPointerUp(PointerEventData eventData) {
        if (GUISettings.K_ENABLE_POINTER_ON_MOUSE_RELEASE == false) return; //Check-functionality
        m_guiManager.OnGUIElementButton(this, enum_type, ENUM_GUIELEMENT_POINTER_STATUS.ON_MOUSE_RELEASE);
    }
}
