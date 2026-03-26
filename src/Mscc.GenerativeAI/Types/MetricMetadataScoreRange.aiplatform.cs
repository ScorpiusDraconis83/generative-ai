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
	/// The range of possible scores for this metric, used for plotting.
	/// </summary>
	public sealed partial class MetricMetadataScoreRange
	{
		/// <summary>
		/// Optional. The description of the score explaining the directionality etc.
		/// </summary>
		public string? Description { get; set; }
		/// <summary>
		/// Required. The maximum value of the score range (inclusive).
		/// </summary>
		public double? Max { get; set; }
		/// <summary>
		/// Required. The minimum value of the score range (inclusive).
		/// </summary>
		public double? Min { get; set; }
		/// <summary>
		/// Optional. The distance between discrete steps in the range. If unset, the range is assumed to be continuous.
		/// </summary>
		public double? Step { get; set; }
    }
}