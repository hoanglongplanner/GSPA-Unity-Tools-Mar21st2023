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

//Added library
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class GUIElementSlider : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {
    [SerializeField] private GUIManager m_guiManager;
    [SerializeField] private ENUM_GUIELEMENT_SLIDER_TYPE enum_type;
    [SerializeField] private Slider m_slider;
    [SerializeField] private bool isMouseHover = false;

    public void SetGUIManager(GUIManager _guiManager) => m_guiManager = _guiManager;
    public void Setup() {
        m_slider = this.GetComponent<Slider>();
        m_slider.onValueChanged.AddListener(delegate { m_guiManager.OnGUIElementSlider(this, enum_type); });
        m_guiManager.OnGUIElementSlider(this, enum_type);
    }

    public void SetupSlider(float min, float max, float defaultValue, bool isWholeNumber = false) {
        m_slider.wholeNumbers = isWholeNumber;
        m_slider.minValue = min;
        m_slider.maxValue = max;
        m_slider.value = defaultValue;
    }

    public bool IsType(ENUM_GUIELEMENT_SLIDER_TYPE _type) { return _type == enum_type; }
    public ENUM_GUIELEMENT_SLIDER_TYPE GetTypeSlider() { return enum_type; }

    private void Update() {
        if (isMouseHover && GUISettings.K_ENABLE_POINTER_ON_MOUSE_HOVER) {
            m_guiManager.GUIElementSliderManager(ENUM_GUIELEMENT_POINTER_STATUS.ON_HOVER);
        }
    }

    public float GetValue() { return m_slider.value; }

    public void SetActive(bool status) => this.transform.gameObject.SetActive(status);

    public void OnPointerClick(PointerEventData eventData) => m_guiManager.GUIElementSliderManager(ENUM_GUIELEMENT_POINTER_STATUS.ON_MOUSE_DOWN);

    public void OnPointerEnter(PointerEventData eventData) {
        isMouseHover = true;
        m_guiManager.GUIElementSliderManager(ENUM_GUIELEMENT_POINTER_STATUS.ON_ENTER);
    }

    public void OnPointerExit(PointerEventData eventData) {
        isMouseHover = false;
        m_guiManager.GUIElementSliderManager(ENUM_GUIELEMENT_POINTER_STATUS.ON_EXIT);
    }
}
