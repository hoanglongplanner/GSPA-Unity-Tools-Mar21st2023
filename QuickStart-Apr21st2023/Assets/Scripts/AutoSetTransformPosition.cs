using UnityEngine;

public class AutoSetTransformPosition : MonoBehaviour {
    [SerializeField] private Transform m_targetTransform;
    [SerializeField] private bool isUpdateEveryFrame = false;

    private void Start() => IsHandleError();

    private void Update() {        
        if (isUpdateEveryFrame) UpdatePosition();
    }

    private void FixedUpdate() {        
        if (isUpdateEveryFrame == false) UpdatePosition();
    }

    private bool IsHandleError() {
        if (m_targetTransform == null) {
            Debug.LogError("Transform not found !! Abort auto set position", this);
            return true; 
        }
        return false;
    }    

    private void UpdatePosition() {
        if (IsHandleError()) return; //safe-check
        this.transform.position = m_targetTransform.position; 
    }

    public void SetTargetTransform(Transform _transform) => m_targetTransform = _transform;
    public void SetStatusUpdatePosEveryFrame(bool _status) => isUpdateEveryFrame = _status;
}
