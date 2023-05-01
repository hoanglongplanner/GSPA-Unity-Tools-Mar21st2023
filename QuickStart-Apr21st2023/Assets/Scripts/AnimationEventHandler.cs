using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventHandler : MonoBehaviour {           
    public System.Action action_onStart;
    public System.Action action_onFinish;
    public void HandleOnAnimationStart() { }
    public void HandleOnAnimationFinish() { }
}
