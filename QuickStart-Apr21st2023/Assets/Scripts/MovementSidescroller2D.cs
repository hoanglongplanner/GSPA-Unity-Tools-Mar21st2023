using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSidescroller2D : MonoBehaviour {

    public enum ENUM_MOVEMENT_TYPE {
        K_MOVE_UP,
        K_MOVE_DOWN,
        K_MOVE_LEFT,
        K_MOVE_RIGHT,
        K_JUMP
    }

    private bool isMoveUp;
    private bool isMoveDown;
    private bool isMoveLeft;
    private bool isMoveRight;
    private bool isJump;
    private bool isGround;
    private bool isFlip;
    private float f_moveRate = 0.5f;

    private void Start() { }

    private void Update() => UpdateMovement();

    public void SetMovementStatus(ENUM_MOVEMENT_TYPE _type, bool _status) {
        switch (_type) {
            case ENUM_MOVEMENT_TYPE.K_MOVE_UP: isMoveUp = _status; break;
            case ENUM_MOVEMENT_TYPE.K_MOVE_DOWN: isMoveDown = _status; break;
            case ENUM_MOVEMENT_TYPE.K_MOVE_LEFT: isMoveLeft = _status; break;
            case ENUM_MOVEMENT_TYPE.K_MOVE_RIGHT: isMoveRight = _status; break;
            case ENUM_MOVEMENT_TYPE.K_JUMP: isJump = _status; break;
            default: break;
        }
    }    

    public void UpdateMovement() {
        if (isMoveUp) f_moveRate += 0.1f;
        if (isMoveDown) f_moveRate += 0.1f;
        if (isMoveLeft) f_moveRate += 0.1f;
        if (isMoveRight) f_moveRate += 0.1f;
    }

    public void Flip() {

    }
}
