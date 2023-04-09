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

public interface IGUIManager {
    //Get Functions
    public System.Collections.Generic.List<GUIElementObject> GetAllGUIElementObjectOfType(ENUM_GUIELEMENT_OBJECT_TYPE _type);
    public System.Collections.Generic.List<GUIElementText> GetAllGUIElementTextOfType(ENUM_GUIELEMENT_TEXT_TYPE _type);
    public System.Collections.Generic.List<GUIElementButton> GetAllGUIElementButtonOfType(ENUM_GUIELEMENT_BUTTON_TYPE _type);
    public System.Collections.Generic.List<GUIElementSlider> GetAllGUIElementSliderOfType(ENUM_GUIELEMENT_OBJECT_TYPE _type);
    public System.Collections.Generic.List<GUIElementDropdown> GetAllGUIElementDropdownOfType(ENUM_GUIELEMENT_OBJECT_TYPE _type);

    //Functions
    public void InitGUI();
    public void SetupGUIManager(UnityEngine.Transform _transform = null, bool _isItself = false);
    public void CheckGUIElementLists(UnityEngine.Transform _transform);

    //GUI Element Object
    public void SetGUIElementObject(ENUM_GUIELEMENT_OBJECT_TYPE _type);
    public void OnGUIElementObject(ENUM_GUIELEMENT_OBJECT_TYPE _type);

    //GUI Element Text
    public void SetGUIElementText(ENUM_GUIELEMENT_TEXT_TYPE _type);
    public void OnGUIElementText(ENUM_GUIELEMENT_TEXT_TYPE _type);

    //GUI Element Button    
    public void OnGUIElementButton(IGUIElementButton _button, ENUM_GUIELEMENT_BUTTON_TYPE _buttonType, ENUM_GUIELEMENT_BUTTON_POINTER_TYPE _buttonPointerType);

    //GUI Element Slider
    public void SetGUIElementSlider();
    public void OnGUIElementSlider();

    //GUI Element Dropdown
    public void SetGUIElementDropdown(GUIElementDropdown _dropdown, ENUM_GUIELEMENT_DROPDOWN_TYPE _type);
    public void OnGUIElementDropdown(GUIElementDropdown _dropdown, ENUM_GUIELEMENT_DROPDOWN_TYPE _type);    
}



