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
	/// Hyperparameters for Distillation.
	/// </summary>
	public sealed partial class DistillationHyperParameters
	{
		/// <summary>
		/// Optional. Adapter size for distillation.
		/// </summary>
		public AdapterSize? AdapterSize { get; set; }
		/// <summary>
		/// Optional. Batch size for tuning. This feature is only available for open source models.
		/// </summary>
		public long? BatchSize { get; set; }
		/// <summary>
		/// Optional. Number of complete passes the model makes over the entire training dataset during training.
		/// </summary>
		public long? EpochCount { get; set; }
		/// <summary>
		/// Optional. Specifies the learning rate for tuning. Mutually exclusive with <c>learning_rate_multiplier</c>. This feature is only available for open source models.
		/// </summary>
		public double? LearningRate { get; set; }
		/// <summary>
		/// Optional. Multiplier for adjusting the default learning rate.
		/// </summary>
		public double? LearningRateMultiplier { get; set; }
    }
}