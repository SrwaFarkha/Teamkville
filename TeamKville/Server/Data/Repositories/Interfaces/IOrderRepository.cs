﻿namespace TeamKville.Server.Data.Repositories.Interfaces;

public interface IOrderRepository<T>
{
	Task<string> AddItemAsync (T item);
	Task<IEnumerable<T>> GetByUserIdentity(string email);
	Task<string> PatchOrder(T item);
}