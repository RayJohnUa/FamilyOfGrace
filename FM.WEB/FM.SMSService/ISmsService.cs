using System;
using System.Collections.Generic;
using System.Text;

namespace FM.SMSService
{
    public interface ISmsService
    {
        void Send(string to, string body);
    }
}
