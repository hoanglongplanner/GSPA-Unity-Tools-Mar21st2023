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
    public System.Collections.Generic.List<GUIElementText> GetAllTypeGUIElementText(ENUM_GUIELEMENT_TEXT_TYPE type);

    //Functions
    public void InitGUI();
    public void UpdateText(ENUM_GUIELEMENT_TEXT_TYPE type);
    public void OnTextChange(ENUM_GUIELEMENT_TEXT_TYPE type);
    public void OnButtonBehavior();
    public void CreateSlider();
    public void OnSliderChange();
    public void CreateDropdown(GUIElementDropdown elementDropdown, ENUM_GUIELEMENT_DROPDOWN_TYPE type);
    public void OnDropdownSelected(GUIElementDropdown elementDropdown, ENUM_GUIELEMENT_DROPDOWN_TYPE type);    
}



