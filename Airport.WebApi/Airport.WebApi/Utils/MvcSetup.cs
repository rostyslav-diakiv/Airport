namespace Airport.WebApi.Utils
{
    using System;

    using Microsoft.AspNetCore.Mvc;

    using Newtonsoft.Json;

    public static class MvcSetup
    {
        public static Action<MvcJsonOptions> JsonSetupAction = mvcJsonOptions =>
            {
                mvcJsonOptions.SerializerSettings.ContractResolver =
                    new Newtonsoft.Json.Serialization.DefaultContractResolver();
                mvcJsonOptions.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                mvcJsonOptions.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                mvcJsonOptions.SerializerSettings.FloatFormatHandling = FloatFormatHandling.DefaultValue;
                mvcJsonOptions.SerializerSettings.FloatParseHandling = FloatParseHandling.Decimal;
                mvcJsonOptions.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            };
    }
}
