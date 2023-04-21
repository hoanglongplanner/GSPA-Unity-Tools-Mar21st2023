using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ComponentTag), typeof(Rigidbody))]
public class ComponentCollisionRespond : MonoBehaviour {
    private ComponentTag m_componentTag;
    private void Start() => m_componentTag = this.GetComponent<ComponentTag>();

    private bool IsSetupError(GameObject _gameObject) {
        bool status = false;
        if (_gameObject.GetComponent<ComponentTag>() == null) {
            Debug.Log("WARN Collision Respond with objects has no TAG, safe exit");
            status = true;
        }
        if (_gameObject.GetComponent<Rigidbody>() == null) {
            Debug.Log("WARN Collision Respond with objects has no RIGIDBODY, safe exit");
            status = true;
        }
        if (status) return true; //return-result-error-if-encounter
        return false; //return-result-if-no-errors
    }

    //--UNITY COLLISION TYPES--
    //DO NOT EDIT UNLESS NECCESSARY

    private void OnCollisionEnter2D(Collision2D collision) {
        if (IsSetupError(collision.gameObject)) return; //safe-check-early-exit
        OnCollisionRespondEnter(collision.gameObject, m_componentTag.GetTagType(), collision.gameObject.GetComponent<ComponentTag>().GetTagType());
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (IsSetupError(collision.gameObject)) return; //safe-check-early-exit
        OnCollisionRespondStay(collision.gameObject, m_componentTag.GetTagType(), collision.gameObject.GetComponent<ComponentTag>().GetTagType());
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (IsSetupError(collision.gameObject)) return; //safe-check-early-exit
        OnCollisionRespondExit(collision.gameObject, m_componentTag.GetTagType(), collision.gameObject.GetComponent<ComponentTag>().GetTagType());
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (IsSetupError(collision.gameObject)) return; //safe-check-early-exit
        OnCollisionRespondEnter(collision.gameObject, m_componentTag.GetTagType(), collision.gameObject.GetComponent<ComponentTag>().GetTagType());
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (IsSetupError(collision.gameObject)) return; //safe-check-early-exit
        OnCollisionRespondStay(collision.gameObject, m_componentTag.GetTagType(), collision.gameObject.GetComponent<ComponentTag>().GetTagType());
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (IsSetupError(collision.gameObject)) return; //safe-check-early-exit
        OnCollisionRespondExit(collision.gameObject, m_componentTag.GetTagType(), collision.gameObject.GetComponent<ComponentTag>().GetTagType());
    }

    private void OnCollisionEnter(Collision collision) {
        if (IsSetupError(collision.gameObject)) return; //safe-check-early-exit
        OnCollisionRespondEnter(collision.gameObject, m_componentTag.GetTagType(), collision.gameObject.GetComponent<ComponentTag>().GetTagType());
    }

    private void OnCollisionStay(Collision collision) {
        if (IsSetupError(collision.gameObject)) return; //safe-check-early-exit
        OnCollisionRespondStay(collision.gameObject, m_componentTag.GetTagType(), collision.gameObject.GetComponent<ComponentTag>().GetTagType());
    }

    private void OnCollisionExit(Collision collision) {
        if (IsSetupError(collision.gameObject)) return; //safe-check-early-exit
        OnCollisionRespondExit(collision.gameObject, m_componentTag.GetTagType(), collision.gameObject.GetComponent<ComponentTag>().GetTagType());        
    }
    
    private void OnTriggerEnter(Collider other) {
        if (IsSetupError(other.gameObject)) return; //safe-check-early-exit
        OnCollisionRespondEnter(other.gameObject, m_componentTag.GetTagType(), other.GetComponent<ComponentTag>().GetTagType());
    }
    
    private void OnTriggerStay(Collider other) {
        if (IsSetupError(other.gameObject)) return; //safe-check-early-exit
        OnCollisionRespondStay(other.gameObject, m_componentTag.GetTagType(), other.GetComponent<ComponentTag>().GetTagType());
    }
    
    private void OnTriggerExit(Collider other) {
        if (IsSetupError(other.gameObject)) return; //safe-check-early-exit
        OnCollisionRespondExit(other.gameObject, m_componentTag.GetTagType(), other.GetComponent<ComponentTag>().GetTagType());
    }

    //--CUSTOM COLLISION RESPOND--
    //ALLOW EDIT

    private void OnCollisionRespondEnter(GameObject _gameObject, ENUM_TAG_TYPE _type, ENUM_TAG_TYPE _compareTag) {
        switch (_type) {
            case ENUM_TAG_TYPE.K_PLAYER: break;
            case ENUM_TAG_TYPE.K_THREAT: break;
            default: return; //safe-check                
        }
    }

    private void OnCollisionRespondStay(GameObject _gameObject, ENUM_TAG_TYPE _type, ENUM_TAG_TYPE _compareTag) {
        switch (_type) {
            case ENUM_TAG_TYPE.K_PLAYER: break;
            case ENUM_TAG_TYPE.K_THREAT: break;
            default: return; //safe-check                
        }
    }

    private void OnCollisionRespondExit(GameObject _gameObject, ENUM_TAG_TYPE _type, ENUM_TAG_TYPE _compareTag) {
        switch (_type) {
            case ENUM_TAG_TYPE.K_PLAYER: break;
            case ENUM_TAG_TYPE.K_THREAT: break;
            default: return; //safe-check                
        }
    }
}
