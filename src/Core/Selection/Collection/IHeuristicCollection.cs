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
using Ninject.Core.Binding;
using Ninject.Core.Planning;
#endregion

namespace Ninject.Core.Selection
{
	/// <summary>
	/// Collects <see cref="IHeuristic{T}"/>s. and organizes them by type.
	/// </summary>
	public interface IHeuristicCollection
	{
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Adds the specified heuristic to the collection.
		/// </summary>
		/// <typeparam name="TMember">The type of member the heuristic examines.</typeparam>
		/// <param name="heuristic">The heuristic to add.</param>
		void Add<TMember>(IHeuristic<TMember> heuristic) where TMember : MemberInfo;
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Gets all registered heuristics that examine the specified type of member.
		/// </summary>
		/// <typeparam name="TMember">The type of member.</typeparam>
		/// <returns>The series of heuristics that examine the type of member.</returns>
		IEnumerable<IHeuristic<TMember>> GetAll<TMember>() where TMember : MemberInfo;
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Removes all registered heuristics that examine the specified type of member.
		/// </summary>
		/// <typeparam name="TMember">The type of member.</typeparam>
		void RemoveAll<TMember>() where TMember : MemberInfo;
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Clears all heuristics from the collection.
		/// </summary>
		void Clear();
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Returns a value indicating whether at least one of the registered heuristics indicates
		/// that the specified member should be injected. 
		/// </summary>
		/// <param name="binding">The binding that points at the type whose activation plan being manipulated.</param>
		/// <param name="plan">The activation plan that is being manipulated.</param>
		/// <param name="candidates">The candidates that are available.</param>
		/// <param name="member">The member in question.</param>
		/// <returns><see langword="True"/> if the member should be injected, otherwise <see langword="false"/>.</returns>
		bool ShouldInject<TMember>(IBinding binding, IActivationPlan plan, IEnumerable<TMember> candidates, TMember member) where TMember : MemberInfo;
		/*----------------------------------------------------------------------------------------*/
	}
}