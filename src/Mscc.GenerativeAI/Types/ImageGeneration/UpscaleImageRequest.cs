namespace Mscc.GenerativeAI
{
    /// <summary>
    /// Request for image upscaling.
    /// </summary>
    public class UpscaleImageRequest : ImageGenerationRequest
    {
        /// <summary>
        /// Configuration for image upscaling.
        /// </summary>
        public UpscaleImageConfig? Config { get; set; }
    }
}