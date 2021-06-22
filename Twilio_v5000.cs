using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace ASP_CORE_SMS_SEND.SMS_SEND.Twilio_Lib
{
    interface ITwilio_v5000
    {
        MessageResource Send_Message_SMS(string Messsage_SMS_HTML, string Phone);
        Task<MessageResource> Send_Message_SMS_Asyn(string Messsage_SMS_HTML, string Phone);
    }
    public class Twilio_v5000:ITwilio_v5000
    {
        //Конструктор
        public Twilio_v5000()
        {
            TwilioClient.Init(Twilio_Option.accountSid, Twilio_Option.authToken);
        }

        public bool ErrorFlag { get; set; }

        //Можно вернуть реультаты отправки message
        public MessageResource Send_Message_SMS(string Messsage_SMS_HTML,string Phone)
        {
            MessageResource message=null;
            try
            {
                 message = MessageResource.Create(
                               to: new PhoneNumber(Phone),
                               from: new PhoneNumber(Twilio_Option.PhoneSend),
                               body: Messsage_SMS_HTML
                               );
                ErrorFlag = false;
            }
            catch (Exception ex)
            {
                ErrorFlag = true;
            }
           

            return message;
        }

        //Асинхронная отправка вернуть реультаты отправки message
        public async Task<MessageResource> Send_Message_SMS_Asyn(string Messsage_SMS_HTML, string Phone)
        {
            MessageResource message = null;
            try
            {
                message = await MessageResource.CreateAsync(
               to: new PhoneNumber(Phone),
               from: new PhoneNumber(Twilio_Option.PhoneSend),
               body: Messsage_SMS_HTML);
                ErrorFlag = false;
            }
            catch (Exception ex)
            {
                ErrorFlag = true;
            }
            
            return message;
        }
    }
}
