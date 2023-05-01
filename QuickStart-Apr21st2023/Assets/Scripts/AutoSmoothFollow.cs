using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSmoothFollow : MonoBehaviour {
    [SerializeField] private Transform m_targetTransform;
    [SerializeField] private float f_speed = 2.0f;

    void Update() => UpdateSmoothFollow();

    private void UpdateSmoothFollow() {
        float interpolation = f_speed * Time.deltaTime;
        Vector3 resultPosition = transform.position;

        resultPosition.x = Mathf.Lerp(transform.position.x, m_targetTransform.position.x, interpolation);
        resultPosition.y = Mathf.Lerp(transform.position.y, m_targetTransform.position.y, interpolation);
        resultPosition.z = Mathf.Lerp(transform.position.z, m_targetTransform.position.z, interpolation);

        transform.position = resultPosition;
    }

    public void SetTransformTarget(Transform _transform) => m_targetTransform = _transform;
    public void SetSpeed(float _value) => f_speed = _value;
}
