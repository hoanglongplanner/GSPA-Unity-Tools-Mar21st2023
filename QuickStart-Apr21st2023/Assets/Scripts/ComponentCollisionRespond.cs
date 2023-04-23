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

public enum ENUM_COLLISION_RESPOND_TYPE {
    K_PLAYER,
    K_THREAT
}

[RequireComponent(typeof(ComponentTag), typeof(Rigidbody))]
public class ComponentCollisionRespond : MonoBehaviour {
    //TODO Remove Component TAG
    private ComponentTag m_componentTag;
    [SerializeField] private ENUM_COLLISION_RESPOND_TYPE enum_collisionRespond;
    private void Start() { 
        m_componentTag = this.GetComponent<ComponentTag>();
        IsHandleErrorCollisionObject(this.gameObject);
    }

    //TODO Remove
    private bool IsHandleError(GameObject _gameObject) {
        bool status = false;
        if (_gameObject.GetComponent<ComponentCollisionRespond>() == null) {
            Debug.LogError("ERROR Object has no Component Collision Respond, safe exit");            
            status = true;
        }
        if (_gameObject.GetComponent<Rigidbody>() == null) {
            Debug.LogError("WARN Collision Respond with objects has no RIGIDBODY, safe exit");
            status = true;
        }
        if (status) return true; //return-error
        return false; //return-no-errors
    }

    //TODO Rename    
    private bool IsHandleErrorCollisionObject(GameObject _gameObject) {
        if (IsHandleErrorNoComponentCollisionRespond(_gameObject)) return true; //return-error
        if (IsHandleErrorNoRigidbody(_gameObject)) return true; //return-error
        return false; //return-no-errors
    }

    private bool IsHandleErrorNoComponentCollisionRespond(GameObject _gameObject) {        
        if (_gameObject.GetComponent<ComponentCollisionRespond>() == null) {
            Debug.LogError("ERROR No ComponentCollisionRespond, safe exit");
            return true; //return-error
        }                
        return false; //return-no-errors
    }

    private bool IsHandleErrorNoRigidbody(GameObject _gameObject) {        
        if (_gameObject.GetComponent<Rigidbody>() == null) {
            Debug.LogError("ERROR No RIGIDBODY, safe exit");
            return true; //return-error
        }        
        return false; //return-no-errors
    }

    public ENUM_COLLISION_RESPOND_TYPE GetCollisionRespondType() { return enum_collisionRespond; }
    public bool IsCollisionRespondType(ENUM_COLLISION_RESPOND_TYPE _type) { return enum_collisionRespond == _type; }

    //--UNITY COLLISION TYPES--
    //DO NOT EDIT UNLESS NECCESSARY

    private void OnCollisionEnter2D(Collision2D collision) => OnCollisionRespondEnter(collision.gameObject, collision.gameObject.GetComponent<ComponentTag>().GetTagType());
    private void OnCollisionStay2D(Collision2D collision) => OnCollisionRespondStay(collision.gameObject, collision.gameObject.GetComponent<ComponentTag>().GetTagType());
    private void OnCollisionExit2D(Collision2D collision) => OnCollisionRespondExit(collision.gameObject, collision.gameObject.GetComponent<ComponentTag>().GetTagType());

    private void OnTriggerEnter2D(Collider2D collision) => OnCollisionRespondEnter(collision.gameObject, collision.gameObject.GetComponent<ComponentTag>().GetTagType());
    private void OnTriggerStay2D(Collider2D collision) => OnCollisionRespondStay(collision.gameObject, collision.gameObject.GetComponent<ComponentTag>().GetTagType());
    private void OnTriggerExit2D(Collider2D collision) => OnCollisionRespondExit(collision.gameObject, collision.gameObject.GetComponent<ComponentTag>().GetTagType());

    private void OnCollisionEnter(Collision collision) => OnCollisionRespondEnter(collision.gameObject, collision.gameObject.GetComponent<ComponentTag>().GetTagType());
    private void OnCollisionStay(Collision collision) => OnCollisionRespondStay(collision.gameObject, collision.gameObject.GetComponent<ComponentTag>().GetTagType());
    private void OnCollisionExit(Collision collision) => OnCollisionRespondExit(collision.gameObject, collision.gameObject.GetComponent<ComponentTag>().GetTagType());

    private void OnTriggerEnter(Collider other) => OnCollisionRespondEnter(other.gameObject, other.GetComponent<ComponentTag>().GetTagType());
    private void OnTriggerStay(Collider other) => OnCollisionRespondStay(other.gameObject, other.GetComponent<ComponentTag>().GetTagType());
    private void OnTriggerExit(Collider other) => OnCollisionRespondExit(other.gameObject, other.GetComponent<ComponentTag>().GetTagType());

    //--CUSTOM COLLISION RESPOND--
    //ALLOW EDIT

    private void OnCollisionRespondEnter(GameObject _gameObject, ENUM_TAG_TYPE _compareTag) {
        if (IsHandleError(_gameObject)) return; //safe-check
        switch (m_componentTag.GetTagType()) {
            case ENUM_TAG_TYPE.K_PLAYER:
                switch (_compareTag) {
                    case ENUM_TAG_TYPE.K_PLAYER: break;
                    case ENUM_TAG_TYPE.K_THREAT: break;
                    default: break;
                }
                break;
            case ENUM_TAG_TYPE.K_THREAT: break;
            default: return; //safe-check                
        }
    }

    private void OnCollisionRespondStay(GameObject _gameObject, ENUM_TAG_TYPE _compareTag) {
        if (IsHandleError(_gameObject)) return; //safe-check
        switch (m_componentTag.GetTagType()) {
            case ENUM_TAG_TYPE.K_PLAYER:
                switch (_compareTag) {
                    case ENUM_TAG_TYPE.K_PLAYER: break;
                    case ENUM_TAG_TYPE.K_THREAT: break;
                    default: break;
                }
                break;
            case ENUM_TAG_TYPE.K_THREAT: break;
            default: return; //safe-check                
        }
    }

    private void OnCollisionRespondExit(GameObject _gameObject, ENUM_TAG_TYPE _compareTag) {
        if (IsHandleError(_gameObject)) return; //safe-check
        switch (m_componentTag.GetTagType()) {
            case ENUM_TAG_TYPE.K_PLAYER:
                switch (_compareTag) {
                    case ENUM_TAG_TYPE.K_PLAYER: break;
                    case ENUM_TAG_TYPE.K_THREAT: break;
                    default: break;
                }
                break;
            case ENUM_TAG_TYPE.K_THREAT: break;
            default: return; //safe-check                
        }
    }
}
