using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.ViewModel.ResponseModel
{
   public class ResponseModel<T>
    {
        public ResponseModel()
        {
            Messages = new List<string>();
        }

        public bool Status { get; set; } = false;
        public List<string> Messages { get; set; }
        public T Data { get; set; }
    }
}
