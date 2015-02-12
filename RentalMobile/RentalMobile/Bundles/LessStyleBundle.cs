using System.Web.Optimization;
using RentalMobile.Bundles;

namespace RentalMobile.Bundles
{
    /// <summary>
    /// Wrapper for bundle that automatically applies the less transformation and css minify in the correct order.
    /// I can use this convenience bundle all the time now, so I don't have to know when to use one or the other.
    /// </summary>
    public class CssTransformStyleBundle : Bundle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CssTransformStyleBundle"/> class.
        /// </summary>
        /// <param name="virtualPath">The virtual path.</param>
        public CssTransformStyleBundle(string virtualPath) :
            base(virtualPath, new CssUrlTransform(), new CssMinify())
        {
        }
    }
}