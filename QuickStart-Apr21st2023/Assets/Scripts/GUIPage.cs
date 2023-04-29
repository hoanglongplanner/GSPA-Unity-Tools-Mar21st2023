using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIPage : MonoBehaviour {
    [SerializeField] private ENUM_GUIPAGE_TYPE enum_type;
    public bool IsType(ENUM_GUIPAGE_TYPE _type) { return enum_type == _type; }
    public ENUM_GUIPAGE_TYPE GetPageType() { return enum_type; }
    public void SetPageActive(bool _status) => this.gameObject.SetActive(_status);
}
