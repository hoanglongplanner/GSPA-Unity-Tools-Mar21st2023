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

[RequireComponent(typeof(Rigidbody))]
public class CollisionRespond : MonoBehaviour {
    public enum ENUM_COLLISION_RESPOND_TYPE {
        K_PLAYER,
        K_THREAT
    }

    [SerializeField] private ENUM_COLLISION_RESPOND_TYPE enum_collisionRespond;

    private void Start() => IsHandleErrorStartSetup();

    //--EXTERNAL-FUNCTIONS
    public ENUM_COLLISION_RESPOND_TYPE GetCollisionRespondType() { return enum_collisionRespond; }
    public bool IsCollisionRespondType(ENUM_COLLISION_RESPOND_TYPE _type) { return enum_collisionRespond == _type; }    

    //--UNITY COLLISION TYPES--
    //DO NOT EDIT UNLESS NECCESSARY

    private void OnCollisionEnter2D(Collision2D collision) => OnCollisionRespondEnter(collision.gameObject, collision.gameObject.GetComponent<ComponentTagLayer>().GetTagType());
    private void OnCollisionStay2D(Collision2D collision) => OnCollisionRespondStay(collision.gameObject, collision.gameObject.GetComponent<ComponentTagLayer>().GetTagType());
    private void OnCollisionExit2D(Collision2D collision) => OnCollisionRespondExit(collision.gameObject, collision.gameObject.GetComponent<ComponentTagLayer>().GetTagType());

    private void OnTriggerEnter2D(Collider2D collision) => OnCollisionRespondEnter(collision.gameObject, collision.gameObject.GetComponent<ComponentTagLayer>().GetTagType());
    private void OnTriggerStay2D(Collider2D collision) => OnCollisionRespondStay(collision.gameObject, collision.gameObject.GetComponent<ComponentTagLayer>().GetTagType());
    private void OnTriggerExit2D(Collider2D collision) => OnCollisionRespondExit(collision.gameObject, collision.gameObject.GetComponent<ComponentTagLayer>().GetTagType());

    private void OnCollisionEnter(Collision collision) => OnCollisionRespondEnter(collision.gameObject, collision.gameObject.GetComponent<ComponentTagLayer>().GetTagType());
    private void OnCollisionStay(Collision collision) => OnCollisionRespondStay(collision.gameObject, collision.gameObject.GetComponent<ComponentTagLayer>().GetTagType());
    private void OnCollisionExit(Collision collision) => OnCollisionRespondExit(collision.gameObject, collision.gameObject.GetComponent<ComponentTagLayer>().GetTagType());

    private void OnTriggerEnter(Collider other) => OnCollisionRespondEnter(other.gameObject, other.GetComponent<ComponentTagLayer>().GetTagType());
    private void OnTriggerStay(Collider other) => OnCollisionRespondStay(other.gameObject, other.GetComponent<ComponentTagLayer>().GetTagType());
    private void OnTriggerExit(Collider other) => OnCollisionRespondExit(other.gameObject, other.GetComponent<ComponentTagLayer>().GetTagType());

    //--CUSTOM COLLISION RESPOND--
    //ALLOW EDIT

    private void OnCollisionRespondEnter(GameObject _gameObject, ENUM_TAG_TYPE _compareTag) {
        if (IsHandleErrorCollisionObject(_gameObject)) return; //safe-check

        switch (this.GetCollisionRespondType()) {
            case ENUM_COLLISION_RESPOND_TYPE.K_PLAYER: break;
            case ENUM_COLLISION_RESPOND_TYPE.K_THREAT: break;
            default: break;
        }
    }

    private void OnCollisionRespondStay(GameObject _gameObject, ENUM_TAG_TYPE _compareTag) {
        if (IsHandleErrorCollisionObject(_gameObject)) return; //safe-check

        switch (this.GetCollisionRespondType()) {
            case ENUM_COLLISION_RESPOND_TYPE.K_PLAYER: break;
            case ENUM_COLLISION_RESPOND_TYPE.K_THREAT: break;
            default: break;
        }
    }

    private void OnCollisionRespondExit(GameObject _gameObject, ENUM_TAG_TYPE _compareTag) {
        if (IsHandleErrorCollisionObject(_gameObject)) return; //safe-check

        switch (this.GetCollisionRespondType()) {
            case ENUM_COLLISION_RESPOND_TYPE.K_PLAYER: break;
            case ENUM_COLLISION_RESPOND_TYPE.K_THREAT: break;
            default: break;
        }
    }

    //--HANDLING-ERROR-NULL-REFERENCE--
    //Checking error
    private bool IsHandleErrorStartSetup() {
        IsHandleErrorCollisionObject(this.gameObject); //return-error-if-encounter
        return false; //return-no-errors
    }

    //PLEASE-USE-THIS-MAINLY
    private bool IsHandleErrorCollisionObject(GameObject _gameObject) {
        if (IsHandleErrorNoComponentCollisionRespond(_gameObject)) return true; //return-error
        if (IsHandleErrorNoRigidbody(_gameObject)) return true; //return-error
        return false; //return-no-errors
    }

    private bool IsHandleErrorNoComponentCollisionRespond(GameObject _gameObject) {
        if (_gameObject.GetComponent<CollisionRespond>() == null) {
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
}
