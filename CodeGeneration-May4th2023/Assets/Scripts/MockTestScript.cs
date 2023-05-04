using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockTestScript : MonoBehaviour
{
    public class ConcurentValueObject<T> {
        private string str_name;
        private T t_min;
        private T t_max;
        private T t_default;

        public ConcurentValueObject(string _name, T _min, T _max, T _default) {
            str_name = _name;
            t_min = _min;
            t_max = _max;
            t_default = _default;
        }

        public string GetName() { return str_name; }
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

    public string GetStringMethodName(ENUM_CODEGEN_VARIABLE_TYPE _type) {
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
}
