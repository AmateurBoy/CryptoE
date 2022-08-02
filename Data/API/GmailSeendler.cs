using System.Net;
using System.Net.Mail;
namespace CryptoE.Data.API
{
    public class GmailSeendler
    {
        public void Seend(string email,string from,string to, string value, string amount,int id,string wallet,bool Status)
        {
            string WalletAdmin = "";
            string Statuse = "";
            if (Status == false)
            {
                Statuse = "В оброботке";
            }
            else
            {
                Statuse = "Готово.";
            }
            if(to=="USDT")
            {
                WalletAdmin = "TMVp1NN6RGBtGuJUgmxhB7fx2JcWcAUGrn";
            }
            if (to == "BUSD")
            {
                WalletAdmin = "0x49f2E76aAaB756315bF999e0A903668541E33426";
            }
            if (to == "USDC")
            {
                WalletAdmin = "0x49f2E76aAaB756315bF999e0A903668541E33426";
            }



            string Title = "Crypto Exchanger";
            string message = $"Ваша заявка № {id}<br/> " +
                $"Стутус:{Statuse}<br/>" +
                $"Транзакция:<br/>" +
                $"{from} ({amount})  =>  {to}({value})<br/>" +
                $"Ожидаеться перевод на ваш кошелек:<br/>" +
                $"{wallet}<br/>" +
                $"Отправьте на этот кошелек средства для подтверждения заявки:<br/>" +
                $"{WalletAdmin}<br/><br/><br/>" +
                $"Контакты для связи:<br/>@телеграм123123<br/>+31242141432423412";

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("exchangerseender@gmail.com");
                mail.To.Add($"{email}");
                mail.Subject = $"{Title}";
                mail.Body = $"{message}";
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("C:\\file.zip"));

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("exchangerseender@gmail.com", "qmortdoipszfxfuj");
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                    smtp.Send(mail);
                    Console.WriteLine("Готово.");
                }
            }
        }
    }
}
