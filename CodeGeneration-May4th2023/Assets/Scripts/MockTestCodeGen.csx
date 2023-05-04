public class MockTestCodeGen {

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

    public string GetStringVariableType(ENUM_CODEGEN_VARIABLE_TYPE _type) {
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

    FormattableString ExtensionGenerateConcurent<T>(ConcurentValueObject<T> concurentValueObject) {   
    return $$""" 
    private static readonly {{typeof(T).ToString()}}[] {{concurentValueObject.GetName}} = { {{concurentValueObject.GetValueMin()}}, {{concurentValueObject.GetValueMax}}, {{concurentValueObject.GetValueDefault}} };
    """;
    }

    FormattableString ExtensionGenerateFunctionMethod(ENUM_CODEGEN_ACCESS_TYPE _accessType, ENUM_CODEGEN_VARIABLE_TYPE _variType, string _functionName, FormattableString _content = null) {   
    return $$"""
    {{GetStringAccessType(_accessType)}} {{GetStringVariableType(_variType)}} {{_functionName}}() {        
        {{_content}}
    }
    """;
    }

    //--MAIN-CONTENT--
    //EDIT ALL YOUR STUFF HERE

    FormattableString GenerateContent() {

    string[] sz_str_othervalueFunction = new string[] { "ResetSpecificValueDefault", "ResetSpecificValueMin", "ResetSpecificValueMax" };    
    ConcurentValueObject<int> intObject = new ConcurentValueObject<int>("K_COIN", 0, 100, 0);

    FormattableString[] sz_m_formattableString = new FormattableString[] {
        ExtensionGenerateFunctionMethod(ENUM_CODEGEN_ACCESS_TYPE.K_PRIVATE_STATIC_READONLY, ENUM_CODEGEN_VARIABLE_TYPE.K_ARRAY_FLOAT, "MethodSomething"),        
        ExtensionGenerateConcurent(intObject),
    };

    //Return all result here
    return $$"""    
    {{ExtensionGenerateClassContentArray("TestingClassArray", true, sz_m_formattableString)}}    
    """;
    }

    FormattableString Main() {

        var model = new {
            i32_licenseYear = System.DateTime.Now.Year,
            str_licenseOwner = "HOANGLONGPLANNER",
            str_namespace = "CustomPlaceholderName",
            sz_str_classes = new string[] { "Users", "Products" },
            sz_str_valueFunction = new string[] { "Something" },
        };        

        return $$"""                                                
            namespace {{model.str_namespace}} {      
                {{GenerateLicenseApacheV2(model.i32_licenseYear, model.str_licenseOwner)}}   
                {{GenerateContent()}}
            }
            """;
    }                


    //--EXTENSION-FOR-USAGE--
    //REMEMBER USE THESE

    FormattableString GenerateLicenseApacheV2(int _year = 2023, string _owner = "HOANGLONGPLANNER") {
    return $$"""
    /*
    * Copyright (C) {{_year}} {{_owner}}
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
    """;
    }    

    FormattableString ExtensionGenerateClassContentArray(string _className, bool _isPublic = true, FormattableString[] _content = null) {

    string str_accessType = null;
    if (_isPublic) str_accessType = "public";
    else str_accessType = "private";

    return $$"""
    {{str_accessType}} class {{_className}} {
        {{_content}}
    }
    """;
    }    

    FormattableString ExtensionGenerateClass(string _className, bool _isPublic = true, FormattableString _content = null) {

    string str_accessType = null;
    if (_isPublic) str_accessType = "public";
    else str_accessType = "private";

    return $$"""
    {{str_accessType}} class {{_className}} {        
        {{_content}}
    }
    """;
    }        
}
