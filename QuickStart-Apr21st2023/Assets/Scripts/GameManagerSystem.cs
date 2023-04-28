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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENUM_DIFFICULTY_TYPE {
    K_EASY,
    K_MEDIUM,
    K_HARD
}

public enum ENUM_GAMESYSTEM_STATE {
    K_MAINMENU,
    K_GAMEPLAY_INIT,
    K_GAMEPLAY_LOOP,
    K_GAMEPLAY_CLEANUP,
    K_PAUSE,
    K_RESUME
}

public enum ENUM_GAMELOOP_STATE {
    K_PLAYER_TURN,
    K_THREAT_TURN
}

public enum ENUM_GAME_STATUS { K_DRAW, K_WIN, K_LOSE }

public class GameManagerSystem : MonoBehaviour {
    [Header("GAME MANAGER")]
    [SerializeField] private ENUM_GAMESYSTEM_STATE enum_gameSystemState;
    [SerializeField] private ENUM_GAMELOOP_STATE enum_gameLoopState;
    [SerializeField] private bool isGamePause = false;

    [Header("SYSTEM ADVANCE")]
    [SerializeField] private int i32_framelimit = 60;
    
    private void Update() {
        SetSystemFramerateLimit(i32_framelimit); //WARNING-BE-CAREFUL
        UpdateGameSystemState(); 
    }

    //WARNING-BE-CAREFUL
    //USING THIS FUNCTION CHANGE SOFTWARE BEHAVIOR
    public static void SetSystemFramerateLimit(int _value = 60) => Application.targetFrameRate = _value;

    public void SetGameSystemState(ENUM_GAMESYSTEM_STATE _type) {
        enum_gameSystemState = _type;
        OnGameSystemStateChange(_type);
    }

    //TODO - Add seperate game loop
    public void SetGameLoopState(ENUM_GAMELOOP_STATE _type) => enum_gameLoopState = _type;

    private void StartGameSystemState() {
        switch (enum_gameSystemState) {
            case ENUM_GAMESYSTEM_STATE.K_MAINMENU: break;
            case ENUM_GAMESYSTEM_STATE.K_GAMEPLAY_INIT: break;
            case ENUM_GAMESYSTEM_STATE.K_GAMEPLAY_LOOP: break;
            case ENUM_GAMESYSTEM_STATE.K_GAMEPLAY_CLEANUP: break;
            case ENUM_GAMESYSTEM_STATE.K_PAUSE: break;
            case ENUM_GAMESYSTEM_STATE.K_RESUME: break;
            default: break;
        }
    }

    private void UpdateGameSystemState() {
        switch (enum_gameSystemState) {
            case ENUM_GAMESYSTEM_STATE.K_MAINMENU: break;
            case ENUM_GAMESYSTEM_STATE.K_GAMEPLAY_INIT: break;
            case ENUM_GAMESYSTEM_STATE.K_GAMEPLAY_LOOP: break;            
            case ENUM_GAMESYSTEM_STATE.K_GAMEPLAY_CLEANUP: break;
            case ENUM_GAMESYSTEM_STATE.K_PAUSE: break;
            case ENUM_GAMESYSTEM_STATE.K_RESUME: break;
            default: break;
        }
    }

    private void OnGameSystemStateChange(ENUM_GAMESYSTEM_STATE _type) {
        switch (_type) {
            case ENUM_GAMESYSTEM_STATE.K_MAINMENU: break;
            case ENUM_GAMESYSTEM_STATE.K_GAMEPLAY_INIT: break;
            case ENUM_GAMESYSTEM_STATE.K_GAMEPLAY_LOOP: break;
            case ENUM_GAMESYSTEM_STATE.K_GAMEPLAY_CLEANUP: break;
            case ENUM_GAMESYSTEM_STATE.K_PAUSE: break;
            case ENUM_GAMESYSTEM_STATE.K_RESUME: break;
            default: break;
        }
    }
}
