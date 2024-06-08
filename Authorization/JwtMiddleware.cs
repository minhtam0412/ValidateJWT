﻿using ValidateJWT.Services;

namespace ValidateJWT.Authorization
{
    public class JwtMiddleware(RequestDelegate next)
    {
        public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateToken(token);
            if (userId != null)
            {
                // attach user to context on successful jwt validation
                context.Items["User"] = userService.GetById(userId.Value);
            }

            await next(context);
        }
    }
}
