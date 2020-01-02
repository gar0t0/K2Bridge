// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

namespace K2Bridge.Models
{
    using System;
    using Microsoft.Extensions.Configuration;

    internal class ListenerDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListenerDetails"/> class.
        /// </summary>
        /// <param name="prefixes">The address prefix to listen on. e.g. "http://contoso.com:8080/index/".</param>
        /// <param name="metadataEndpoint">URI for metadata Elasticsearch endpoint.</param>
        private ListenerDetails(string[] prefixes, string metadataEndpoint)
        {
            if (prefixes == null || prefixes.Length == 0)
            {
                throw new ArgumentException("URI prefixes are required, for example http://contoso.com:8080/index/");
            }

            if (string.IsNullOrEmpty(metadataEndpoint))
            {
                throw new ArgumentException("URI for metadata Elasticsearch endpoint is required, for example http://127.0.0.1:8080");
            }

            Prefixes = prefixes;
            MetadataEndpoint = metadataEndpoint;
        }

        public string[] Prefixes { get; private set; }

        public string MetadataEndpoint { get; private set; }

        public static ListenerDetails MakeFromConfiguration(IConfigurationRoot config) =>
            new ListenerDetails(
                new string[] { config["bridgeListenerAddress"] },
                config["metadataElasticAddress"]);
    }
}
