public class MockTestCodeGen {
    FormattableString Main() {

        var model = new {
            string str_licenseOwnerName = "HOANGLONGPLANNER",
            int i32_licenseYear = 2023,
            string str_namespace = "CustomPlaceholderNamespace",
            sz_str_classes = new string[] { "Users", "Products" },
            sz_str_valueFunction = new string[] { "Something" },
        };

        return $$"""                                                
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
            namespace CustomPlaceholderNamespace {      
                {{ExtensionGenerateClass("HelloThere")}}
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

    FormattableString GenerateLicenseApacheV2() {
    return $$"""
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
    """;
    }

    FormattableString ExtensionGenerateClass(string _className, FormattableString _content = null) {
    return $$"""
    public class {{_className}} {
        // my properties...
        {{_content}}
    }
    """;
    }

    FormattableString ExtensionGenerateFunctionMethod(string _functionName, FormattableString _content = null) {
    return $$"""
    public void {{_functionName}}() {
        // hello there properties...
        {{_content}}
    }
    """;
    }
}
