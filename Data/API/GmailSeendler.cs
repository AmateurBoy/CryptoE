using System.Net;
using System.Net.Mail;
namespace CryptoE.Data.API
{
    public class GmailSeendler
    {
        public void Seend(string email,string from,string to, string value, string amount,int id,string wallet,bool Status)
        {
            string Statuse = "";
            if (Status == false)
            {
                Statuse = "В оброботке";
            }
            else
            {
                Statuse = "Готово.";
            }
            string WalletAdmin = "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN";
            string Title = "Crypto Exchanger";
            string message = $"Ваша заявка № {id}\n " +
                $"Стутус:{Statuse}\n" +
                $"Транзакция:\n" +
                $"{from} ({amount})  =>  {to}({value})\n" +
                $"Ожидаеться перевод на ваш кошелек:\n" +
                $"{wallet}\n" +
                $"Отправьте на этот кошелек средства для подтверждения заявки:\n" +
                $"{WalletAdmin}\n\n\n" +
                $"Контакты для связи:\n@телеграм123123\n+31242141432423412";

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
