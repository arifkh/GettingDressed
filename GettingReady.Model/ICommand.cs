using System;

namespace GettingReady.Model
{
    public interface ICommand
    {
        String Print(Mode mode);
        bool CanPrint(Mode mode);
    }
}
