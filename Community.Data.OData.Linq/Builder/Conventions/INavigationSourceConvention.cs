﻿// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License.  See License.txt in the project root for license information.

namespace Community.OData.Linq.Builder.Conventions
{
    internal interface INavigationSourceConvention : IConvention
    {
        void Apply(NavigationSourceConfiguration configuration, ODataModelBuilder model);
    }
}
