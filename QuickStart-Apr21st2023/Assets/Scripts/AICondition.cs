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
using UnityEngine.Serialization;

public class AICondition : MonoBehaviour {

    [FormerlySerializedAs("Player Distance"), SerializeField] private float f_playerDistance;
    [SerializeField] private bool isPlayerInCloseArea;
    [FormerlySerializedAs("Wait Time"), SerializeField] private float f_waitTime;
    [FormerlySerializedAs("Alert Time"), SerializeField] private float f_alertTime;

    public enum ENUM_AICORE_CONDITION_TYPE {
        IS_PLAYER_IN_LOS, //Line Of Sight
        IS_PLAYER_IN_ATTACK_RANGE,
        IS_PLAYER_NOT_IN_LOS, //Line Of Sight
        IS_PLAYER_NOT_IN_ATTACK_RANGE,
        IS_ANIMATION_DONE
    }

    public enum ENUM_FSM_CONDITION_TYPE {
        IsPlayerInLOS,
        IsPlayerInAttackRange,
        IsWaitTimeExceed,
        IsPlayerNotInLOS,
        IsPlayerNotInAttackRange,
        IsAnimationDone
    }

    public bool GetStatusAICondition(ENUM_AICORE_CONDITION_TYPE _type) {
        switch (_type) {
            case ENUM_AICORE_CONDITION_TYPE.IS_PLAYER_IN_LOS: return false;
            case ENUM_AICORE_CONDITION_TYPE.IS_PLAYER_IN_ATTACK_RANGE: return false;
            case ENUM_AICORE_CONDITION_TYPE.IS_PLAYER_NOT_IN_LOS: return false;
            case ENUM_AICORE_CONDITION_TYPE.IS_PLAYER_NOT_IN_ATTACK_RANGE: return false;
            default: Debug.Log("Unknown AI Condition Detected !!"); return false;
        }
    }

    private void FixedUpdate() {
        
    }

    public void ResetWaitTime() => f_waitTime = 0.0f;
}
