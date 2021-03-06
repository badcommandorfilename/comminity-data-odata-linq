﻿// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License.  See License.txt in the project root for license information.

namespace Community.OData.Linq.Builder.Conventions.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using Community.OData.Linq.Common;

    using Microsoft.OData.Edm;

    /// <summary>
    /// Ignores properties with the NotMappedAttribute from <see cref="IEdmStructuredType"/>.
    /// </summary>
    internal class NotMappedAttributeConvention : AttributeEdmPropertyConvention<PropertyConfiguration>
    {
        // .net 4.5 NotMappedAttribute has the same name.
        private const string EntityFrameworkNotMappedAttributeTypeName = "System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute";

        private static Func<Attribute, bool> _filter = attribute =>
        {
            return attribute.GetType() == typeof(NotMappedAttribute);
        };

        public NotMappedAttributeConvention()
            : base(_filter, allowMultiple: false)
        {
        }

        public override void Apply(PropertyConfiguration edmProperty,
            StructuralTypeConfiguration structuralTypeConfiguration,
            Attribute attribute,
            ODataConventionModelBuilder model)
        {
            if (edmProperty == null)
            {
                throw Error.ArgumentNull("edmProperty");
            }

            if (structuralTypeConfiguration == null)
            {
                throw Error.ArgumentNull("structuralTypeConfiguration");
            }

            if (!edmProperty.AddedExplicitly)
            {
                structuralTypeConfiguration.RemoveProperty(edmProperty.PropertyInfo);
            }
        }
    }
}
