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

    public class ConcurentValueConstants {

        //EDIT FOR DIFFERENT USAGE

        //--MAIN-VALUE--

        static readonly int[] K_COIN = { 0, 100000, 0 }; //min - 0.0f, max - 10000.0f, def - 0.0f
        static readonly int[] K_HIGHSCORE = { 0, 10000, 0 }; //min - 0, max - 10000, def - 0
        static readonly int[] K_COMBO = { 0, int.MaxValue, 0 }; //min - 0, max - int.Max
        static readonly float[] K_FEVER = { 0.0f, 100.0f, 50.0f }; //min - 0.0f, max - 100.0f, def - 50.0f        

        //--ADDITIONAL-RATE-VALUE--
        public enum ENUM_RATE_TYPE {
            MINIMUM,
            MEDIUM_01,
            MEDIUM_02,
            MEDIUM_03,
            MAXIMUM
        }

        static readonly int[] K_COIN_RATE = { 1, 2, 5, 10, 25 };
        static readonly float[] K_HIGHSCORE_RATE = { 10.0f, 25.0f, 50.0f, 75.0f, 100.0f };

        //--GET-FUNCTIONS--
        public static int GetCoinMin() { return K_COIN[0]; }
        public static int GetCoinMax() { return K_COIN[1]; }
        public static int GetCoinDefault() { return K_COIN[2]; }
        public static int GetHighscoreMin() { return K_HIGHSCORE[0]; }
        public static int GetHighscoreMax() { return K_HIGHSCORE[1]; }
        public static int GetHighscoreDefault() { return K_HIGHSCORE[2]; }
        public static int GetComboMin() { return K_COMBO[0]; }
        public static int GetComboMax() { return K_COMBO[1]; }
        public static int GetComboDefault() { return K_COMBO[2]; }
        public static float GetFeverMin() { return K_FEVER[0]; }
        public static float GetFeverMax() { return K_FEVER[1]; }
        public static float GetFeverDefault() { return K_FEVER[2]; }

        //--GET-RATE--
        public static int GetCoinRate(ENUM_RATE_TYPE _type) { return K_COIN_RATE[(int)_type]; }
        public static int GetCoinRateRandom() { return K_COIN_RATE[Random.Range(0, K_COIN_RATE.Length)]; }
    }

    public enum ENUM_VALUE_TYPE {
        COIN,
        HIGHSCORE,
        COMBO,
        FEVER,
    }

    private int i32_coin;
    private int i32_highscore;
    private int i32_combo;
    private float f_fever;

    //--PROCESSOR--

    private void Start() { }
    private void Update() { }

    //--GET-VALUE--

    public int GetValueCoin() { return i32_coin; }
    public int GetValueHighScore() { return i32_highscore; }
    public int GetValueCombo() { return i32_combo; }
    public float GetValueFever() { return f_fever; }    

    //--RESET-VALUE--    

    public void ResetSpecificValueDefault(ENUM_VALUE_TYPE _type) {
        switch (_type) {
            case ENUM_VALUE_TYPE.COIN: i32_coin = ConcurentValueConstants.GetCoinDefault(); break;
            case ENUM_VALUE_TYPE.HIGHSCORE: i32_highscore = ConcurentValueConstants.GetHighscoreDefault(); break;
            case ENUM_VALUE_TYPE.COMBO: i32_combo = ConcurentValueConstants.GetComboDefault(); break;
            case ENUM_VALUE_TYPE.FEVER: f_fever = 0; break;
            default: break;
        }

        OnValueChange(_type);
    }

    public void ResetSpecificValueMin(ENUM_VALUE_TYPE _type) {
        switch (_type) {
            case ENUM_VALUE_TYPE.COIN: i32_coin = ConcurentValueConstants.GetCoinMin(); break;
            case ENUM_VALUE_TYPE.HIGHSCORE: i32_highscore = ConcurentValueConstants.GetHighscoreMin(); break;
            case ENUM_VALUE_TYPE.COMBO: i32_combo = ConcurentValueConstants.GetComboMin(); break;
            case ENUM_VALUE_TYPE.FEVER: f_fever = ConcurentValueConstants.GetFeverMin(); break;
            default: break;
        }

        OnValueChange(_type);
    }

    public void ResetSpecificValueMax(ENUM_VALUE_TYPE _type) {
        switch (_type) {
            case ENUM_VALUE_TYPE.COIN: i32_coin = ConcurentValueConstants.GetCoinMin(); break;
            case ENUM_VALUE_TYPE.HIGHSCORE: i32_highscore = ConcurentValueConstants.GetHighscoreMin(); break;
            case ENUM_VALUE_TYPE.COMBO: i32_combo = ConcurentValueConstants.GetComboMin(); break;
            case ENUM_VALUE_TYPE.FEVER: f_fever = ConcurentValueConstants.GetFeverMin(); break;
            default: break;
        }

        OnValueChange(_type);
    }    

    public void ResetAllValueDefault() {
        ResetSpecificValueDefault(ENUM_VALUE_TYPE.COIN);
        ResetSpecificValueDefault(ENUM_VALUE_TYPE.HIGHSCORE);
        ResetSpecificValueDefault(ENUM_VALUE_TYPE.COMBO);
        ResetSpecificValueDefault(ENUM_VALUE_TYPE.FEVER);
    }

    public static bool IsEnough(float _current, float _value) { return _current <= _value; }

    //--EXTERNAL-FUNCTION--

    public void IncreaseCoin(ConcurentValueConstants.ENUM_RATE_TYPE _type) {
        i32_coin += ConcurentValueConstants.GetCoinRate(_type);
        OnValueChange(ENUM_VALUE_TYPE.COIN);
    }

    public void IncreaseCoin(int _value = 0) {
        i32_coin += _value;
        OnValueChange(ENUM_VALUE_TYPE.COIN);
    }

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

    //--BEHAVIOR-CHANGE--
    //Update your logic here, GUI or Something
    private void OnValueChange(ENUM_VALUE_TYPE _type) {
        switch (_type) {
            case ENUM_VALUE_TYPE.COIN:
                if (i32_coin <= ConcurentValueConstants.GetCoinMin()) ResetSpecificValueMin(ENUM_VALUE_TYPE.FEVER);
                else if (i32_coin >= ConcurentValueConstants.GetCoinMax()) ResetSpecificValueMax(ENUM_VALUE_TYPE.COIN);
                break;
            case ENUM_VALUE_TYPE.HIGHSCORE: break;
            case ENUM_VALUE_TYPE.COMBO: break;
            case ENUM_VALUE_TYPE.FEVER:
                if (f_fever <= 0.0f) ResetSpecificValueDefault(ENUM_VALUE_TYPE.FEVER);
                else if (f_fever >= 100.0f) f_fever = 100.0f;
                break;
            default: break;
        }
    }
}
