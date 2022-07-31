using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LoanManagement.ViewModel.Activity
{
    public enum StatusType
    {
        [Description("bg-danger")]
        Error = 0,
        [Description("toast-info")]
        Success = 1,
        [Description("bg-warning")]
        Warning = 2,
    }
}
