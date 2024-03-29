﻿using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace OpayoPaymentsNet.Domain.Entities.Transactions.Responses
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum OpayoTransactionStatus
    {
        /// <summary>
        /// Transaction request completed successfully.
        /// </summary>
        Ok,
        /// <summary>
        /// Transaction request was not authorised by the bank.
        /// </summary>
        NotAuthed,
        /// <summary>
        /// Transaction rejected by your fraud rules.
        /// </summary>
        Rejected,
        /// <summary>
        /// Missing properties or badly formed body.
        /// </summary>
        Malformed,
        /// <summary>
        /// Invalid property values supplied.
        /// </summary>
        Invalid,
        /// <summary>
        /// An error occurred at Opayo.
        /// </summary>
        Error,
        /// <summary>
        /// Transaction has been registered (Authenticate transaction)
        /// </summary>
        Registered,
        /// <summary>
        /// Transaction has been authenticated (Authenticate transaction)
        /// </summary>
        Authenticated,
        /// <summary>
        /// Redirect (PayPal)
        /// </summary>
        Redirect,
        /// <summary>
        /// Transaction requires redirection for 3D Secure Challenge
        /// </summary>
        [EnumMember(Value = "3DAuth")]
        ThreeDAuth
    }
}
