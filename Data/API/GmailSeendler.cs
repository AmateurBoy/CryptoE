using CryptoE.Controllers;
using CryptoE.Data.Entitys;
using CryptoE.TelegramBot;
using System.Net;
using System.Net.Mail;
namespace CryptoE.Data.API
{
    public class GmailSeendler
    {
        public void Seend(ClientApplication CA,bool Status)
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
            WalletAdmin = Singleton.GetWallet(CA.from);



            string Title = "Crypto Exchanger";

            string message = $"Your application № {CA.Id}<br/> " +
                $"Status:{Statuse}<br/>" +
                $"Transaction:{CA.Network} <br/>" +
                $"{CA.from} ({CA.amount})  =>  {CA.to}({CA.result})<br/>" +
                $"Transfer to your wallet is expected:<br/>" +
                $"{CA.wallend}<br/>" +
                $"Send funds to this wallet to confirm the application:<br/>" +
                $"{WalletAdmin}<br/><br/><br/>" +
                $"Contacts for communication:<br/> <a href='http://t.me/cryptoexchangr'></a>";

            string messageTelega = $"Новая заявка № {CA.Id}\n " +
                $"Статус:{Statuse}\n " +
                $"Транзакция:{CA.Network} \n " +
                $"{CA.from} ({CA.amount})  =>  {CA.to}({CA.result})\n " +
                $"На этот отпрвить:\n " +
                $"{CA.wallend}\n " +
                $"На этот должны прийти средства:\n " +
                $"{WalletAdmin}";
            try
            {
                BotController.MessageTelegram(messageTelega);
            }
            catch
            {

            }
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("exchangerseender@gmail.com");
                mail.To.Add($"{CA.email}");
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
