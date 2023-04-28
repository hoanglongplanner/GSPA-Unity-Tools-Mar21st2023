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

public enum ENUM_ANIMATION_STATE_TYPE {
    K_IDLE,
    K_WALK,
    K_RUN,
    K_ATTACK_MELEE,
    K_ATTACK_RANGE,
    K_JUMP_UP,
    K_ON_AIR,
    K_JUMP_DOWN
}

[RequireComponent(typeof(Animator))]
public class AnimationPlayer : MonoBehaviour {    

    [SerializeField] private Animator m_animator;
    [SerializeField] private ENUM_ANIMATION_STATE_TYPE enum_currentAnim;
    [SerializeField] private ENUM_ANIMATION_STATE_TYPE enum_previousAnim;
    [SerializeField] private bool isAnimationDone = false;
    [SerializeField] private float f_animTime;

    private void Start() => m_animator = GetComponent<Animator>();

    public void PlayAnimation(ENUM_ANIMATION_STATE_TYPE _type) => StartCoroutine(RoutineAnimation(_type));

    public void PlayAnimationForce(ENUM_ANIMATION_STATE_TYPE type) {
        StopAllCoroutines();

        enum_previousAnim = type;
        enum_currentAnim = enum_previousAnim;

        StartCoroutine(RoutineAnimation(enum_currentAnim));
    }

    public void ResetAnimation() => PlayAnimationForce(ENUM_ANIMATION_STATE_TYPE.K_IDLE);

    public void StopAnimation() => m_animator.StopPlayback();

    public static string GetAnimationName(ENUM_ANIMATION_STATE_TYPE type) {
        switch (type) {
            case ENUM_ANIMATION_STATE_TYPE.K_IDLE: return "IDLE";
            case ENUM_ANIMATION_STATE_TYPE.K_RUN: return "RUN";
            case ENUM_ANIMATION_STATE_TYPE.K_JUMP_UP: return "JUMP_UP";
            case ENUM_ANIMATION_STATE_TYPE.K_ON_AIR: return "ON_AIR";
            case ENUM_ANIMATION_STATE_TYPE.K_JUMP_DOWN: return "JUMP_DOWN";
            default: Debug.Log("NO ANIMATION NAME OF THAT TYPE !!"); return "NONE";
        }
    }    

    private IEnumerator RoutineAnimation(ENUM_ANIMATION_STATE_TYPE _type) {        
        if (enum_currentAnim == enum_previousAnim) yield break;

        enum_previousAnim = enum_currentAnim; //Archive previous animation state
        enum_currentAnim = _type; //Change to new animation name

        isAnimationDone = false;

        m_animator.Play(GetAnimationName(enum_currentAnim));

        f_animTime = m_animator.GetCurrentAnimatorStateInfo(0).length; //get wait time

        yield return new WaitForSeconds(f_animTime); //wait

        isAnimationDone = true;

        yield return OnAnimationDone(enum_currentAnim); //recursion-continulous-loop
    }    

    private IEnumerator OnAnimationDone(ENUM_ANIMATION_STATE_TYPE type) {
        switch (type) {
            case ENUM_ANIMATION_STATE_TYPE.K_IDLE: StartCoroutine(RoutineAnimation(ENUM_ANIMATION_STATE_TYPE.K_IDLE)); break;
            case ENUM_ANIMATION_STATE_TYPE.K_WALK: break;
            case ENUM_ANIMATION_STATE_TYPE.K_RUN: StartCoroutine(RoutineAnimation(ENUM_ANIMATION_STATE_TYPE.K_RUN)); break;
            case ENUM_ANIMATION_STATE_TYPE.K_ATTACK_MELEE: break;
            case ENUM_ANIMATION_STATE_TYPE.K_ATTACK_RANGE: break;
            case ENUM_ANIMATION_STATE_TYPE.K_JUMP_UP: StartCoroutine(RoutineAnimation(ENUM_ANIMATION_STATE_TYPE.K_ON_AIR)); break;
            case ENUM_ANIMATION_STATE_TYPE.K_ON_AIR: break;
            case ENUM_ANIMATION_STATE_TYPE.K_JUMP_DOWN: StartCoroutine(RoutineAnimation(ENUM_ANIMATION_STATE_TYPE.K_RUN)); break;                        
            default: break;
        }

        yield break;
    }
}
