using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoResizeAndMiddleBetweenTwoObjects : MonoBehaviour
{
    [SerializeField] private Transform m_startTransform;
    [SerializeField] private Transform m_endTransform;
    [SerializeField] private float f_resizeRate = 0.5f;

    void Start() => ResizeConnector(m_startTransform.position, m_endTransform.position);
    void Update() => ResizeConnector(m_startTransform.position, m_endTransform.position);

    //reposition to middle of two vector, resize the middle between two vector
    private void ResizeConnector(Vector3 _startVector, Vector3 _endVector) {
        Vector3 dir = _endVector - _startVector;
        Vector3 middle = (dir) / 2.0f + _startVector;

        transform.position = middle;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);

        Vector3 scale = transform.localScale;

        scale.y = dir.magnitude * f_resizeRate;

        transform.localScale = scale;
    }
}
