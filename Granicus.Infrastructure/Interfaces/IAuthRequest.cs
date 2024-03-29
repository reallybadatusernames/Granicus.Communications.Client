﻿namespace Granicus.Infrastructure.Interfaces
{
    public interface IAuthRequest
    {
        string AccountCode { get; set; }

        string UserName { get; set; }

        string Password { get; set; }

        string Uri { get; set; }
    }
}
