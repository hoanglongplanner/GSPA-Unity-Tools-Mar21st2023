public class MockTestCodeGen {

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
        K_ENUM,
        K_ARRAY_INT,
        K_ARRAY_FLOAT,
        K_ARRAY_BOOL,
    }

    public static string GetStringAccessType(ENUM_CODEGEN_ACCESS_TYPE _type) {
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
            case ENUM_CODEGEN_VARIABLE_TYPE.K_ENUM: return "enum";
            case ENUM_CODEGEN_VARIABLE_TYPE.K_ARRAY_INT: return "int[]";
            case ENUM_CODEGEN_VARIABLE_TYPE.K_ARRAY_FLOAT: return "float[]";
            case ENUM_CODEGEN_VARIABLE_TYPE.K_ARRAY_BOOL: return "bool[]";
            default: return null;
        }
    }    

    FormattableString ExtGenerateEnum(ENUM_CODEGEN_ACCESS_TYPE _accessType, string _enumNameClass, string[] _content = null) {   
    return $$"""
    {{GetStringAccessType(_accessType)}} enum {{_enumNameClass}} {        
        {{_content.ToList().Select(t => ExtGenerateEnumContent(t))}}
    }
    """;
    }

    FormattableString ExtGenerateEnum(ENUM_CODEGEN_ACCESS_TYPE _accessType, EnumObject _enumObject) {   
    return $$"""
    {{GetStringAccessType(_accessType)}} enum {{_enumObject.GetName()}} {        
        {{_enumObject.GetContent().ToList().Select(t => ExtGenerateEnumContent(t))}}
    }
    """;
    }
    
    FormattableString ExtGenerateEnumContent(string _enumName = null) {   
    return $$"""
    K_{{_enumName}}, 
    """;
    }

    FormattableString ExtGenerateSwitchCaseEnum(EnumObject _enumObject) {   
    return $$"""
    switch (_type) {
        {{_enumObject.GetContent().ToList().Select(t => ExtGenerateSwitchCaseEnumContent(_enumObject,t))}}
    }    
    """;
    }

    FormattableString ExtGenerateSwitchCaseEnumContent(EnumObject _enumObject, string _singleEnumName) {   
    return $$"""
    case {{_enumObject.GetName()}}.{{_singleEnumName}}:
    break;
    """;
    }

    FormattableString ExtGenerateConcurent<T>(ConcurentValueObject<T> concurentValueObject) {   
    return $$""" 
    private static readonly {{concurentValueObject.GetVariableName()}}[] {{concurentValueObject.GetNameWithPrefix()}} = { {{concurentValueObject.GetValueMin()}}, {{concurentValueObject.GetValueMax}}, {{concurentValueObject.GetValueDefault}} };
    public static {{concurentValueObject.GetVariableName()}} GetValueMin{{concurentValueObject.GetNameNoPrefix()}}() { return {{concurentValueObject.GetNameWithPrefix()}}[0]; }
    public static {{concurentValueObject.GetVariableName()}} GetValueMax{{concurentValueObject.GetNameNoPrefix()}}() { return {{concurentValueObject.GetNameWithPrefix()}}[1]; }
    public static {{concurentValueObject.GetVariableName()}} GetValueDefault{{concurentValueObject.GetNameNoPrefix()}}() { return {{concurentValueObject.GetNameWithPrefix()}}[2]; }
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

    ConcurentValueObject<int> concurentCoin = new ConcurentValueObject<int>("K_COIN", "Coin", ENUM_CODEGEN_VARIABLE_TYPE.K_INT, 0, int.MaxValue, 0);
    ConcurentValueObject<int> concurentHighscore = new ConcurentValueObject<int>("K_HIGHSCORE", "Highscore", ENUM_CODEGEN_VARIABLE_TYPE.K_INT, 0, int.MaxValue, 0);
    ConcurentValueObject<int> concurentCombo = new ConcurentValueObject<int>("K_COMBO", "Combo", ENUM_CODEGEN_VARIABLE_TYPE.K_INT, 0, int.MaxValue, 0);
    ConcurentValueObject<float> concurentFever = new ConcurentValueObject<float>("K_FEVER", "Fever", ENUM_CODEGEN_VARIABLE_TYPE.K_FLOAT, 0.0f, 100.0f, 0.0f);    
    
    string[] sz_str_rate = new string[] { "MIN", "MEDIUM_01", "MEDIUM_02", "MEDIUM_03", "MAX" };
    EnumObject enumRateObj = new EnumObject("ENUM_RATE_TYPE", sz_str_rate);

    FormattableString[] sz_m_formattableString = new FormattableString[] {
        ExtensionGenerateFunctionMethod(ENUM_CODEGEN_ACCESS_TYPE.K_PUBLIC, ENUM_CODEGEN_VARIABLE_TYPE.K_ARRAY_FLOAT, "MethodSomething"),
        ExtGenerateConcurent(concurentCoin),
        ExtGenerateConcurent(concurentHighscore),
        ExtGenerateConcurent(concurentCombo),
        ExtGenerateConcurent(concurentFever),
        ExtGenerateEnum(ENUM_CODEGEN_ACCESS_TYPE.K_PUBLIC, enumRateObj),
        //ExtGenerateSwitchCaseEnum(enumRateObj),
    };

    //Return all result here
    return $$"""    
    {{ExtensionGenerateClassContentArray("ConcurentClassConstants", true, sz_m_formattableString)}}    
    """;
    }

    FormattableString Main() {

        var model = new {
            i32_licenseYear = System.DateTime.Now.Year,
            str_licenseOwner = "HOANGLONGPLANNER",
            str_namespace = "PlaceholderNamespaceName",
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
