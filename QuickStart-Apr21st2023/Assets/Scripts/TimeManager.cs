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

public class TimeManager : MonoBehaviour {
    class TimeConstants {
        public static readonly float[] K_TIME_ELAPSE = { 0, 100, 0 };
        public static readonly float[] K_TIME_LIMIT = { 0, 100, 0 };
        public const float K_TIME_ELAPSE_RATE = 1.0f;
        public const float K_TIME_LIMIT_RATE = 1.0f;
    }

    public enum ENUM_TIME_TYPE {
        K_TIME_ELAPSE,
        K_TIME_LIMIT,
        K_TIME_ELAPSE_CONDITION,
        K_TIME_LIMIT_CONDITION
    }
    
    float f_timeElapse;
    float f_timeLimit;

    bool isAllowTimeElapse = false;
    bool isAllowTimeLimit = false;

    private void Start() { }

    private void Update() { }

    public void ResetSpecificValueDefault(ENUM_TIME_TYPE _type) {
        switch (_type) {
            case ENUM_TIME_TYPE.K_TIME_ELAPSE: break;
            case ENUM_TIME_TYPE.K_TIME_LIMIT: break;
            case ENUM_TIME_TYPE.K_TIME_ELAPSE_CONDITION: break;
            case ENUM_TIME_TYPE.K_TIME_LIMIT_CONDITION: break;
            default: break;
        }
    }

    public void SetStatusAllowTimeElapse(bool _status) => isAllowTimeElapse = _status;
    public void SetStatusAllowTimeLimit(bool _status) => isAllowTimeLimit = _status;    

    public void SetTimeLimit(float _value) { }
    public void IncreaseTimeElapse() { 
        f_timeElapse += TimeConstants.K_TIME_ELAPSE_RATE;
        OnTimeValueChange(ENUM_TIME_TYPE.K_TIME_ELAPSE);
    }
    public void IncreaseTimeLimit() { }
    public void DecreaseTimeLimit() { }

    public void OnTimeValueChange(ENUM_TIME_TYPE _type) {
        switch (_type) {
            case ENUM_TIME_TYPE.K_TIME_ELAPSE: break;
            case ENUM_TIME_TYPE.K_TIME_LIMIT: break;
            case ENUM_TIME_TYPE.K_TIME_ELAPSE_CONDITION: break;
            case ENUM_TIME_TYPE.K_TIME_LIMIT_CONDITION: break;
            default: break;
        }
    }
}
