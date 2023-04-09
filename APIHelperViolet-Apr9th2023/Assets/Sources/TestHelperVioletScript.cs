using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using APIHelperVioletRoot;

public class TestHelperVioletScript : MonoBehaviour {
    public Vector3 vec3;
    private void Start() => APIHelperVioletRoot.APIHelperViolet.HelloWorld();
}
