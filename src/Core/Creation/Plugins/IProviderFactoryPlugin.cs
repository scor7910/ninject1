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
#endregion

namespace Ninject.Core.Creation
{
	/// <summary>
	/// A plugin for a <see cref="IProviderFactory"/> that can create <see cref="IProvider"/>s.
	/// </summary>
	public interface IProviderFactoryPlugin : ICondition<Type>
	{
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Creates a provider for the specified type.
		/// </summary>
		/// <param name="type">The type to create a provider for.</param>
		/// <returns>The provider.</returns>
		IProvider Create(Type type);
		/*----------------------------------------------------------------------------------------*/
	}
}