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

public class GUIElementObject : UnityEngine.MonoBehaviour {
    public ENUM_GUIELEMENT_OBJECT_TYPE enum_type;
    public bool IsType(ENUM_GUIELEMENT_OBJECT_TYPE _type) { return _type == enum_type; }
    public bool IsActive() { return isActiveAndEnabled; }
    public void SetStatusObjectActive(bool _status) { this.gameObject.SetActive(_status); }
}
