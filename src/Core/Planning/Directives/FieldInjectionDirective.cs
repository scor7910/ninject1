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
using System.Reflection;
using System.Text;
using Ninject.Core.Planning.Targets;
#endregion

namespace Ninject.Core.Planning.Directives
{
	/// <summary>
	/// A directive that describes a field injection.
	/// </summary>
	public class FieldInjectionDirective : SingleInjectionDirective<FieldInfo>
	{
		/*----------------------------------------------------------------------------------------*/
		#region Constructors
		/// <summary>
		/// Creates a new FieldInjectionDirective.
		/// </summary>
		/// <param name="member">The member that the directive relates to.</param>
		public FieldInjectionDirective(FieldInfo member)
			: base(member, new FieldTarget(member))
		{
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region Protected Methods
		/// <summary>
		/// Builds the value that uniquely identifies the directive. This is called the first time
		/// the key is accessed, and then cached in the directive.
		/// </summary>
		/// <returns>The directive's unique key.</returns>
		protected override object BuildKey()
		{
			StringBuilder sb = new StringBuilder();

			sb.Append(Member.Name);
			sb.Append(Member.FieldType);

			return sb.ToString();
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
	}
}