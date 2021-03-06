﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.Scripting.Utils;

namespace Microsoft.Scripting.Runtime {
    /// <summary>
    /// An attribute that is applied to saved ScriptCode's to be used to re-create the ScriptCode
    /// from disk.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class DlrCachedCodeAttribute : Attribute {
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class CachedOptimizedCodeAttribute : Attribute {
        // C# requires a constructor with CLS compliant types:
        public CachedOptimizedCodeAttribute() {
            Names = ArrayUtils.EmptyStrings;
        }

        public CachedOptimizedCodeAttribute(string[] names) {
            ContractUtils.RequiresNotNull(names, "names");
            Names = names;
        }

        /// <summary>
        /// Gets names stored in optimized scope. 
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
        public string[] Names { get; }
    }
}
