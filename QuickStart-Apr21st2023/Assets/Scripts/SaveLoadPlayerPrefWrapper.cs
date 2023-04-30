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

public class SaveLoadPlayerPrefWrapper {
    private enum ENUM_SAVE_NAME {
        MONEY
    }

    public static void SaveMoney(int _value) => ToolSaveLoadPlayerPref.SetInt(ENUM_SAVE_NAME.MONEY.ToString(), _value);
    public static void LoadMoney() => ToolSaveLoadPlayerPref.GetInt(ENUM_SAVE_NAME.MONEY.ToString());
}
