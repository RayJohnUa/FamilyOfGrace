using System;
using System.Collections.Generic;
using System.Text;

namespace SmsService
{
    public interface ISmsService
    {
        void Send(string to, string body);
    }
}
