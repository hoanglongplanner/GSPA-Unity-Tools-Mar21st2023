using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationPlayer : MonoBehaviour {

    public enum ENUM_ANIMATION_TYPE {
        K_IDLE,
        K_WALK,
        K_RUN,
        K_ATTACK_MELEE,
        K_ATTACK_RANGE,
        K_JUMP_UP,
        K_ON_AIR,
        K_JUMP_DOWN
    }

    [SerializeField] private Animator m_animator;

    private void Start() => m_animator = GetComponent<Animator>();

    public void PlayAnimation(ENUM_ANIMATION_TYPE _type) {
        switch (_type) {
            case ENUM_ANIMATION_TYPE.K_IDLE: break;
            case ENUM_ANIMATION_TYPE.K_WALK: break;
            case ENUM_ANIMATION_TYPE.K_RUN: break;
            case ENUM_ANIMATION_TYPE.K_ATTACK_MELEE: break;
            case ENUM_ANIMATION_TYPE.K_ATTACK_RANGE: break;
            case ENUM_ANIMATION_TYPE.K_JUMP_UP: break;
            case ENUM_ANIMATION_TYPE.K_ON_AIR: break;
            case ENUM_ANIMATION_TYPE.K_JUMP_DOWN: break;
            default: break;
        }
    }

    public void ResetAnimation() { }

    public void StopAnimation() => m_animator.StopPlayback();
}
