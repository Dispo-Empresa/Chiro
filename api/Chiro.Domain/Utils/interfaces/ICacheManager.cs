﻿namespace Chiro.Domain.Utils.interfaces
{
    public interface ICacheManager
    {
        void Add(string key, string obj, long expiration);

        string Get(string key);

        void Remove(string key);
    }
}
