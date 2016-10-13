﻿// ==========================================================================
//  TypeNameSerializationBinder.cs
//  PinkParrot Headless CMS
// ==========================================================================
//  Copyright (c) PinkParrot Group
//  All rights reserved.
// ==========================================================================

using System;
using Newtonsoft.Json.Serialization;

namespace PinkParrot.Infrastructure.Json
{
    public class TypeNameSerializationBinder : DefaultSerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            var type = TypeNameRegistry.GetType(typeName);

            return type ?? base.BindToType(assemblyName, typeName);
        }

        public override void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            assemblyName = null;

            var name = TypeNameRegistry.GetName(serializedType);

            if (name != null)
            {
                typeName = name;
            }
            else
            {
                base.BindToName(serializedType, out assemblyName, out typeName);
            }
        }
    }
}
