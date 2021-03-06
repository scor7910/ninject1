﻿#region License
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
using Ninject.Core;
using Ninject.Extensions.AutoWiring;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
#endregion

namespace Ninject.Tests.Extensions.AutoWiring
{
	[TestFixture]
	public class AutoWiringFieldHeuristicFixture
	{
		/*----------------------------------------------------------------------------------------*/
		[Test]
		public void HeuristicSelectsPropertiesIfTheyHaveMatchingBindings()
		{
			var testModule = new InlineModule(
				m => m.Bind<PocoForFieldAutoWiring>().ToSelf(),
				m => m.Bind<IServiceA>().To<ServiceImplA>(),
				m => m.Bind<IServiceB>().To<ServiceImplB>()
			);

			var options = new KernelOptions { InjectNonPublicMembers = true };

			using (var kernel = new StandardKernel(options, new AutoWiringModule(), testModule))
			{
				var mock = kernel.Get<PocoForFieldAutoWiring>();
				Assert.That(mock, Is.Not.Null);

				Assert.That(mock.Child, Is.Null);

				Assert.That(mock.ServiceA, Is.Not.Null);
				Assert.That(mock.ServiceA, Is.InstanceOfType(typeof(ServiceImplA)));

				Assert.That(mock.ServiceB, Is.Not.Null);
				Assert.That(mock.ServiceB, Is.InstanceOfType(typeof(ServiceImplB)));
			}
		}
		/*----------------------------------------------------------------------------------------*/
		[Test]
		public void HeuristicSelectsConstructorWithMostValidArgumentsEvenIfNotLargest()
		{
			var testModule = new InlineModule(
				m => m.Bind<PocoForFieldAutoWiring>().ToSelf(),
				m => m.Bind<IMock>().To<SimpleObject>()
			);

			var options = new KernelOptions { InjectNonPublicMembers = true };

			using (var kernel = new StandardKernel(options, new AutoWiringModule(), testModule))
			{
				var mock = kernel.Get<PocoForFieldAutoWiring>();
				Assert.That(mock, Is.Not.Null);

				Assert.That(mock.Child, Is.Not.Null);
				Assert.That(mock.Child, Is.InstanceOfType(typeof(SimpleObject)));

				Assert.That(mock.ServiceA, Is.Null);
				Assert.That(mock.ServiceB, Is.Null);
			}
		}
		/*----------------------------------------------------------------------------------------*/
	}
}
