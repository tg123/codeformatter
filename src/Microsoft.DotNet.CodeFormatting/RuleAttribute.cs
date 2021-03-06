// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.DotNet.CodeFormatting
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    internal sealed class SyntaxRuleAttribute : ExportAttribute, IRuleMetadata
    {
        public SyntaxRuleAttribute(string name, string description, int order)
            : base(typeof(ISyntaxFormattingRule))
        {
            Name = name;
            Description = description;
            Order = order;
            DefaultRule = true;
        }

        public SyntaxRuleAttribute(IDictionary<string, object> @params)
            : base(typeof(ISyntaxFormattingRule))
        {
            Name = (string) @params[nameof(Name)];
            Description = (string) @params[nameof(Description)];
            Order = (int) @params[nameof(Order)];
            DefaultRule = (bool) @params[nameof(DefaultRule)];
        }

        [DefaultValue("")]
        public string Name { get; private set; }

        [DefaultValue("")]
        public string Description { get; private set; }

        [DefaultValue(int.MaxValue)]
        public int Order { get; private set; }

        [DefaultValue(true)]
        public bool DefaultRule { get; set; }
    }

    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    internal sealed class LocalSemanticRuleAttribute : ExportAttribute, IRuleMetadata
    {
        public LocalSemanticRuleAttribute(string name, string description, int order)
            : base(typeof(ILocalSemanticFormattingRule))
        {
            Name = name;
            Description = description;
            Order = order;
            DefaultRule = true;
        }

        public LocalSemanticRuleAttribute(IDictionary<string, object> @params)
            : base(typeof(ILocalSemanticFormattingRule))
        {
            Name = (string)@params[nameof(Name)];
            Description = (string)@params[nameof(Description)];
            Order = (int)@params[nameof(Order)];
            DefaultRule = (bool)@params[nameof(DefaultRule)];
        }

        [DefaultValue("")]
        public string Name { get; private set; }

        [DefaultValue("")]
        public string Description { get; private set; }

        [DefaultValue(int.MaxValue)]
        public int Order { get; private set; }

        [DefaultValue(true)]
        public bool DefaultRule { get; set; }
    }

    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    internal sealed class GlobalSemanticRuleAttribute : ExportAttribute, IRuleMetadata
    {
        public GlobalSemanticRuleAttribute(string name, string description, int order)
            : base(typeof(IGlobalSemanticFormattingRule))
        {
            Name = name;
            Description = description;
            Order = order;
            DefaultRule = true;
        }

        public GlobalSemanticRuleAttribute(IDictionary<string, object> @params) 
            : base(typeof(IGlobalSemanticFormattingRule))
        {
            Name = (string)@params[nameof(Name)];
            Description = (string)@params[nameof(Description)];
            Order = (int)@params[nameof(Order)];
            DefaultRule = (bool)@params[nameof(DefaultRule)];
        }

        [DefaultValue("")]
        public string Name { get; private set; }

        [DefaultValue("")]
        public string Description { get; private set; }

        [DefaultValue(int.MaxValue)]
        public int Order { get; private set; }

        [DefaultValue(true)]
        public bool DefaultRule { get; set; }
    }
}
