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

using UnityEngine;

public class GUIElementText : MonoBehaviour {
    [SerializeField] private GUIManager m_guiManager;
    [SerializeField] private ENUM_GUIELEMENT_TEXT_TYPE enum_type;
    private TMPro.TextMeshProUGUI m_tmpro;
    public void SetGUIManager(GUIManager _guiManager) => m_guiManager = _guiManager;
    public void Setup() => m_tmpro = this.GetComponent<TMPro.TextMeshProUGUI>();
    public bool IsType(ENUM_GUIELEMENT_TEXT_TYPE _type) { return _type == enum_type; }
    public ENUM_GUIELEMENT_TEXT_TYPE GetTypeText() { return enum_type; }
    public void SetText(string input) => m_tmpro.text = input;
}
