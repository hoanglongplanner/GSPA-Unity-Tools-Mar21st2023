using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaviorStyleSwitchCase : MonoBehaviour {
    public enum ENUM_AI_ACTOR_TYPE {
        K_NPC,
        K_ALLY,
        K_THREAT
    }

    public enum ENUM_AIBEHAVIOR_STATE_TYPE {
        K_IDLE_WAIT,
        K_WANDER,
        K_PATROL,
        K_FOLLOW,
        K_ATTACK_MELEE,
        K_ATTACK_RANGE,
        K_DEFEND,
        K_EVADE,        
        K_DEATH
    }

    [SerializeField] private ENUM_AI_ACTOR_TYPE enum_aiActorType;
    [SerializeField] private ENUM_AIBEHAVIOR_STATE_TYPE enum_currentAIBehavior;
    [SerializeField] private ENUM_AIBEHAVIOR_STATE_TYPE enum_previousAIBehavior;
    [SerializeField] private bool isAISwitch = false;

    private void Update() {
        if (isAISwitch) return; //early-exit
        OnAIBehaviorLogicUpdate(enum_currentAIBehavior); //Update AI Behavior Every Frame
    }

    public ENUM_AI_ACTOR_TYPE GetAIActorType() { return enum_aiActorType; }
    public ENUM_AIBEHAVIOR_STATE_TYPE GetCurrentAIBehavior() { return enum_currentAIBehavior; }

    public void SetAIBehaviorType(ENUM_AIBEHAVIOR_STATE_TYPE _type) {

        if (_type == enum_currentAIBehavior) return; //early-exit, only allow switch to new state, not duplicate state

        OnAIBehaviorLogicEnd(enum_currentAIBehavior); //run last logic of current ai behavior before switch

        enum_previousAIBehavior = enum_currentAIBehavior; //archive previous ai behavior

        enum_currentAIBehavior = _type; //set new ai behavior

        OnAIBehaviorLogicStart(enum_currentAIBehavior); //run start logic of current new ai behavior
    }

    public void StartRandomBehavior() {
        int count = System.Enum.GetNames(typeof(ENUM_AIBEHAVIOR_STATE_TYPE)).Length;        
        SetAIBehaviorType((ENUM_AIBEHAVIOR_STATE_TYPE)Random.Range(0, count));
    }

    //--BEHAVIOR-TYPE--
    //Add all your logic behavior here
    public void OnAIBehaviorLogicStart(ENUM_AIBEHAVIOR_STATE_TYPE _type) {
        switch (_type) {
            case ENUM_AIBEHAVIOR_STATE_TYPE.K_IDLE_WAIT: break;
            case ENUM_AIBEHAVIOR_STATE_TYPE.K_WANDER: break;
            case ENUM_AIBEHAVIOR_STATE_TYPE.K_PATROL: break;
            case ENUM_AIBEHAVIOR_STATE_TYPE.K_FOLLOW: break;
            case ENUM_AIBEHAVIOR_STATE_TYPE.K_ATTACK_MELEE: break;
            case ENUM_AIBEHAVIOR_STATE_TYPE.K_ATTACK_RANGE: break;
            case ENUM_AIBEHAVIOR_STATE_TYPE.K_DEFEND: break;
            case ENUM_AIBEHAVIOR_STATE_TYPE.K_EVADE: break;
            case ENUM_AIBEHAVIOR_STATE_TYPE.K_DEATH: break;
            default: break;
        }
    }

    public void OnAIBehaviorLogicUpdate(ENUM_AIBEHAVIOR_STATE_TYPE _type) {
        switch (_type) {
            case ENUM_AIBEHAVIOR_STATE_TYPE.K_IDLE_WAIT: break;
            case ENUM_AIBEHAVIOR_STATE_TYPE.K_WANDER: break;
            case ENUM_AIBEHAVIOR_STATE_TYPE.K_PATROL: break;
            case ENUM_AIBEHAVIOR_STATE_TYPE.K_FOLLOW: break;
            case ENUM_AIBEHAVIOR_STATE_TYPE.K_ATTACK_MELEE: break;
            case ENUM_AIBEHAVIOR_STATE_TYPE.K_ATTACK_RANGE: break;
            case ENUM_AIBEHAVIOR_STATE_TYPE.K_DEFEND: break;
            case ENUM_AIBEHAVIOR_STATE_TYPE.K_EVADE: break;
            case ENUM_AIBEHAVIOR_STATE_TYPE.K_DEATH: break;
            default: break;
        }
    }

    public void OnAIBehaviorLogicEnd(ENUM_AIBEHAVIOR_STATE_TYPE _type) {
        switch (_type) {
            case ENUM_AIBEHAVIOR_STATE_TYPE.K_IDLE_WAIT: break;
            case ENUM_AIBEHAVIOR_STATE_TYPE.K_WANDER: break;
            case ENUM_AIBEHAVIOR_STATE_TYPE.K_PATROL: break;
            case ENUM_AIBEHAVIOR_STATE_TYPE.K_FOLLOW: break;
            case ENUM_AIBEHAVIOR_STATE_TYPE.K_ATTACK_MELEE: break;
            case ENUM_AIBEHAVIOR_STATE_TYPE.K_ATTACK_RANGE: break;
            case ENUM_AIBEHAVIOR_STATE_TYPE.K_DEFEND: break;
            case ENUM_AIBEHAVIOR_STATE_TYPE.K_EVADE: break;
            case ENUM_AIBEHAVIOR_STATE_TYPE.K_DEATH: break;
            default: break;
        }
    }
}
