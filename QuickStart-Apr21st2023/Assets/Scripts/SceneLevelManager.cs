using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ENUM_SCENE_LEVEL_TYPE {
    K_MAINMENU,
    K_LOADING_SCREEN,
    K_GAMEPLAY,
    K_RESULT,
    K_CREDITS
}

public class SceneLevelManager : MonoBehaviour {
    public static int GetCurrentSceneBuildID() { return UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex; }
    public static void LoadSceneCurrentAutoBuildIndex() => UnityEngine.SceneManagement.SceneManager.LoadScene(GetCurrentSceneBuildID());
    public static void LoadSceneSpecific(ENUM_SCENE_LEVEL_TYPE _type) => UnityEngine.SceneManagement.SceneManager.LoadScene((int)_type);
    public static void LoadSceneSpecific(int _index) => UnityEngine.SceneManagement.SceneManager.LoadScene(_index);
    public void LoadSceneAsyncSpecific(ENUM_SCENE_LEVEL_TYPE _type) => StartCoroutine(LoadSceneAsync((int)_type));
    public void LoadSceneAsyncSpecific(int _index) => StartCoroutine(LoadSceneAsync(_index));
    private static IEnumerator LoadSceneAsync(int _index) {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_index);
        while (!asyncLoad.isDone) {
            yield return null;
        } // Wait until the asynchronous scene fully loads
        OnSceneLoadSuccessful((ENUM_SCENE_LEVEL_TYPE)_index);
    }

    private static void OnSceneLoadSuccessful(ENUM_SCENE_LEVEL_TYPE _type) {
        switch (_type) {
            case ENUM_SCENE_LEVEL_TYPE.K_MAINMENU: break;
            case ENUM_SCENE_LEVEL_TYPE.K_LOADING_SCREEN: break;
            case ENUM_SCENE_LEVEL_TYPE.K_GAMEPLAY: break;
            case ENUM_SCENE_LEVEL_TYPE.K_RESULT: break;
            case ENUM_SCENE_LEVEL_TYPE.K_CREDITS: break;            
            default: break;
        }
    }
}
