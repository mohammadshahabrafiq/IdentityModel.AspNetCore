// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityModel.AspNetCore.AccessTokenManagement
{
    /// <summary>
    /// Storage abstraction for access and refresh tokens
    /// </summary>
    public interface IUserAccessTokenStore
    {
        /// <summary>
        /// Stores tokens
        /// </summary>
        /// <param name="user">User the tokens belong to</param>
        /// <param name="accessToken">The access token</param>
        /// <param name="expiration">The access token expiration</param>
        /// <param name="refreshToken">The refresh token (optional)</param>
        /// <param name="parameters">Extra optional parameters</param>
        /// <returns></returns>
        Task StoreTokenAsync(ClaimsPrincipal user, string accessToken, DateTimeOffset expiration, string refreshToken = null, UserAccessTokenParameters parameters = null);

        /// <summary>
        /// Retrieves tokens from store
        /// </summary>
        /// <param name="user">User the tokens belong to</param>
        /// <param name="parameters">Extra optional parameters</param>
        /// <returns>access and refresh token and access token expiration</returns>
        Task<UserAccessToken> GetTokenAsync(ClaimsPrincipal user, UserAccessTokenParameters parameters = null);

        /// <summary>
        /// Clears the stored tokens for a given user
        /// </summary>
        /// <param name="user">User the tokens belong to</param>
        /// <param name="parameters">Extra optional parameters</param>
        /// <returns></returns>
        Task ClearTokenAsync(ClaimsPrincipal user, UserAccessTokenParameters parameters = null);
    }
}