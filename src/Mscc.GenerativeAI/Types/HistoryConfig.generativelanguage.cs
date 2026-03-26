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
	/// History configuration. This message is included in the session configuration as <c>BidiGenerateContentSetup.history_config</c>. Configures the exchange of history messages.
	/// </summary>
	public sealed partial class HistoryConfig
	{
		/// <summary>
		/// Optional. If true, after sending <c>setup_complete</c>, the server will wait and at first process <c>client_content</c> messages until <c>turn_complete</c> is <c>true</c>. This initial history will not trigger a model call and may end with role <c>MODEL</c>. After <c>turn_complete</c> is <c>true</c>, the client can start the realtime conversation via <c>realtime_input</c>.
		/// </summary>
		public bool? InitialHistoryInClientContent { get; set; }
    }
}