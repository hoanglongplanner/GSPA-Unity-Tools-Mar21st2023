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

public class AutoSetTransformPosition : MonoBehaviour {
    [SerializeField] private Transform m_targetTransform;
    [SerializeField] private bool isUpdateEveryFrame = false;

    private void Start() => IsHandleError();

    private void Update() {        
        if (isUpdateEveryFrame) UpdatePosition();
    }

    private void FixedUpdate() {        
        if (isUpdateEveryFrame == false) UpdatePosition();
    }

    private bool IsHandleError() {
        if (m_targetTransform == null) {
            Debug.LogError("Transform not found !! Abort auto set position", this);
            return true; 
        }
        return false;
    }    

    private void UpdatePosition() {
        if (IsHandleError()) return; //safe-check
        this.transform.position = m_targetTransform.position; 
    }

    public void SetTargetTransform(Transform _transform) => m_targetTransform = _transform;
    public void SetStatusUpdatePosEveryFrame(bool _status) => isUpdateEveryFrame = _status;
}
