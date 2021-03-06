﻿// ----------------------------------------------------------------------------
// The MIT License
// LeopotamGroupLibrary https://github.com/Leopotam/LeopotamGroupLibraryUnity
// Copyright (c) 2012-2017 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using UnityEngine;

// ReSharper disable RedundantCast.0

namespace LeopotamGroup.Common {
    /// <summary>
    /// Replacement for MonoBehaviour class with transform caching.
    /// </summary>
    public abstract class MonoBehaviourBase : MonoBehaviour {
        // ReSharper disable once InconsistentNaming
        /// <summary>
        /// Patched transform, gains 2x performance boost compare to standard.
        /// </summary>
        /// <value>The transform.</value>
        public new Transform transform {
            get {
                if ((object) CachedTransform == null) {
                    CachedTransform = base.transform;
                }
                return CachedTransform;
            }
        }

        /// <summary>
        /// Internal cached transform. Dont be fool to overwrite it, no protection for additional 2x performance boost.
        /// </summary>
        protected Transform CachedTransform;

        protected virtual void Awake () {
            if ((object) CachedTransform == null) {
                CachedTransform = base.transform;
            }
        }
    }
}