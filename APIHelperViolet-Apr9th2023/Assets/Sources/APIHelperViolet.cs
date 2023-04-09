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
        public static void HelloWorld() => ToolLog.Info("Hello there, I'm Helper Violet. What can I assist you with ?");
    }

    public static class Core { }

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
            public static Vector3 Zero() { return new Vector3(0, 0, 0); }
            public static Vector3 One() { return new Vector3(1, 1, 1); }
            public static Vector3 Up() { return new Vector3(0, 0, 0); }
            public static Vector3 Down() { return new Vector3(0, 0, 0); }
            public static Vector3 Left() { return new Vector3(0, 0, 0); }
            public static Vector3 Right() { return new Vector3(0, 0, 0); }
            public static Vector3 Forward() { return new Vector3(0, 0, 0); }
            public static Vector3 Back() { return new Vector3(0, 0, 0); }

            //public static Vector3 Max(Vector3 _a, Vector3 _b);
            //public static Vector3 Min(Vector3 _a, Vector3 _b);
            //public static Vector3 Normalize(Vector3 value);

            public static Vector3 operator +(Vector3 _a, Vector3 _b) { return new Vector3(_a.x + _b.x, _a.y + _b.y, _a.z + _b.z); }
            public static Vector3 operator -(Vector3 _a) { return new Vector3(-_a.x, -_a.y, -_a.z); }
            public static Vector3 operator -(Vector3 _a, Vector3 _b) { return new Vector3(_a.x - _b.x, _a.y - _b.y, _a.z - _b.z); }
            public static Vector3 operator *(Vector3 _a, float _b) { return new Vector3(_a.x * _b, _a.y * _b, _a.z * _b); }
            public static Vector3 operator /(Vector3 _a, float _b) { return new Vector3(_a.x / _b, _a.y / _b, _a.z / _b); }
            public static bool operator ==(Vector3 _a, Vector3 _b) { return _a == _b; }
            public static bool operator !=(Vector3 _a, Vector3 _b) { return _a != _b; }
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

    public static class Multithreaded { }
    public static class Coroutine { }

    /// <summary>
    /// Class for mathetical
    /// https://github.com/Unity-Technologies/UnityCsReference/blob/master/Runtime/Export/Math/Mathf.cs
    /// https://docs.rs/bevy/latest/bevy/math/index.html
    /// </summary>
    public static class MathTool {
        /// <summary>
        /// Returns the sine of angle /f/ in radians.
        /// </summary>        
        public static float Sin(float f) { return (float)Math.Sin(f); }

        // Returns the cosine of angle /f/ in radians.
        public static float Cos(float f) { return (float)Math.Cos(f); }

        // Returns the tangent of angle /f/ in radians.
        public static float Tan(float f) { return (float)Math.Tan(f); }

        // Returns the arc-sine of /f/ - the angle in radians whose sine is /f/.
        public static float Asin(float f) { return (float)Math.Asin(f); }

        // Returns the arc-cosine of /f/ - the angle in radians whose cosine is /f/.
        public static float Acos(float f) { return (float)Math.Acos(f); }

        // Returns the arc-tangent of /f/ - the angle in radians whose tangent is /f/.
        public static float Atan(float f) { return (float)Math.Atan(f); }

        // Returns the angle in radians whose ::ref::Tan is y/x.
        public static float Atan2(float y, float x) { return (float)Math.Atan2(y, x); }

        // Returns square root of /f/.
        public static float Sqrt(float f) { return (float)Math.Sqrt(f); }

        // Returns the absolute value of /f/.
        public static float Abs(float f) { return Math.Abs(f); }

        // Returns the absolute value of /value/.
        public static int Abs(int value) { return Math.Abs(value); }

        /// *listonly*
        public static float Min(float a, float b) { return a < b ? a : b; }
        // Returns the smallest of two or more values.
        public static float Min(params float[] values) {
            int len = values.Length;
            if (len == 0)
                return 0;
            float m = values[0];
            for (int i = 1; i < len; i++) {
                if (values[i] < m)
                    m = values[i];
            }
            return m;
        }

        /// *listonly*
        public static int Min(int a, int b) { return a < b ? a : b; }
        // Returns the smallest of two or more values.
        public static int Min(params int[] values) {
            int len = values.Length;
            if (len == 0)
                return 0;
            int m = values[0];
            for (int i = 1; i < len; i++) {
                if (values[i] < m)
                    m = values[i];
            }
            return m;
        }

        /// *listonly*
        public static float Max(float a, float b) { return a > b ? a : b; }
        // Returns largest of two or more values.
        public static float Max(params float[] values) {
            int len = values.Length;
            if (len == 0)
                return 0;
            float m = values[0];
            for (int i = 1; i < len; i++) {
                if (values[i] > m)
                    m = values[i];
            }
            return m;
        }

        /// *listonly*
        public static int Max(int a, int b) { return a > b ? a : b; }
        // Returns the largest of two or more values.
        public static int Max(params int[] values) {
            int len = values.Length;
            if (len == 0)
                return 0;
            int m = values[0];
            for (int i = 1; i < len; i++) {
                if (values[i] > m)
                    m = values[i];
            }
            return m;
        }

        // Returns /f/ raised to power /p/.
        public static float Pow(float f, float p) { return (float)Math.Pow(f, p); }

        // Returns e raised to the specified power.
        public static float Exp(float power) { return (float)Math.Exp(power); }

        // Returns the logarithm of a specified number in a specified base.
        public static float Log(float f, float p) { return (float)Math.Log(f, p); }

        // Returns the natural (base e) logarithm of a specified number.
        public static float Log(float f) { return (float)Math.Log(f); }

        // Returns the base 10 logarithm of a specified number.
        public static float Log10(float f) { return (float)Math.Log10(f); }

        // Returns the smallest integer greater to or equal to /f/.
        public static float Ceil(float f) { return (float)Math.Ceiling(f); }

        // Returns the largest integer smaller to or equal to /f/.
        public static float Floor(float f) { return (float)Math.Floor(f); }

        // Returns /f/ rounded to the nearest integer.
        public static float Round(float f) { return (float)Math.Round(f); }

        // Returns the smallest integer greater to or equal to /f/.
        public static int CeilToInt(float f) { return (int)Math.Ceiling(f); }

        // Returns the largest integer smaller to or equal to /f/.
        public static int FloorToInt(float f) { return (int)Math.Floor(f); }

        // Returns /f/ rounded to the nearest integer.
        public static int RoundToInt(float f) { return (int)Math.Round(f); }
        
        /// <summary>
        /// Clamps value between min and max and returns value. 
        /// </summary>                
        public static int Clamp(int value, int min, int max) {
            if (value < min)
                value = min;
            else if (value > max)
                value = max;
            return value;
        }
        
        /// <summary>
        /// Clamps value between 0 and 1 and returns value 
        /// </summary>        
        public static float Clamp01(float value) {
            if (value < 0F)
                return 0F;
            else if (value > 1F)
                return 1F;
            else
                return value;
        }
    }
    
    public static class ToolTweenLerp { }

    /// <summary>
    /// Class for logging message to Unity Console
    /// </summary>
    public static class ToolLog {
        /// <summary>
        /// "Log Level" type.
        /// ("least important" to "most important" order)
        /// </summary>
        public enum ENUM_LOG_LEVEL_TYPE {
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
        public static void Log(ENUM_LOG_LEVEL_TYPE _type, object _message, UnityEngine.Object _origin) {
            switch (_type) {
                case ENUM_LOG_LEVEL_TYPE.TRACE: break;
                case ENUM_LOG_LEVEL_TYPE.DEBUG: break;
                case ENUM_LOG_LEVEL_TYPE.INFO: break;
                case ENUM_LOG_LEVEL_TYPE.WARN: break;
                case ENUM_LOG_LEVEL_TYPE.ERROR: break;
                case ENUM_LOG_LEVEL_TYPE.FATAL: break;
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


