namespace ClientLight.Helpers
{
    using Windows.Security.Cryptography.Certificates;
    using Windows.Web.Http.Filters;

    public class FilterProvider
    {
        public static HttpBaseProtocolFilter GetFilter()
        {
            return new HttpBaseProtocolFilter
            {
                IgnorableServerCertificateErrors = { ChainValidationResult.Untrusted | ChainValidationResult.InvalidName }
            };
        }
    }
}
