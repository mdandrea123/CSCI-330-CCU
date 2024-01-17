using System;

namespace project
{
    public interface ICreditable
    {
        int Credits {get; set;}
        bool HasCredits();
    }
}