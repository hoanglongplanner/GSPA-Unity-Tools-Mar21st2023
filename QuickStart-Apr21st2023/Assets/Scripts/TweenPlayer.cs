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

public class TweenPlayer : MonoBehaviour {
    public enum ENUM_TWEEN_TYPE {
        K_GUI_NAVIGATION
    }

    public enum ENUM_TWEEN_GUI_DIRECTION {
        K_UP,
        K_DOWN,
        K_LEFT,
        K_RIGHT,
        K_UPLEFT
    }

    private ENUM_TWEEN_TYPE enum_tweenType;
    private bool isTweenComplete;

    public ENUM_TWEEN_TYPE GetTweenType() { return enum_tweenType; }

    public void PlayTween(ENUM_TWEEN_TYPE _type) {
        switch (_type) {
            case ENUM_TWEEN_TYPE.K_GUI_NAVIGATION: break;
            default: break;
        }
    }

    public void OnTweenComplete(ENUM_TWEEN_TYPE _type) {
        switch (_type) {
            case ENUM_TWEEN_TYPE.K_GUI_NAVIGATION: break;
            default: break;
        }
    }

    public void TweenGUI() {
        //UP DOWN LEFT RIGHT
        //FROM ANCHOR
    }

    public void TweenValueColor() {
        //TO NEW COLOUR        
    }
}
