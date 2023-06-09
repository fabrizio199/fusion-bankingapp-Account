﻿// Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved
// SPDX-License-Identifier:  Apache-2.0

namespace WebsiteConfigExample
{
    using System;
    using System.Threading.Tasks;
    using Amazon;
    using Amazon.S3;
    using Amazon.S3.Model;

    /// <summary>
    /// This example uses Amazon Simple Storage Service (Amazon S3) to
    /// configure a static website in an Amazon S3 bucket. The example was
    /// created using AWS SDK for .NET version 3.7 and .NET Core 5.0.
    /// </summary>
    public class S3_Write
    {
        /// <summary>
        /// The Main method initializes the values for Amazon Simple Storage
        /// Service (Amazon S3) and the document and error document suffix
        /// values.
        /// </summary>
        public static async Task Main()
        {
            const string bucketName = "S3_1";
//            string bn = "S3_BucketName";
//            const string bucketName = ConfigurationManager.AppSettings[bn];
            const string indexDocumentSuffix = "index.html";
            const string errorDocument = "error.html";

            // Specify the region for your S3 bucket if it is different from the region
            // of the default user. RegionEndpoint.USWest2 for example.
            IAmazonS3 client = new AmazonS3Client(RegionEndpoint.USEast1);

            await AddWebsiteConfigurationAsync(client, bucketName, indexDocumentSuffix, errorDocument);
        }

        /// <summary>
        /// This method first adds and then checks the configuration for a
        /// static website in an S3 bucket.
        /// </summary>
        /// <param name="client">The S3 client used to add and then check the
        /// website configuration.</param>
        /// <param name="bucketName">The name of the bucket that will serve as
        /// a static website.</param>
        /// <param name="indexDocumentSuffix">The index document suffix for the
        /// website.</param>
        /// <param name="errorDocument">The name of the error document for the
        /// static website.</param>
        public static async Task AddWebsiteConfigurationAsync(
            IAmazonS3 client,
            string bucketName,
            string indexDocumentSuffix,
            string errorDocument)
        {
            try
            {
                // Put the website configuration.
                PutBucketWebsiteRequest putRequest = new PutBucketWebsiteRequest()
                {
                    BucketName = bucketName,
                    WebsiteConfiguration = new WebsiteConfiguration()
                    {
                        IndexDocumentSuffix = indexDocumentSuffix,
                        ErrorDocument = errorDocument,
                    },
                };
                PutBucketWebsiteResponse response = await client.PutBucketWebsiteAsync(putRequest);

            }
            catch (AmazonS3Exception ex)
            {
                Console.WriteLine($"Error encountered on server. Message:'{ex.Message}' when writing an object.");
            }
        }

	}
}
