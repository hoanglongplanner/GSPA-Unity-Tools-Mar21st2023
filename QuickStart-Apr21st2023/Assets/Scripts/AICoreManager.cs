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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICoreManager : MonoBehaviour
{        
    [SerializeField] private float f_waitTime = 10.0f;    

    [SerializeField] private float f_lenghtX = 5.0f;
    [SerializeField] private float f_lenghtZ = 5.0f;
    [SerializeField] private Vector3 vec3_areaMin;
    [SerializeField] private Vector3 vec3_areaMax;
    [SerializeField] private Vector3 vec3_center;
    [SerializeField] private bool isCalculateOnce = false;
    [SerializeField] private Vector3 vec3_nextPosition;           

    public void CalculateGameAreaBasedOnCurrentPosition() {
        if (isCalculateOnce) return;

        float minAreaX = this.transform.position.x - f_lenghtX;
        float minAreaZ = this.transform.position.z - f_lenghtZ;

        float maxAreaX = this.transform.position.x + f_lenghtX;
        float maxAreaZ = this.transform.position.z + f_lenghtZ;

        vec3_areaMin = new Vector3(minAreaX, this.transform.position.y, minAreaZ);
        vec3_areaMax = new Vector3(maxAreaX, this.transform.position.y, maxAreaZ);
        vec3_center = new Vector3((vec3_areaMax.x + vec3_areaMin.x) / 2, this.transform.position.y, (vec3_areaMax.z + vec3_areaMin.z) / 2);

        isCalculateOnce = true;
    }

    public Vector3 GetRandomLocationWithinBounds() {
        Vector3 temp = Vector3.one;

        float x = Random.Range(vec3_areaMin.x, vec3_areaMax.x);
        float z = Random.Range(vec3_areaMin.z, vec3_areaMax.z);

        //Debug.Log("New Area " + new Vector3(maxAreaX, this.transform.position.y, maxAreaZ));

        temp = new Vector3(x, this.transform.position.y, z);
        return vec3_nextPosition = temp;
    }    

    public void WaitIdle() => StartCoroutine(RoutineWait(Random.Range(1.0f, 5.0f)));
    public void Move(Vector3 _destination, float _time) => StartCoroutine(RoutineMove(_destination, _time));

    private IEnumerator RoutineWait(float _time) {
        f_waitTime = _time;
        yield return new WaitForSeconds(_time);        
    }

    private IEnumerator RoutineMove(UnityEngine.Vector3 _destination, float _time) {

        f_waitTime = _time;

        UnityEngine.Vector3 startPosition = this.transform.position;

        bool isReachDest = false;

        float elapsedTime = 0f;

        //While loop for lerp between two destinations purpose
        while (isReachDest == false) {

            if (UnityEngine.Vector3.Distance(this.transform.position, _destination) < 0.01f) {
                isReachDest = true; //confirm
                this.transform.position = _destination; //set the position of this object equals to the destination                                    

                break; //break-out-of-the-loop                
            }

            //Lerp between 0 and 1
            elapsedTime += UnityEngine.Time.deltaTime;
            float t = elapsedTime / _time;
            this.transform.position = UnityEngine.Vector3.Lerp(startPosition, _destination, t);
            yield return null; //Back to the start of while loop
        }
    }    

    //--EDITOR-GIZMOS    
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        if (isCalculateOnce == false) Gizmos.DrawLine(new Vector3(this.transform.position.x - f_lenghtX, 1, this.transform.position.z - f_lenghtZ), new Vector3(this.transform.position.x + f_lenghtX, 1, this.transform.position.z + f_lenghtZ));
        else if (isCalculateOnce) Gizmos.DrawLine(vec3_areaMin, vec3_areaMax);
    }
}
