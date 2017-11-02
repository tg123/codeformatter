// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.DotNet.CodeFormatting.Filters
{
    [Export(typeof(IFormattingFilter))]
    internal sealed class UsableFileFilter : IFormattingFilter
    {
        private readonly Options _options;

        [ImportingConstructor]
        public UsableFileFilter([Import] Options options)
        {
            _options = options;
        }

        public bool ShouldBeProcessed(Document document)
        {
            if (document.FilePath == null)
            {
                return true;
            }

            var fileInfo = new FileInfo(document.FilePath);
            if (!fileInfo.Exists || fileInfo.IsReadOnly)
            {
                _options.FormatLogger.WriteLine("warning: skipping document '{0}' because it {1}.",
                    document.FilePath,
                    fileInfo.IsReadOnly ? "is read-only" : "does not exist");
                return false;
            }

            return true;
        }
    }
}
