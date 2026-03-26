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
using System.Text.Json.Serialization;

// *** AUTO-GENERATED FILE - DO NOT EDIT MANUALLY *** //

namespace Mscc.GenerativeAI.Types
{
	/// <summary>
	/// Configures the realtime input behavior in <c>BidiGenerateContent</c>.
	/// </summary>
	public partial class RealtimeInputConfig
	{
		/// <summary>
		/// Optional. Defines what effect activity has.
		/// </summary>
		public ActivityHandlingType? ActivityHandling { get; set; }
		/// <summary>
		/// Optional. If not set, automatic activity detection is enabled by default. If automatic voice detection is disabled, the client must send activity signals.
		/// </summary>
		public AutomaticActivityDetection? AutomaticActivityDetection { get; set; }
		/// <summary>
		/// Optional. Defines which input is included in the user&apos;s turn.
		/// </summary>
		public TurnCoverageType? TurnCoverage { get; set; }

		[JsonConverter(typeof(JsonStringEnumConverter<ActivityHandlingType>))]
		public enum ActivityHandlingType
		{
			/// <summary>
			/// If unspecified, the default behavior is `START_OF_ACTIVITY_INTERRUPTS`.
			/// </summary>
			ActivityHandlingUnspecified,
			/// <summary>
			/// If true, start of activity will interrupt the model&apos;s response (also called &quot;barge in&quot;). The model&apos;s current response will be cut-off in the moment of the interruption. This is the default behavior.
			/// </summary>
			StartOfActivityInterrupts,
			/// <summary>
			/// The model&apos;s response will not be interrupted.
			/// </summary>
			NoInterruption,
		}

		[JsonConverter(typeof(JsonStringEnumConverter<TurnCoverageType>))]
		public enum TurnCoverageType
		{
			/// <summary>
			/// If unspecified, a default behavior is selected based on the model. E.g., for Gemini 2.5, the default is `TURN_INCLUDES_ONLY_ACTIVITY`, while for Gemini 3.1 and onwards, it&apos;s `TURN_INCLUDES_AUDIO_ACTIVITY_AND_ALL_VIDEO`.
			/// </summary>
			TurnCoverageUnspecified,
			/// <summary>
			/// Includes activity since the last turn, excluding inactivity (e.g. silence on the audio stream).
			/// </summary>
			TurnIncludesOnlyActivity,
			/// <summary>
			/// Includes all realtime input since the last turn, including inactivity (e.g. silence on the audio stream).
			/// </summary>
			TurnIncludesAllInput,
			/// <summary>
			/// Includes audio activity and all video since the last turn. With automatic activity detection, audio activity means speech and excludes silence.
			/// </summary>
			TurnIncludesAudioActivityAndAllVideo,
		}
    }
}