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

public class AutoLerpToPosition : MonoBehaviour {
    [SerializeField] private Transform[] sz_m_destination;
    private int i32_current;
    [SerializeField] private float f_timeToComplete = 10.0f;

    private void Start() => Move(sz_m_destination[0], f_timeToComplete);

    public void Move(Transform _destination, float _time) => StartCoroutine(RoutineMove(_destination.position, _time));

    public IEnumerator RoutineMove(Vector3 _destination, float _time) {

        Vector3 startPosition = this.transform.position;

        bool isReachDest = false;

        float elapsedTime = 0f;

        //While loop for lerp between two destinations purpose
        while (isReachDest == false) {

            if (Vector3.Distance(this.transform.position, _destination) < 0.01f) {
                isReachDest = true; //confirm
                this.transform.position = _destination; //set the position of this object equals to the destination

                i32_current++;
                if (i32_current >= sz_m_destination.Length) i32_current = 0;

                Move(sz_m_destination[i32_current], f_timeToComplete);

                break; //break-out-of-the-loop                
            }

            //Lerp between 0 and 1
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / _time;
            this.transform.position = Vector3.Lerp(startPosition, _destination, t);
            yield return null; //Back to the start of while loop
        }
    }
}
