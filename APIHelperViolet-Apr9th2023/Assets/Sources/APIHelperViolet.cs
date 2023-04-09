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

//⣿⡇⣿⣿⣿⠛⠁⣴⣿⡿⠿⠧⠹⠿⠘⣿⣿⣿⡇⢸⡻⣿⣿⣿⣿⣿⣿⣿
//⢹⡇⣿⣿⣿⠄⣞⣯⣷⣾⣿⣿⣧⡹⡆⡀⠉⢹⡌⠐⢿⣿⣿⣿⡞⣿⣿⣿
//⣾⡇⣿⣿⡇⣾⣿⣿⣿⣿⣿⣿⣿⣿⣄⢻⣦⡀⠁⢸⡌⠻⣿⣿⣿⡽⣿⣿
//⡇⣿⠹⣿⡇⡟⠛⣉⠁⠉⠉⠻⡿⣿⣿⣿⣿⣿⣦⣄⡉⠂⠈⠙⢿⣿⣝⣿
//⠤⢿⡄⠹⣧⣷⣸⡇⠄⠄⠲⢰⣌⣾⣿⣿⣿⣿⣿⣿⣶⣤⣤⡀⠄⠈⠻⢮
//⠄⢸⣧⠄⢘⢻⣿⡇⢀⣀⠄⣸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⡀⠄⢀
//⠄⠈⣿⡆⢸⣿⣿⣿⣬⣭⣴⣿⣿⣿⣿⣿⣿⣿⣯⠝⠛⠛⠙⢿⡿⠃⠄⢸
//⠄⠄⢿⣿⡀⣿⣿⣿⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣿⣿⣿⣿⡾⠁⢠⡇⢀
//⠄⠄⢸⣿⡇⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣏⣫⣻⡟⢀⠄⣿⣷⣾
//⠄⠄⢸⣿⡇⠄⠈⠙⠿⣿⣿⣿⣮⣿⣿⣿⣿⣿⣿⣿⣿⡿⢠⠊⢀⡇⣿⣿
//⠒⠤⠄⣿⡇⢀⡲⠄⠄⠈⠙⠻⢿⣿⣿⠿⠿⠟⠛⠋⠁⣰⠇⠄⢸⣿⣿⣿
//⠄⠄⠄⣿⡇⢬⡻⡇⡄⠄⠄⠄⡰⢖⠔⠉⠄⠄⠄⠄⣼⠏⠄⠄⢸⣿⣿⣿
//⠄⠄⠄⣿⡇⠄⠙⢌⢷⣆⡀⡾⡣⠃⠄⠄⠄⠄⠄⣼⡟⠄⠄⠄⠄⢿⣿⣿
//<API: Helper Violet>
//API Helper is design for Unity Engine use
//Unity Engine 2021.3.10f1

using System;
using System.Collections;
using System.Collections.Generic;

namespace APIHelperVioletRoot {

    /// <summary>
    /// Exclusive Class for API Helper Violet
    /// </summary>
    public static class APIHelperViolet {       
        /// <summary>
        /// Send Hello World message to Unity Console
        /// </summary>
        public static void HelloWorld() => LogSystem.Info("Hello there, I'm Helper Violet. What can I assist you with ?");
    }

    public static class Core { }

    /// <summary>
    /// Class for mathetical
    /// </summary>
    public static class Math { }

    public static class Transform {

        enum ENUM_ROTATION_ORDER { XYZ, XZY, YZX, YXZ, ZXY, ZYX }

        public class Vector2 {
            public float x { get; set; }
            public float y { get; set; }
            public Vector2(float _x, float _y) {
                x = _x;
                y = _y;
            }
        }

        public class Vector3 {
            public float x { get; set; }
            public float y { get; set; }
            public float z { get; set; }
            public Vector3(float _x, float _y, float _z) {                                
                x = _x;
                y = _y;
                z = _z;
            }            
            public Vector3 Zero() { return new Vector3(0, 0, 0); }
            public Vector3 One() { return new Vector3(1, 1, 1); }
            public Vector3 Up() { return new Vector3(0, 0, 0); }
            public Vector3 Down() { return new Vector3(0, 0, 0); }
            public Vector3 Left() { return new Vector3(0, 0, 0); }
            public Vector3 Right() { return new Vector3(0, 0, 0); }
            public Vector3 Forward() { return new Vector3(0, 0, 0); }
            public Vector3 Back() { return new Vector3(0, 0, 0); }
        }

