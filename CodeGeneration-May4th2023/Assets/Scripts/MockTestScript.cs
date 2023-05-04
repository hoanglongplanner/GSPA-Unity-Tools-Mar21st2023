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

    // Start is called before the first frame update
    void Start()
    {
        ConcurentValueObject<int> intObject = new ConcurentValueObject<int>("K_COIN", 0, 100, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetSomeStuff(ConcurentValueObject<T> concurentValueObject) {

    }
}
