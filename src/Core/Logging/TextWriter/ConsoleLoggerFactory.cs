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

namespace Ninject.Core.Logging
{
	/// <summary>
	/// A logger factory that creates <see cref="TextWriterLogger"/> that write to <see cref="Console.Out"/>.
	/// </summary>
	public class ConsoleLoggerFactory : LoggerFactoryBase
	{
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Creates a logger for the specified type.
		/// </summary>
		/// <param name="type">The type to create the logger for.</param>
		/// <returns>The newly-created logger.</returns>
		protected override ILogger CreateLogger(Type type)
		{
			return new TextWriterLogger(type, Console.Out);
		}
		/*----------------------------------------------------------------------------------------*/
	}
}