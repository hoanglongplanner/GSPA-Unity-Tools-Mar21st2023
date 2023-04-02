// 
//Manage all GUIs in the game
//(c) hoanglongplanner 2023
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//ADDED
using APIGUI_Mar21st2023;

namespace APIGUI_Mar21st2023 {
    public class GUIElementText : MonoBehaviour, IGUIElementText {

        private TextMeshProUGUI m_TMPRO;

        private void Start() { m_TMPRO = this.GetComponent<TextMeshProUGUI>(); }
        public void SetText(string text) { m_TMPRO.SetText(text); }
    }
}


