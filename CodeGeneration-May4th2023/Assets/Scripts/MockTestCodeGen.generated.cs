namespace PlaceholderNamespaceName {
    /*
    * Copyright (C) 2023 HOANGLONGPLANNER
    *
    * Licensed under the Apache License, Version 2.0(the "License");
    * you may not use this file except in compliance with the License.
    *
    * You may obtain a copy of the License at
    * http://www.apache.org/licenses/LICENSE-2.0
    *
    * Unless required by applicable law or agreed to in writing, software
    * distributed under the License is distributed on an "AS IS" BASIS,
    * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    * See the License for the specific language governing permissions and
    * limitations under the License.
    */
    public class ConcurentClassConstants {
        public float[] MethodSomething() {

        }

        private static readonly int[] K_COIN = { 0, 2147483647, 0 };
        public static int GetValueMinCoin() { return K_COIN[0]; }
        public static int GetValueMaxCoin() { return K_COIN[1]; }
        public static int GetValueDefaultCoin() { return K_COIN[2]; }

        private static readonly int[] K_HIGHSCORE = { 0, 2147483647, 0 };
        public static int GetValueMinHighscore() { return K_HIGHSCORE[0]; }
        public static int GetValueMaxHighscore() { return K_HIGHSCORE[1]; }
        public static int GetValueDefaultHighscore() { return K_HIGHSCORE[2]; }

        private static readonly int[] K_COMBO = { 0, 2147483647, 0 };
        public static int GetValueMinCombo() { return K_COMBO[0]; }
        public static int GetValueMaxCombo() { return K_COMBO[1]; }
        public static int GetValueDefaultCombo() { return K_COMBO[2]; }

        private static readonly float[] K_FEVER = { 0, 100, 0 };
        public static float GetValueMinFever() { return K_FEVER[0]; }
        public static float GetValueMaxFever() { return K_FEVER[1]; }
        public static float GetValueDefaultFever() { return K_FEVER[2]; }

        public enum ENUM_RATE_TYPE {
            K_MIN,
            K_MEDIUM_01,
            K_MEDIUM_02,
            K_MEDIUM_03,
            K_MAX,
        }

        public void GetSomething(ENUM_RATE_TYPE _type) {
            switch (_type) {
                case ENUM_RATE_TYPE.K_MIN: break;
                case ENUM_RATE_TYPE.K_MEDIUM_01: break;
                case ENUM_RATE_TYPE.K_MEDIUM_02: break;
                case ENUM_RATE_TYPE.K_MEDIUM_03: break;
                case ENUM_RATE_TYPE.K_MAX: break;
            }
        }
    }
}