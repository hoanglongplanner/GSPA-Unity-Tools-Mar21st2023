using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIPage : MonoBehaviour {
    [SerializeField] private ENUM_GUIPAGE_TYPE enum_type;
    public bool IsType(ENUM_GUIPAGE_TYPE _type) { return enum_type == _type; }
    public ENUM_GUIPAGE_TYPE GetTypePage() { return enum_type; }
    public bool IsPageActive() { return this.gameObject.activeInHierarchy; }
    public void SetStatusPageActive(bool _status) => this.gameObject.SetActive(_status);
}
