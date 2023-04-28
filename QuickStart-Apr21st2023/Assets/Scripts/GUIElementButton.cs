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

public class GUIElementButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {
    [SerializeField] private ENUM_GUIELEMENT_BUTTON_TYPE enum_type;

    public bool IsType(ENUM_GUIELEMENT_BUTTON_TYPE _type) { return _type == enum_type; }

    public void OnPointerClick(PointerEventData eventData) {
        if (GUISettings.K_ENABLE_POINTER_ON_MOUSE_DOWN == false) return; //Check-functionality
        GUIManager.Instance.OnGUIElementButton(this, enum_type, ENUM_GUIELEMENT_POINTER_STATUS.ON_MOUSE_DOWN);
    }        

    public void OnPointerEnter(PointerEventData eventData) {
        if (GUISettings.K_ENABLE_POINTER_ON_ENTER_HOVER == false) return; //Check-functionality        
        GUIManager.Instance.OnGUIElementButton(this, enum_type, ENUM_GUIELEMENT_POINTER_STATUS.ON_ENTER_HOVER);
    }

    public void OnPointerExit(PointerEventData eventData) {
        if (GUISettings.K_ENABLE_POINTER_ON_EXIT == false) return; //Check-functionality        
        GUIManager.Instance.OnGUIElementButton(this, enum_type, ENUM_GUIELEMENT_POINTER_STATUS.ON_EXIT);
    }
}
