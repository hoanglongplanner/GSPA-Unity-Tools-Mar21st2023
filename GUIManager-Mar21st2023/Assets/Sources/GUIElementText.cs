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

public class GUIElementText : MonoBehaviour, IGUIElementText {
    public ENUM_GUIELEMENT_TEXT_TYPE type;
    private TextMeshProUGUI m_TMPRO;
    private void Start() => m_TMPRO = this.GetComponent<TextMeshProUGUI>();
    public void SetText(string text) => m_TMPRO.SetText(text);
    public void SetColor(Color color) => m_TMPRO.color = color;
    public bool IsType(ENUM_GUIELEMENT_TEXT_TYPE compare) { return type == compare; }    
}


