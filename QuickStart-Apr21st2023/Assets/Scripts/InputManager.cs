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

public class InputManager : MonoBehaviour {
    public enum ENUM_INPUT_CONTEXT_FUNCTION {
        K_MOVE_UP,
        K_MOVE_DOWN,
        K_MOVE_LEFT,
        K_MOVE_RIGHT,                
        K_CONFIRM,
        K_CANCEL,
        K_USE,
        K_MELEE,
        K_OPEN_INVENTORY,
        K_PAUSE_GAME
    }

    public enum ENUM_INPUT_TYPE {
        K_PRESS,
        K_HOLD,
        K_RELEASE
    }

    public Vector3 vec3_pos;
    [SerializeField] private bool isClickTapOnce = false;
    [SerializeField] private bool isAllowInput = true;

    private void Start() => DisableInputTemporary();

    void Update() {
        if (isAllowInput == false) return; //early-exit
        UpdateInputMouse();
        UpdateInputKeyboard();
        UpdateInputTouch();
    }

    public bool IsAllowInput() { return isAllowInput; }

    public void SetStatusDisableInput(bool _status) => isAllowInput = _status;

    public void DisableInputTemporary(float _disableTime = 3.0f) {
        StopCoroutine(RoutineDisableInputTemporary()); //Stop-stacking-on-this-Monobehavior
        StartCoroutine(RoutineDisableInputTemporary(_disableTime));
    }

    private IEnumerator RoutineDisableInputTemporary(float _disableTime = 3.0f) {
        isAllowInput = false;
        yield return new WaitForSeconds(_disableTime);
        isAllowInput = true;
    }

    public void UpdateInputMouse() {
        vec3_pos = Input.mousePosition; //Get position from Mouse Position

        //Add and replace all the input here
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)) HandleLogicClickTap();
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2)) HandleLogicClickTap();
        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(2)) HandleLogicRelease();
    }

    public void UpdateInputKeyboard() {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) HandleLogicKeystroke(ENUM_INPUT_TYPE.K_PRESS, ENUM_INPUT_CONTEXT_FUNCTION.K_MOVE_UP);
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) HandleLogicKeystroke(ENUM_INPUT_TYPE.K_PRESS, ENUM_INPUT_CONTEXT_FUNCTION.K_MOVE_DOWN);
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) HandleLogicKeystroke(ENUM_INPUT_TYPE.K_PRESS, ENUM_INPUT_CONTEXT_FUNCTION.K_MOVE_LEFT);
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) HandleLogicKeystroke(ENUM_INPUT_TYPE.K_PRESS, ENUM_INPUT_CONTEXT_FUNCTION.K_MOVE_RIGHT);
        if (Input.GetKeyDown(KeyCode.Z)) { }
        if (Input.GetKeyDown(KeyCode.X)) { }
        if (Input.GetKeyDown(KeyCode.E)) { }
        if (Input.GetKeyDown(KeyCode.F)) { }
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) HandleLogicKeystroke(ENUM_INPUT_TYPE.K_PRESS, ENUM_INPUT_CONTEXT_FUNCTION.K_PAUSE_GAME);
    }

    public void UpdateInputController() {
        
    }

    public void UpdateInputTouch() {
        if (UnityEngine.Input.touchCount == 1) {

            UnityEngine.Touch touch = UnityEngine.Input.touches[0]; //Only get the touch from touches 0
            vec3_pos = touch.position; //Get position from Touch, if detect one touch input

            switch (touch.phase) {
                case TouchPhase.Began: HandleLogicClickTap(); break;
                case TouchPhase.Stationary: HandleLogicHoldStationary(); break;
                case TouchPhase.Ended: HandleLogicRelease(); break;
                case TouchPhase.Moved: break;
                case TouchPhase.Canceled: break;
                default: break;
            }
        }
    }

    public void HandleLogicClickTap() {
        if (isClickTapOnce == true) return;
        isClickTapOnce = true;

        //Insert-Logic-Here
    }

    public void HandleLogicHoldStationary() {
        //Insert-Logic-Here
    }

    public void HandleLogicRelease() {
        isClickTapOnce = false;

        //Insert-Logic-Here
    }

    public void HandleLogicKeystroke(ENUM_INPUT_TYPE _inputType, ENUM_INPUT_CONTEXT_FUNCTION _contextType) {
        switch (_inputType) {
            case ENUM_INPUT_TYPE.K_PRESS:
                break;
            case ENUM_INPUT_TYPE.K_HOLD:
                break;
            case ENUM_INPUT_TYPE.K_RELEASE:
                break;
            default:
                break;
        }
    }    
}
