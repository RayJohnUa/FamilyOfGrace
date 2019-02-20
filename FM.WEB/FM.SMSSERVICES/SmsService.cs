using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace FM.SMSSERVICES
{
    public class SmsService : ISmsService
    {
        const string accountSid = "AC311a96e1cf462bd252274edd585f83e3";
        const string authToken = "101575670b2ff5e8a570822eed1dd3d7";


        public SmsService()
        {
            TwilioClient.Init(accountSid, authToken);
        }

        public void Send(string to, string body)
        {
            var message = MessageResource.Create(
                body: body,
                from: new Twilio.Types.PhoneNumber("FamOfGrace"),
                to: new Twilio.Types.PhoneNumber(to)
            );

            //string[] text = { to + "  " + body + Environment.NewLine };

            //string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //File.AppendAllLines(Path.Combine(docPath, "WriteFile.txt"), text);
        }
    }
}
