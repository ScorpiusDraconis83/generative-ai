/*
 * Copyleft 2024-2025 Jochen Kirstätter and contributors
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      https://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

// *** AUTO-GENERATED FILE - DO NOT EDIT MANUALLY *** //

namespace Mscc.GenerativeAI.Types
{
	/// <summary>
	/// A predicted server-side <c>ToolCall</c> returned from the model. This message contains information about a tool that the model wants to invoke. The client is NOT expected to execute this <c>ToolCall</c>. Instead, the client should pass this <c>ToolCall</c> back to the API in a subsequent turn within a <c>Content</c> message, along with the corresponding <c>ToolResponse</c>.
	/// </summary>
	public sealed partial class ToolCall
	{
		/// <summary>
		/// Optional. The tool call arguments. Example: {&quot;arg1&quot; : &quot;value1&quot;, &quot;arg2&quot; : &quot;value2&quot; , ...}
		/// </summary>
		public object? Args { get; set; }
		/// <summary>
		/// Optional. Unique identifier of the tool call. The server returns the tool response with the matching <c>id</c>.
		/// </summary>
		public string? Id { get; set; }
		/// <summary>
		/// Required. The type of tool that was called.
		/// </summary>
		public ToolType? ToolType { get; set; }
    }
}