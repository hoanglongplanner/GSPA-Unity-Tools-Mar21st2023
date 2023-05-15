/*
Copyright 2023 hoanglongplanner 

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.

You may obtain a copy of the License at
http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

// 2023 hoanglongplanner
// Managing all type of GUI in game, use Singleton Design Pattern

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GUISettings {
    public static bool K_USING_SINGLETON_GUIMANAGER = false; //def: false
    public static bool K_ENABLE_AUTOSETUP_GUIELEMENT = false; //def: false    
    public static bool K_ENABLE_POINTER_ON_MOUSE_ENTER = true; //def: true    
    public static bool K_ENABLE_POINTER_ON_MOUSE_HOVER = false; //def: false
    public static bool K_ENABLE_POINTER_ON_MOUSE_EXIT = true; //def: true
    public static bool K_ENABLE_POINTER_ON_MOUSE_DOWN = true; //def: true
    public static bool K_ENABLE_POINTER_ON_MOUSE_HOLD = false; //def: false
    public static bool K_ENABLE_POINTER_ON_MOUSE_RELEASE = false; //def: false                                                               
}

public enum ENUM_GUIPAGE_TYPE {
    K_MAIN_MENU,
    K_GAMEPLAY,
    K_RESULT_DRAW,
    K_RESULT_WIN,
    K_RESULT_LOSE
}

public enum ENUM_GUIELEMENT_POINTER_STATUS {
    ON_ENTER,
    ON_HOVER,
    ON_EXIT,
    ON_MOUSE_DOWN,    
    ON_MOUSE_HOLD,
    ON_MOUSE_RELEASE
}

public enum ENUM_GUIELEMENT_OBJECT_TYPE {
    TIMER,
    DISABLE_INPUT
}

public enum ENUM_GUIELEMENT_BUTTON_TYPE {
    FUNCTION_LOADSCENE_MAINMENU,
    FUNCTION_LOADSCENE_GAMEPLAY,
    FUNCTION_RESTART_GAME,
    FUNCTION_EXITGAME
}

public enum ENUM_GUIELEMENT_TEXT_TYPE {
    HIGHSCORE,
    TIMER,
    COMBO,
    LEVEL_CURRENT,
    LEVEL_NEXT
}

public enum ENUM_GUIELEMENT_SLIDER_TYPE {
    FEVER,
    OBSTACLE_LEFT,
    LEVEL_PROGRESSION
}

public class GUIManager : MonoBehaviour {
    [SerializeField] private bool isSingleton = false; //functionality as singleton from inspector

    [SerializeField] private List<GUIPage> list_m_guiPage;
    [SerializeField] private List<GUIElementObject> list_m_guiObject;
    [SerializeField] private List<GUIElementText> list_m_guiText;
    [SerializeField] private List<GUIElementButton> list_m_guiButton;
    [SerializeField] private List<GUIElementSlider> list_m_guiSlider;

    private void Awake() => SetupGUIManager(this.transform, true);

    public void OpenGUIPage(ENUM_GUIPAGE_TYPE _type, bool _isCloseAllPage = true) {

        //--CLOSE-PAGE-FUNCTIONALITY--
        if (_isCloseAllPage) CloseGUIPageAll();

        else if (_isCloseAllPage == false) {
            switch (_type) {                
                case ENUM_GUIPAGE_TYPE.K_MAIN_MENU: break;
                case ENUM_GUIPAGE_TYPE.K_GAMEPLAY: break;
                case ENUM_GUIPAGE_TYPE.K_RESULT_DRAW: break;
                case ENUM_GUIPAGE_TYPE.K_RESULT_WIN: break;
                case ENUM_GUIPAGE_TYPE.K_RESULT_LOSE: break;
                default: break;
            }
        }

        switch (_type) {            
            case ENUM_GUIPAGE_TYPE.K_MAIN_MENU: OpenGUIPageSpecific(ENUM_GUIPAGE_TYPE.K_MAIN_MENU); break;
            case ENUM_GUIPAGE_TYPE.K_GAMEPLAY: OpenGUIPageSpecific(ENUM_GUIPAGE_TYPE.K_GAMEPLAY); break;
            case ENUM_GUIPAGE_TYPE.K_RESULT_DRAW: OpenGUIPageSpecific(ENUM_GUIPAGE_TYPE.K_RESULT_DRAW); break;
            case ENUM_GUIPAGE_TYPE.K_RESULT_WIN: OpenGUIPageSpecific(ENUM_GUIPAGE_TYPE.K_RESULT_WIN); break;
            case ENUM_GUIPAGE_TYPE.K_RESULT_LOSE: OpenGUIPageSpecific(ENUM_GUIPAGE_TYPE.K_RESULT_LOSE); break;
            default: break;
        }
    }

    public void OpenGUIPageSpecific(ENUM_GUIPAGE_TYPE _type) {
        foreach (GUIPage guiPage in GetAllGUIPageOfType(_type)) {
            guiPage.SetStatusPageActive(true);
        }
    }

    public void CloseGUIPageAll() {
        foreach (GUIPage guiPage in list_m_guiPage) {
            guiPage.SetStatusPageActive(false);
        }
    }

    public void CloseGUIPageSpecific(ENUM_GUIPAGE_TYPE _type) {
        foreach (GUIPage guiPage in GetAllGUIPageOfType(_type)) {
            guiPage.SetStatusPageActive(false);
        }
    }

    public void SetupGUIManager(Transform targetTransform = null, bool isItself = false) {
        if (isItself) targetTransform = this.transform;
        if (targetTransform == null) return; //early-exit

        foreach (Transform item in targetTransform) {
            CheckGUIElement(item);
            if (item.childCount > 0) SetupGUIManager(item, false); //WARNING-RECCURSIVE            
        }
    }

    /// <summary>
    /// Check whole gui element for components
    /// </summary>    
    private void CheckGUIElement(Transform _target) {
        GUIPage guiPage = _target.GetComponent<GUIPage>();
        if (guiPage != null) {
            list_m_guiPage.Add(guiPage);
        }

        GUIElementObject guiObject = _target.GetComponent<GUIElementObject>();
        if (guiObject != null) {
            list_m_guiObject.Add(guiObject);
            guiObject.SetGUIManager(this);
        }

        GUIElementText guiText = _target.GetComponent<GUIElementText>();
        if (guiText != null) {
            list_m_guiText.Add(guiText);
            guiText.SetGUIManager(this);
            guiText.Setup();
        }

        GUIElementButton guiButton = _target.GetComponent<GUIElementButton>();
        if (guiButton != null) {
            list_m_guiButton.Add(guiButton);
            guiButton.SetGUIManager(this);
        }

        GUIElementSlider guiSlider = _target.GetComponent<GUIElementSlider>();
        if (guiSlider != null) {
            list_m_guiSlider.Add(guiSlider);
            guiSlider.SetGUIManager(this);
            guiSlider.Setup();
        }
    }

    public List<GUIPage> GetAllGUIPageOfType(ENUM_GUIPAGE_TYPE _type) {
        List<GUIPage> temp = new List<GUIPage>();
        foreach (GUIPage guiPage in list_m_guiPage) {
            if (guiPage.IsType(_type))
                temp.Add(guiPage);
        }
        return temp; //return-result
    }

    public List<GUIElementObject> GetAllGUIElementObjectOfType(ENUM_GUIELEMENT_OBJECT_TYPE _type) {
        List<GUIElementObject> temp = new List<GUIElementObject>();
        foreach (GUIElementObject guiObject in list_m_guiObject) {
            if (guiObject.IsType(_type))
                temp.Add(guiObject);
        }
        return temp; //return-result
    }

    public List<GUIElementText> GetAllGUIElementTextOfType(ENUM_GUIELEMENT_TEXT_TYPE _type) {
        List<GUIElementText> temp = new List<GUIElementText>();
        foreach (GUIElementText text in list_m_guiText) {
            if (text.IsType(_type))
                temp.Add(text);
        }
        return temp; //return-result
    }

    public List<GUIElementButton> GetAllGUIElementButtonOfType(ENUM_GUIELEMENT_BUTTON_TYPE _type) {
        List<GUIElementButton> temp = new List<GUIElementButton>();
        foreach (GUIElementButton button in list_m_guiButton) {
            if (button.IsType(_type))
                temp.Add(button);
        }
        return temp; //return-result
    }

    public List<GUIElementSlider> GetAllGUIElementSliderOfType(ENUM_GUIELEMENT_SLIDER_TYPE _type) {
        List<GUIElementSlider> temp = new List<GUIElementSlider>();
        foreach (GUIElementSlider slider in list_m_guiSlider) {
            if (slider.IsType(_type))
                temp.Add(slider);
        }
        return temp; //return-result
    }

    public void UpdateGUIElementObject(ENUM_GUIELEMENT_OBJECT_TYPE _type) {
        List<GUIElementObject> objectList = GetAllGUIElementObjectOfType(_type);
        foreach (GUIElementObject _guiObject in objectList) {
            switch (_type) {
                case ENUM_GUIELEMENT_OBJECT_TYPE.TIMER: break;
                case ENUM_GUIELEMENT_OBJECT_TYPE.DISABLE_INPUT: break;
                default: break;
            }
        }
    }

    public void UpdateGUIElementText(ENUM_GUIELEMENT_TEXT_TYPE _type) {
        List<GUIElementText> textList = GetAllGUIElementTextOfType(_type);
        foreach (GUIElementText text in textList) {
            switch (_type) {
                case ENUM_GUIELEMENT_TEXT_TYPE.HIGHSCORE: break;
                case ENUM_GUIELEMENT_TEXT_TYPE.TIMER: break;
                case ENUM_GUIELEMENT_TEXT_TYPE.COMBO: break;
                case ENUM_GUIELEMENT_TEXT_TYPE.LEVEL_CURRENT: break;
                case ENUM_GUIELEMENT_TEXT_TYPE.LEVEL_NEXT: break;
                default: break;
            }
        }
    }

    public void OnGUIElementButton(GUIElementButton _button, ENUM_GUIELEMENT_BUTTON_TYPE _buttonType, ENUM_GUIELEMENT_POINTER_STATUS _pointerStatus) {
        switch (_pointerStatus) {

            case ENUM_GUIELEMENT_POINTER_STATUS.ON_MOUSE_DOWN:
                //AudioManager.Instance.PlaySFX_UI(ENUM_AUDIO_SFX_UI_TYPE.SELECT);

                switch (_buttonType) {
                    case ENUM_GUIELEMENT_BUTTON_TYPE.FUNCTION_LOADSCENE_MAINMENU: SceneLevelManager.LoadSceneSpecific(ENUM_SCENE_GAME_LEVEL_TYPE.K_MAINMENU); break;
                    case ENUM_GUIELEMENT_BUTTON_TYPE.FUNCTION_LOADSCENE_GAMEPLAY: SceneLevelManager.LoadSceneSpecific(ENUM_SCENE_GAME_LEVEL_TYPE.K_GAMEPLAY); break;
                    case ENUM_GUIELEMENT_BUTTON_TYPE.FUNCTION_RESTART_GAME: SceneLevelManager.LoadSceneCurrentAutoBuildIndex(); break;
                    case ENUM_GUIELEMENT_BUTTON_TYPE.FUNCTION_EXITGAME:
                        if (Application.platform != RuntimePlatform.WebGLPlayer)
                            Application.Quit();
                        break;
                    default: break;
                }
                break;

            case ENUM_GUIELEMENT_POINTER_STATUS.ON_ENTER:
                //AudioManager.Instance.PlaySFX_UI(ENUM_AUDIO_SFX_UI_TYPE.HOVER);
                break;

            case ENUM_GUIELEMENT_POINTER_STATUS.ON_EXIT:
                break;

            default: break;
        }
    }

    public void UpdateGUIElementSlider(ENUM_GUIELEMENT_SLIDER_TYPE _type) {
        List<GUIElementSlider> sliderList = GetAllGUIElementSliderOfType(_type);
        foreach (GUIElementSlider slider in sliderList) OnGUIElementSlider(slider, _type);
    }

    public void GUIElementSliderManager(ENUM_GUIELEMENT_POINTER_STATUS _pointerType) {
        switch (_pointerType) {
            case ENUM_GUIELEMENT_POINTER_STATUS.ON_MOUSE_DOWN:
                //AudioManager.Instance.PlaySFX_UI(ENUM_AUDIO_SFX_UI_TYPE.SELECT);
                break;
            case ENUM_GUIELEMENT_POINTER_STATUS.ON_ENTER:
                //AudioManager.Instance.PlaySFX_UI(ENUM_AUDIO_SFX_UI_TYPE.HOVER);
                break;
            case ENUM_GUIELEMENT_POINTER_STATUS.ON_EXIT:
                break;
            default:
                break;
        }
    }

    public void OnGUIElementSlider(GUIElementSlider _slider, ENUM_GUIELEMENT_SLIDER_TYPE _type) {
        switch (_type) {
            case ENUM_GUIELEMENT_SLIDER_TYPE.FEVER:
                //_slider.SetupSlider(0.0f, 100.0f, ManagerGameValue.Instance.GetValueFever(), false);
                break;
            case ENUM_GUIELEMENT_SLIDER_TYPE.OBSTACLE_LEFT:
                //_slider.SetupSlider(0.0f, 100.0f, ManagerGameValue.Instance.GetValueObstacleLeft()); 
                break;
            case ENUM_GUIELEMENT_SLIDER_TYPE.LEVEL_PROGRESSION:
                //_slider.SetupSlider(0, 2, FactoryLevel.Instance.GetValueLevelProgression(), true);
                break;
            default: break;
        }
    }
}
