﻿namespace SocialNetwork.Business.Wrapper.Interfaces
{
    public interface IDataResponse<T> : IResponse
    {
        T Data { get; }
        string Message { get; }
    }
}
