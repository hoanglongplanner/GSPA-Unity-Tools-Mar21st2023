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

public class ConcurentValueGlobalManager : MonoBehaviour {

    private class ConcurentValueConstants {        
        
        //--MAIN-VALUE--

        static readonly float[] K_MONEY = { 0.0f, 100000.0f, 0.0f }; //min - 0.0f, max - 10000.0f, def - 0.0f
        static readonly int[] K_HIGHSCORE = { 0, 10000, 0 }; //min - 0, max - 10000
        static readonly int[] K_COMBO = { 0, int.MaxValue, 0 }; //min - 0, max - int.Max
        static readonly float[] K_FEVER = { 0.0f, 100.0f, 50.0f }; //min - 0.0f, max - 100.0f, def - 50.0f
        static readonly int[] K_PIECE_LEFT = { 0, int.MaxValue, 0 }; //min - 0, max - int.Max, def - 0

        //--ADDITIONAL-RATE-VALUE--
        public const float K_MONEY_RATE = 50.0f;

        //--GET-FUNCTIONS--
        public static float GetMoneyMin() { return K_MONEY[0]; }
        public static float GetMoneyMax() { return K_MONEY[1]; }
        public static float GetMoneyDefault() { return K_MONEY[2]; }
        public static int GetHighscoreMin() { return K_HIGHSCORE[0]; }
        public static int GetHighscoreMax() { return K_HIGHSCORE[1]; }
        public static int GetHighscoreDefault() { return K_HIGHSCORE[2]; }
        public static int GetComboMin() { return K_COMBO[0]; }
        public static int GetComboMax() { return K_COMBO[1]; }
        public static float GetFeverMin() { return K_FEVER[0]; }
        public static float GetFeverMax() { return K_FEVER[1]; }
        public static float GetFeverDefault() { return K_FEVER[2]; }
    }

    public enum ENUM_VALUE_TYPE {
        MONEY,
        HIGHSCORE,
        COMBO,
        FEVER,
        COUNTER_LEFT,
    }

    private float f_money;
    private int i32_highscore;
    private int i32_combo;
    private float f_fever;
    private int i32_counterLeft;    

    //--PROCESSOR--

    private void Start() { }
    private void Update() { }

    //--GET-VALUE--

    public float GetValueMoney() { return f_money; }
    public int GetValueHighScore() { return i32_highscore; }
    public int GetValueCombo() { return i32_combo; }
    public float GetValueFever() { return f_fever; }
    public int GetValueObstacleLeft() { return i32_counterLeft; }

    //--RESET-VALUE--    

    public void ResetSpecificValueDefault(ENUM_VALUE_TYPE _type) {
        switch (_type) {
            case ENUM_VALUE_TYPE.MONEY:
                f_money = ConcurentValueConstants.GetMoneyDefault();
                OnValueChange(ENUM_VALUE_TYPE.MONEY);
                break;
            case ENUM_VALUE_TYPE.HIGHSCORE:
                i32_highscore = 0;
                OnValueChange(ENUM_VALUE_TYPE.HIGHSCORE);
                break;
            case ENUM_VALUE_TYPE.COMBO:
                i32_combo = ConcurentValueConstants.GetComboMin();
                OnValueChange(ENUM_VALUE_TYPE.HIGHSCORE);
                break;
            case ENUM_VALUE_TYPE.FEVER:
                f_fever = 0;
                OnValueChange(ENUM_VALUE_TYPE.FEVER);
                break;
            case ENUM_VALUE_TYPE.COUNTER_LEFT:
                i32_counterLeft = 0;
                OnValueChange(ENUM_VALUE_TYPE.COUNTER_LEFT);
                break;
            default: break;
        }
    }

    public void ResetAllValueDefault() {
        ResetSpecificValueDefault(ENUM_VALUE_TYPE.HIGHSCORE);
    }

    //--EXTERNAL-FUNCTION--

    public void IncreaseScore() {
        i32_highscore += 50;
        OnValueChange(ENUM_VALUE_TYPE.HIGHSCORE);
    }

    public void IncreaseCombo() {
        i32_combo += 1;
        OnValueChange(ENUM_VALUE_TYPE.COMBO);
    }

    public void IncreaseFever(float value) {
        f_fever += value;
        OnValueChange(ENUM_VALUE_TYPE.FEVER);
    }

    public void DecreaseFever(float value) {
        f_fever -= value;
        OnValueChange(ENUM_VALUE_TYPE.FEVER);
    }

    public void IncreaseObstacleLeft() {
        i32_counterLeft += 1;
        OnValueChange(ENUM_VALUE_TYPE.COUNTER_LEFT);
    }

    public void DecreaseObstacleLeft() {
        i32_counterLeft -= 1;
        OnValueChange(ENUM_VALUE_TYPE.COUNTER_LEFT);
    }

    //--BEHAVIOR-CHANGE--
    //Update your logic here, GUI or Something
    private void OnValueChange(ENUM_VALUE_TYPE _type) {
        switch (_type) {
            case ENUM_VALUE_TYPE.MONEY: break;
            case ENUM_VALUE_TYPE.HIGHSCORE: break;
            case ENUM_VALUE_TYPE.COMBO: break;
            case ENUM_VALUE_TYPE.FEVER:
                if (f_fever <= 0.0f) ResetSpecificValueDefault(ENUM_VALUE_TYPE.FEVER);
                else if (f_fever >= 100.0f) f_fever = 100.0f;
                break;
            case ENUM_VALUE_TYPE.COUNTER_LEFT: break;
            default: break;
        }
    }
}
