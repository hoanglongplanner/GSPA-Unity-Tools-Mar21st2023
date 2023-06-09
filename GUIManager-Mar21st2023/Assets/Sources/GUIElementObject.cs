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

public class GUIElementObject : MonoBehaviour, IGUIElementObject {
    [SerializeField] private IGUIManager m_guiManager;
    [SerializeField] private ENUM_GUIELEMENT_OBJECT_TYPE enum_type;
    public void SetGUIManager(IGUIManager _guiManager) => m_guiManager = _guiManager;
    public bool IsType(ENUM_GUIELEMENT_OBJECT_TYPE type) { return enum_type == type; }
    public bool GetActiveStatus() { return this.gameObject.activeInHierarchy; }
    public void SetActive(bool status) { 
        this.gameObject.SetActive(status);
        OnGUIElementObject(enum_type); //run-behavior
    }
    public void OnGUIElementObject(ENUM_GUIELEMENT_OBJECT_TYPE _type) => m_guiManager.OnGUIElementObject(_type);
}
