﻿namespace Library.Domain.Exceptions
{
    // Wyjątek: Zasób nie został znaleziony
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }
}