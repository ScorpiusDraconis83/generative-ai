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
	/// The output from a server-side <c>ToolCall</c> execution. This message contains the results of a tool invocation that was initiated by a <c>ToolCall</c> from the model. The client should pass this <c>ToolResponse</c> back to the API in a subsequent turn within a <c>Content</c> message, along with the corresponding <c>ToolCall</c>.
	/// </summary>
	public sealed partial class ToolResponse
	{
		/// <summary>
		/// Optional. The identifier of the tool call this response is for.
		/// </summary>
		public string? Id { get; set; }
		/// <summary>
		/// Optional. The tool response.
		/// </summary>
		public object? Response { get; set; }
		/// <summary>
		/// Required. The type of tool that was called, matching the <c>tool_type</c> in the corresponding <c>ToolCall</c>.
		/// </summary>
		public ToolType? ToolType { get; set; }
    }
}