using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockTestScript : MonoBehaviour
{
    public class ConcurentValueObject<T> {
        private string str_namePrefix;
        private string str_nameNoPrefix;
        private ENUM_CODEGEN_VARIABLE_TYPE enum_variableType;
        private T t_min;
        private T t_max;
        private T t_default;

        public ConcurentValueObject(string _namePrefix, string _nameNoPrefix, ENUM_CODEGEN_VARIABLE_TYPE _variableType, T _min, T _max, T _default) {
            str_namePrefix = _namePrefix;
            str_nameNoPrefix = _nameNoPrefix;
            enum_variableType = _variableType;
            t_min = _min;
            t_max = _max;
            t_default = _default;
        }

        public string GetNameWithPrefix() { return str_namePrefix; }
        public string GetNameNoPrefix() { return str_nameNoPrefix; }
        public string GetVariableName() { return GetStringVariableType(enum_variableType); }
        public T GetValueMin() { return t_min; }
        public T GetValueMax() { return t_max; }
        public T GetValueDefault() { return t_default; }
    }    

    public class ConcurentValueRateObject<T> {
        private string str_namePrefix;
        private string str_nameNoPrefix;
        private ENUM_CODEGEN_VARIABLE_TYPE enum_variableType;
        private T[] sz_t_value;

        public ConcurentValueRateObject(string _namePrefix, string _nameNoPrefix, ENUM_CODEGEN_VARIABLE_TYPE _variableType, T[] _value) {
            str_namePrefix = _namePrefix;
            str_nameNoPrefix = _nameNoPrefix;
            enum_variableType = _variableType;
            sz_t_value = _value;
        }

        public string GetNameWithPrefix() { return str_namePrefix; }
        public string GetNameNoPrefix() { return str_nameNoPrefix; }
        public string GetVariableName() { return GetStringVariableType(enum_variableType); }
        public T GetValue(ENUM_RATE_TYPE _type) { return sz_t_value[(int)_type]; }
        public T GetValueRandom() {
            System.Random random = new System.Random();
            return sz_t_value[random.Next(0, sz_t_value.Length)]; 
        }
    }

    public enum ENUM_RATE_TYPE {
        K_MIN,
        K_MEDIUM_01,
        K_MEDIUM_02,
        K_MEDIUM_03,
        K_MAX
    }

    public enum ENUM_CODEGEN_ACCESS_TYPE {
        K_PUBLIC,
        K_PRIVATE,
        K_PROTECTED,
        K_PRIVATE_STATIC_READONLY
    }

    public enum ENUM_CODEGEN_VARIABLE_TYPE {
        K_VOID,
        K_INT,
        K_FLOAT,
        K_BOOL,
        K_ARRAY_INT,
        K_ARRAY_FLOAT,
        K_ARRAY_BOOL,        
    }

    public class EnumObject {
        private string str_name;
        private string[] sz_str_content;

        public EnumObject(string _name, string[] _content) {
            str_name = _name;
            sz_str_content = _content;
        }

        public string GetName() { return str_name; }
        public string[] GetContent() { return sz_str_content; }
    }

    public string GetStringAccessType(ENUM_CODEGEN_ACCESS_TYPE _type) {
        switch (_type) {
            case ENUM_CODEGEN_ACCESS_TYPE.K_PUBLIC: return "public";
            case ENUM_CODEGEN_ACCESS_TYPE.K_PRIVATE: return "private";
            case ENUM_CODEGEN_ACCESS_TYPE.K_PROTECTED: return "protected";
            case ENUM_CODEGEN_ACCESS_TYPE.K_PRIVATE_STATIC_READONLY: return "private static readonly";                
            default: return null;
        }
    }

    public static string GetStringVariableType(ENUM_CODEGEN_VARIABLE_TYPE _type) {
        switch (_type) {
            case ENUM_CODEGEN_VARIABLE_TYPE.K_VOID: return "void";                
            case ENUM_CODEGEN_VARIABLE_TYPE.K_INT: return "int";                
            case ENUM_CODEGEN_VARIABLE_TYPE.K_FLOAT: return "float";
            case ENUM_CODEGEN_VARIABLE_TYPE.K_BOOL: return "bool";
            case ENUM_CODEGEN_VARIABLE_TYPE.K_ARRAY_INT: return "int[]";
            case ENUM_CODEGEN_VARIABLE_TYPE.K_ARRAY_FLOAT: return "float[]";
            case ENUM_CODEGEN_VARIABLE_TYPE.K_ARRAY_BOOL: return "bool[]";            
            default: return null;                
        }
    }

    private void Start() {
        string[] sz_str_rate = new string[] { "MIN", "MEDIUM_01", "MEDIUM_02", "MEDIUM_03", "MAX" };
        EnumObject enumRateObj = new EnumObject("ENUM_RATE_TYPE", sz_str_rate);
    }
}
