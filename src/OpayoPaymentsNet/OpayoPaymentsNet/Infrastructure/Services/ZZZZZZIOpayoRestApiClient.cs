////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;
////using System.Threading.Tasks;

////namespace OpayoPaymentsNet.Infrastructure.Services.OpayoRestApiClient
////{
////    public interface IOpayoRestApiClient
////    {
////        /// <summary>
////        /// Adds basic authentication using the Integration Key and Password.
////        /// This is the standard way to integrate with the Opayo REST API.
////        /// </summary>
////        /// <param name="integrationKey"></param>
////        /// <param name="password"></param>
////        /// <returns></returns>
////        IOpayoRestApiClientWithAuthentication WithAuthentication(string integrationKey, string password);

////        /// <summary>
////        /// Adds bearer authentication using a Merchant Session Key.
////        /// This is required for (and only used by) the card identifiers endpoint.
////        /// </summary>
////        /// <param name="merchantSessionKey"></param>
////        /// <returns></returns>
////        IOpayoRestApiClientWithAuthentication WithAuthentication(string merchantSessionKey);
////    }

////    public interface IOpayoRestApiClientWithAuthentication : IOpayoRestApiClientWithPayload
////    {
////        IOpayoRestApiClientWithPayload WithPayload<T>(T payload);
////    }

////    public interface IOpayoRestApiClientWithPayload
////    {

////    }
////}
