using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManagerLocal : MonoBehaviour {    
    [SerializeField] private List<GUIElementObject> list_m_guiObject;
    [SerializeField] private List<GUIElementText> list_m_guiText;
    [SerializeField] private List<GUIElementButton> list_m_guiButton;
    [SerializeField] private List<GUIElementSlider> list_m_guiSlider;

    public void UpdateObject() { }
    public void UpdateText() { }
    public void UpdateSlider() { }

}
