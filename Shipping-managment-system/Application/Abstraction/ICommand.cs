﻿using Ardalis.Result;
using MediatR;

namespace Shipping_managment_system.Application.Abstraction
{
    public interface ICommand<T> :IRequest<Result<T>>
    {
    }

    public interface ICommand : IRequest<Result>
    { }
}
