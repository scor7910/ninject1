#region License
//
// Author: Nate Kohari <nkohari@gmail.com>
// Copyright (c) 2007-2008, Enkari, Ltd.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion
#region Using Directives
using System;
using System.Collections.Generic;
using System.Reflection;
using Ninject.Core;
using Ninject.Core.Activation;
using Ninject.Core.Binding;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
#endregion

namespace Ninject.Tests
{
	[TestFixture]
	public class AutoModuleFixture
	{
		/*----------------------------------------------------------------------------------------*/
		[Test]
		public void AutoModuleRegistersServiceBindingForTypesWithServiceAttribute()
		{
			AutoModule module = new AutoModule(Assembly.GetExecutingAssembly());

			using (var kernel = new StandardKernel(module))
			{
				ICollection<IBinding> bindings = kernel.Components.BindingRegistry.GetBindings(typeof(IMock));
				Assert.That(bindings, Is.Not.Null);
				Assert.That(bindings, Is.Not.Empty);

				var mock = kernel.Get<IMock>();
				Assert.That(mock, Is.Not.Null);
				Assert.That(mock, Is.InstanceOfType(typeof(ObjectWithServiceBindingServiceAttribute)));
			}
		}
		/*----------------------------------------------------------------------------------------*/
		[Test]
		public void AutoModuleRegistersSelfBindingForTypesWithServiceAttribute()
		{
			AutoModule module = new AutoModule(Assembly.GetExecutingAssembly());

			using (var kernel = new StandardKernel(module))
			{
				ICollection<IBinding> bindings = kernel.Components.BindingRegistry.GetBindings(typeof(ObjectWithSelfBindingServiceAttribute));
				Assert.That(bindings, Is.Not.Null);
				Assert.That(bindings, Is.Not.Empty);

				var mock = kernel.Get<ObjectWithSelfBindingServiceAttribute>();
				Assert.That(mock, Is.Not.Null);
			}
		}
		/*----------------------------------------------------------------------------------------*/
		[Test]
		public void AutoModuleRegistersProviderBindingForTypesWithServiceAttribute()
		{
			var module = new AutoModule(Assembly.GetExecutingAssembly());

			using (var kernel = new StandardKernel(module))
			{
				Type type = typeof(ObjectWithProviderBindingServiceAttribute);

				IContext context = kernel.Components.ContextFactory.Create(type);
				IBinding binding = kernel.Components.BindingSelector.SelectBinding(type, context);

				Assert.That(binding, Is.Not.Null);
				Assert.That(binding.Provider, Is.InstanceOfType(typeof(ServiceAttributeObjectProvider)));

				var mock = kernel.Get<ObjectWithProviderBindingServiceAttribute>();
				Assert.That(mock, Is.Not.Null);
			}
		}
		/*----------------------------------------------------------------------------------------*/
	}
}