        public class Vector4 {
            public float x { get; set; }
            public float y { get; set; }
            public float z { get; set; }
            public float w { get; set; }
            public Vector4(float _x, float _y, float _z, float _w) {
                x = _x;
                y = _y;
                z = _z;
                w = _w;
            }
            public Vector4 Zero() { return new Vector4(0, 0, 0, 0); }
        }
    }

    /// <summary>
    /// Class for logging message to Unity Console
    /// </summary>
    public static class LogSystem {
        /// <summary>
        /// "Log Level" type.
        /// ("least important" to "most important" order)
        /// </summary>
        public enum ENUM_LOGSYSTEM_LEVEL_TYPE {
            TRACE, //very noisy, have to trace back to origin
            DEBUG, //helpful for debugging            
            INFO, //helpful information that is worth printing by default
            WARN, //something bad happened that isn't a failure, but thats worth calling out            
            ERROR, //something failed
            FATAL //deadly for application
        };

        /// <summary>
        /// TODO: ADD LOGIC.
        /// DO NOT USE, STILL IN DEVELOPMENT.
        /// This function is designed as output message based on LOG LEVEL type.
        /// </summary>        
        public static void Log(ENUM_LOGSYSTEM_LEVEL_TYPE _type, object _message, UnityEngine.Object _origin) {
            switch (_type) {
                case ENUM_LOGSYSTEM_LEVEL_TYPE.TRACE: break;
                case ENUM_LOGSYSTEM_LEVEL_TYPE.DEBUG: break;
                case ENUM_LOGSYSTEM_LEVEL_TYPE.INFO: break;
                case ENUM_LOGSYSTEM_LEVEL_TYPE.WARN: break;
                case ENUM_LOGSYSTEM_LEVEL_TYPE.ERROR: break;
                case ENUM_LOGSYSTEM_LEVEL_TYPE.FATAL: break;
                default: break;
            }
        }

        /// <summary>
        /// Log a message to Unity Console
        /// </summary>        
        public static void Debug(object _message) {
#if UNITY_EDITOR
            UnityEngine.Debug.Log("DEBUG " + _message);
#endif
        }

        /// <summary>
        /// Log a message to Unity Console
        /// </summary>        
        public static void Debug(object _message, UnityEngine.Object _origin) {
#if UNITY_EDITOR
            UnityEngine.Debug.Log("DEBUG " + _message, _origin);
#endif
        }

        /// <summary>
        /// Log an info message to Unity Console
        /// </summary>        
        public static void Info(object _message) {
#if UNITY_EDITOR
            UnityEngine.Debug.Log("INFO " + _message);
#endif
        }

        /// <summary>
        /// Log an info message to Unity Console
        /// </summary>        
        public static void Info(object _message, UnityEngine.Object _origin) {
#if UNITY_EDITOR
            UnityEngine.Debug.Log("INFO " + _message, _origin);
#endif
        }

        /// <summary>
        /// Log a warning message to Unity Console
        /// </summary>        
        public static void Warn(object _message) {
#if UNITY_EDITOR
            UnityEngine.Debug.LogWarning("WARN " + _message);
#endif
        }

        /// <summary>
        /// Log a warning message to Unity Console
        /// </summary>        
        public static void Warn(object _message, UnityEngine.Object _origin) {
#if UNITY_EDITOR
            UnityEngine.Debug.LogWarning("WARN " + _message, _origin);
#endif
        }

        /// <summary>
        /// Log an error message to Unity Console
        /// </summary>        
        public static void Error(object _message) {
#if UNITY_EDITOR
            UnityEngine.Debug.LogError("ERROR " + _message);
#endif
        }

        /// <summary>
        /// Log an error message to Unity Console
        /// </summary>        
        public static void Error(object _message, UnityEngine.Object _origin) {
#if UNITY_EDITOR
            UnityEngine.Debug.LogError("ERROR " + _message, _origin);
#endif
        }
    }
}


