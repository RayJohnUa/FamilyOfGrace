using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FM.SMSSERVICES
{
    public interface ISmsService
    {
        void Send(string to, string body);
    }
}

