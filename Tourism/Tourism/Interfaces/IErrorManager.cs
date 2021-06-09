using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.Interfaces
{
    public interface IErrorManager
    {
        Task DisplayErrorMessageAsync(Exception ex, string errorMessage = null);
        void LogException(Exception ex, bool rethrow = false, [System.Runtime.CompilerServices.CallerMemberName] string caller = "");

    }
}
