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
	/// Defines a custom dataset-level aggregation.
	/// </summary>
	public sealed partial class DatasetCustomMetric
	{
		/// <summary>
		/// Required. The Python code string containing the aggregation function. Expected function signature: <c>def aggregate(instances: list[dict[str, Any]]) -&gt; dict[str, float]:</c> The <c>instances</c> argument is a list of dictionaries, where each dictionary represents a single evaluation result item. The structure of each dictionary corresponds to the fields in the <c>EvaluationResult</c> message. This includes: - <c>&quot;request&quot;</c>: Contains the original input data and model inputs (from <c>EvaluationResult.EvaluationRequest</c>). - <c>&quot;candidate_results&quot;</c>: Contains the results of any instance-level metrics (from <c>EvaluationResult.CandidateResults</c>). Example of a single item in the <c>instances</c> list: { &quot;request&quot;: { &quot;prompt&quot;: {&quot;text&quot;: &quot;What is the capital of France?&quot;}, &quot;golden_response&quot;: {&quot;text&quot;: &quot;Paris&quot;}, &quot;candidate_responses&quot;: [{&quot;candidate&quot;: &quot;model-v1&quot;, &quot;text&quot;: &quot;Paris&quot;}] }, &quot;candidate_results&quot;: [ {&quot;metric&quot;: &quot;exact_match&quot;, &quot;score&quot;: 1.0}, {&quot;metric&quot;: &quot;bleu&quot;, &quot;score&quot;: 0.9} ] }
		/// </summary>
		public string? AggregationFunction { get; set; }
		/// <summary>
		/// Optional. A display name for this custom summary metric. Used to prefix keys in the output summaryMetrics map. If not provided, a default name like &quot;dataset_custom_metric_1&quot;, &quot;dataset_custom_metric_2&quot;, etc., will be generated based on the order in the repeated field.
		/// </summary>
		public string? DisplayName { get; set; }
    }
}