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

//ADD LIBRARY
using APIGUI_Mar21st2023;

namespace APIGUI_Mar21st2023 {
    public enum ENUM_GUIELEMENT_TEXT_TYPE {
        HIGHSCORE,
        LIFE,
        SOMETHING
    }

    public enum ENUM_GUIELEMENT_DROPDOWN_TYPE {
        DISPLAY_SETTINGS
    }

    public class GUIManagerSettings {
        public const bool K_ENABLE_TOUCH = false; //def: false
    }

    public class GUIManager : MonoBehaviour, IGUIManager {
        void Start() {

        }

        void Update() {

        }

        public void InitGUI() { }

        public void OnDropdownSelected() { }

        public void OnTextChange() { }

        public void OnSliderChange() { }
    }
}


