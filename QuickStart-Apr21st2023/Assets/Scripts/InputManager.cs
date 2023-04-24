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

using System;
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

    class HotkeySingle {
        private ENUM_INPUT_CONTEXT_FUNCTION enum_contextType;
        private KeyCode[] sz_m_keycode;

        public HotkeySingle(ENUM_INPUT_CONTEXT_FUNCTION _contextType, KeyCode[] _keyCode) {
            enum_contextType = _contextType;
            sz_m_keycode = _keyCode;
        }

        public ENUM_INPUT_CONTEXT_FUNCTION GetTypeContextFunction() { return enum_contextType; }
        public KeyCode[] GetArrayKeycode() { return sz_m_keycode; }
    }

    class HotkeyCombination {
        private ENUM_INPUT_CONTEXT_FUNCTION enum_contextType;
        private KeyCode[] sz_m_keycode;
        private bool isPressSucessful = false;

        public HotkeyCombination(ENUM_INPUT_CONTEXT_FUNCTION _contextType, KeyCode[] _keyCode) {
            enum_contextType = _contextType;
            sz_m_keycode = _keyCode;
        }

        public ENUM_INPUT_CONTEXT_FUNCTION GetTypeContextFunction() { return enum_contextType; }
        public KeyCode[] GetArrayKeycode() { return sz_m_keycode; }
                
        public bool IsAnyOtherKeyPressed() {
            foreach (KeyCode keyCode in sz_m_keycode) {
                if (Input.GetKey(keyCode)) 
                    return true; //return-result-there-are-other-key
            }
            return false; //return-none
        }
    }

    private HotkeySingle[] sz_m_hotkeySingle = new HotkeySingle[] {
        new HotkeySingle(ENUM_INPUT_CONTEXT_FUNCTION.K_MOVE_UP, new KeyCode[]{ KeyCode.W, KeyCode.UpArrow}),
        new HotkeySingle(ENUM_INPUT_CONTEXT_FUNCTION.K_MOVE_DOWN, new KeyCode[]{ KeyCode.S, KeyCode.DownArrow}),
        new HotkeySingle(ENUM_INPUT_CONTEXT_FUNCTION.K_MOVE_LEFT, new KeyCode[]{ KeyCode.A, KeyCode.LeftArrow}),
        new HotkeySingle(ENUM_INPUT_CONTEXT_FUNCTION.K_MOVE_RIGHT, new KeyCode[]{ KeyCode.D, KeyCode.RightArrow}),
        new HotkeySingle(ENUM_INPUT_CONTEXT_FUNCTION.K_PAUSE_GAME, new KeyCode[]{ KeyCode.Escape, KeyCode.P}),
    };

    private HotkeyCombination[] sz_m_hotkeyCombination = new HotkeyCombination[] {
        new HotkeyCombination(ENUM_INPUT_CONTEXT_FUNCTION.K_MOVE_UP, new KeyCode[]{ KeyCode.W, KeyCode.UpArrow}),
        new HotkeyCombination(ENUM_INPUT_CONTEXT_FUNCTION.K_MOVE_DOWN, new KeyCode[]{ KeyCode.S, KeyCode.DownArrow}),        
    };

    public Vector3 vec3_mousePos;
    [SerializeField] private bool isClickTapOnce = false;
    [SerializeField] private bool isAllowHotkeyCombination = false;
    [SerializeField] private bool isAllowInput = true;

    private void Awake() {
        KeyCode[] allKeys = (KeyCode[])Enum.GetValues(typeof(KeyCode));
    }

    private void Start() {
        
    }

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

    private void CheckActiveKeyboardKeys() {
        //GetAllAvailableKeyInList
        //SetTrueToSpecificKeys
        //ResetListOfActiveKeys
    }

    public void UpdateInputMouse() {
        vec3_mousePos = Input.mousePosition; //Get position from Mouse Position

        //Add and replace all the input here
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)) HandleLogicClickTap();
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2)) HandleLogicClickTap();
        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(2)) HandleLogicRelease();
    }

    public void UpdateInputKeyboard() {        

        //Performance Concern, may better than Dictionary method
        foreach(HotkeySingle temp in sz_m_hotkeySingle) {
            foreach(KeyCode keyCode in temp.GetArrayKeycode()) {
                if (Input.GetKeyDown(keyCode)) HandleKeyboardEvent(ENUM_INPUT_TYPE.K_PRESS, temp.GetTypeContextFunction());
                //if (Input.GetKey(keyCode)) HandleKeyboardEvent(ENUM_INPUT_TYPE.K_HOLD, temp.GetTypeContextFunction());
                if (Input.GetKeyUp(keyCode)) HandleKeyboardEvent(ENUM_INPUT_TYPE.K_RELEASE, temp.GetTypeContextFunction());
            }
        }

        if (isAllowHotkeyCombination == false) return; //check-functionality
        foreach (HotkeyCombination temp in sz_m_hotkeyCombination) {
            foreach (KeyCode keyCode in temp.GetArrayKeycode()) {
                if (Input.GetKeyDown(keyCode)) HandleKeyboardEvent(ENUM_INPUT_TYPE.K_PRESS, temp.GetTypeContextFunction());                
                if (Input.GetKeyUp(keyCode)) HandleKeyboardEvent(ENUM_INPUT_TYPE.K_RELEASE, temp.GetTypeContextFunction());
            }
        }
    }

    //TODO Include support for controller
    //not sure how to do this yet
    public void UpdateInputController() { }

    public void UpdateInputTouch() {
        if (UnityEngine.Input.touchCount == 1) {

            UnityEngine.Touch touch = UnityEngine.Input.touches[0]; //Only get the touch from touches 0
            vec3_mousePos = touch.position; //Get position from Touch, if detect one touch input

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

    public void HandleKeyboardEvent(ENUM_INPUT_TYPE _inputType, ENUM_INPUT_CONTEXT_FUNCTION _contextType) {
        switch (_inputType) {
            case ENUM_INPUT_TYPE.K_PRESS:
                switch (_contextType) {
                    case ENUM_INPUT_CONTEXT_FUNCTION.K_MOVE_UP:
                        Debug.Log("Move up once");
                        break;
                    case ENUM_INPUT_CONTEXT_FUNCTION.K_MOVE_DOWN: break;
                    case ENUM_INPUT_CONTEXT_FUNCTION.K_MOVE_LEFT: break;
                    case ENUM_INPUT_CONTEXT_FUNCTION.K_MOVE_RIGHT: break;
                    case ENUM_INPUT_CONTEXT_FUNCTION.K_CONFIRM: break;
                    case ENUM_INPUT_CONTEXT_FUNCTION.K_CANCEL: break;
                    case ENUM_INPUT_CONTEXT_FUNCTION.K_USE: break;
                    case ENUM_INPUT_CONTEXT_FUNCTION.K_MELEE: break;
                    case ENUM_INPUT_CONTEXT_FUNCTION.K_OPEN_INVENTORY: break;
                    case ENUM_INPUT_CONTEXT_FUNCTION.K_PAUSE_GAME: break;
                    default: break;
                }
                break;
            case ENUM_INPUT_TYPE.K_HOLD:
                switch (_contextType) {
                    case ENUM_INPUT_CONTEXT_FUNCTION.K_MOVE_UP:
                        Debug.Log("Move up hold");
                        break;
                    case ENUM_INPUT_CONTEXT_FUNCTION.K_MOVE_DOWN: break;
                    case ENUM_INPUT_CONTEXT_FUNCTION.K_MOVE_LEFT: break;
                    case ENUM_INPUT_CONTEXT_FUNCTION.K_MOVE_RIGHT: break;
                    case ENUM_INPUT_CONTEXT_FUNCTION.K_CONFIRM: break;
                    case ENUM_INPUT_CONTEXT_FUNCTION.K_CANCEL: break;
                    case ENUM_INPUT_CONTEXT_FUNCTION.K_USE: break;
                    case ENUM_INPUT_CONTEXT_FUNCTION.K_MELEE: break;
                    case ENUM_INPUT_CONTEXT_FUNCTION.K_OPEN_INVENTORY: break;
                    case ENUM_INPUT_CONTEXT_FUNCTION.K_PAUSE_GAME: break;
                    default: break;
                }
                break;
            case ENUM_INPUT_TYPE.K_RELEASE:
                switch (_contextType) {
                    case ENUM_INPUT_CONTEXT_FUNCTION.K_MOVE_UP:
                        Debug.Log("Move up release");
                        break;
                    case ENUM_INPUT_CONTEXT_FUNCTION.K_MOVE_DOWN: break;
                    case ENUM_INPUT_CONTEXT_FUNCTION.K_MOVE_LEFT: break;
                    case ENUM_INPUT_CONTEXT_FUNCTION.K_MOVE_RIGHT: break;
                    case ENUM_INPUT_CONTEXT_FUNCTION.K_CONFIRM: break;
                    case ENUM_INPUT_CONTEXT_FUNCTION.K_CANCEL: break;
                    case ENUM_INPUT_CONTEXT_FUNCTION.K_USE: break;
                    case ENUM_INPUT_CONTEXT_FUNCTION.K_MELEE: break;
                    case ENUM_INPUT_CONTEXT_FUNCTION.K_OPEN_INVENTORY: break;
                    case ENUM_INPUT_CONTEXT_FUNCTION.K_PAUSE_GAME: break;
                    default: break;
                }
                break;
            default:
                break;
        }
    }
}
