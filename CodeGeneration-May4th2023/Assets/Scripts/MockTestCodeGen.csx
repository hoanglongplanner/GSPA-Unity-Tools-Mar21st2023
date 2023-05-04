public class MockTestCodeGen {
    FormattableString Main() {

        var model = new {
            i32_licenseYear = System.DateTime.Now.Year,
            str_licenseOwner = "HOANGLONGPLANNER",
            str_namespace = "CustomPlaceholderName",
            sz_str_classes = new string[] { "Users", "Products" },
            sz_str_valueFunction = new string[] { "Something" },
        };

        FormattableString[] sz_m_formattableString = new FormattableString[] {
            ExtensionGenerateFunctionMethod("HelloThereClass"),
            ExtensionGenerateFunctionMethod("HelloThereClass02"),
            ExtensionGenerateFunctionMethod("HelloThereClass03")
        };

        return $$"""                                                
            namespace {{model.str_namespace}} {      
                {{GenerateLicenseApacheV2(model.i32_licenseYear, model.str_licenseOwner)}}
                {{ExtensionGenerateClass("HelloThere", ExtensionGenerateFunctionMethod("HelloThereClass"))}}
                {{ExtensionGenerateClassContentArray("ClassArray", sz_m_formattableString)}}
            }
            """;
    }        

    FormattableString GenerateConcurentValueConstants() {

    string[] sz_str_othervalueFunction = new string[] { "ResetSpecificValueDefault", "ResetSpecificValueMin", "ResetSpecificValueMax" };

    FormattableString myMethod = $$"""
    public void MethodName(){
        //Fuck You
    }
    """;        

    return $$"""
    public class ConcurentValueConstants {
        {{ExtensionGenerateFunctionMethod("HelloThere")}}        
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

    FormattableString ExtensionGenerateClassContentArray(string _className, FormattableString[] _content = null) {
    return $$"""
    public class {{_className}} {
        {{_content}}
    }
    """;
    }

    FormattableString ExtensionGenerateClass(string _className, FormattableString _content = null) {
    return $$"""
    public class {{_className}} {        
        {{_content}}
    }
    """;
    }

    FormattableString ExtensionGenerateClassPrivate(string _className, FormattableString _content = null) {
    return $$"""
    private class {{_className}} {
        {{_content}}
    }
    """;
    }

    FormattableString ExtensionGenerateFunctionMethod(string _functionName, FormattableString _content = null) {
    return $$"""
    public void {{_functionName}}() {        
        {{_content}}
    }
    """;
    }


}
