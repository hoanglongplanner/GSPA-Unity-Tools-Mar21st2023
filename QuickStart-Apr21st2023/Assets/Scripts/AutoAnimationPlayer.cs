using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAnimationPlayer : MonoBehaviour {
    private ENUM_ANIMATION_STATE_TYPE enum_animationType;
    private void OnEnable() => PlayAnimation();
    public void PlayAnimation() => this.GetComponent<Animator>().Play(AnimationPlayer.GetAnimationName(enum_animationType));
}
