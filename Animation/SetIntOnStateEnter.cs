﻿// ----------------------------------------------------------------------------
// The MIT License
// LeopotamGroupLibrary https://github.com/Leopotam/LeopotamGroupLibraryUnity
// Copyright (c) 2012-2017 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using UnityEngine;

namespace LeopotamGroup.Animation {
    /// <summary>
    /// Set Animator integer parameter to new state on node enter.
    /// </summary>
    public sealed class SetIntOnStateEnter : StateMachineBehaviour {
        [SerializeField]
        string _intName = null;

        [SerializeField]
        int _intValue = 0;

        int _fieldHash = -1;

        public override void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            base.OnStateEnter (animator, stateInfo, layerIndex);
            if (_fieldHash == -1) {
#if UNITY_EDITOR
                if (string.IsNullOrEmpty (_intName)) {
                    Debug.LogWarning ("Integer field name is empty", animator);
                    return;
                }
#endif
                _fieldHash = Animator.StringToHash (_intName);
            }
            animator.SetInteger (_fieldHash, _intValue);
        }
    }
}