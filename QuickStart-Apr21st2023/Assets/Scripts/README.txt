NOTE

Comment
return-error
return-no-error
return-result

Multiple types of IsHandleError() 
- Official Error Checking Function Name in Efficient Clarity Standard Convention

It should be more modular as there are many use cases

private bool IsHandleErrorAwake();
private bool IsHandleErrorStart();

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
        if (status) return true; //return-result-error-if-encounter
        return false; //return-result-if-no-errors
    }

private bool IsHandleError() {
        if (m_targetTransform == null) {
            Debug.LogError("Transform not found !! Abort auto set position", this);
            return true; 
        }
        return false;
    }