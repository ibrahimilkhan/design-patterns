using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Body mesaj = new Body() { Title = "Uyarı", Text = "Bu bir uyarıdır!" };

            //MailSender mail1 = new MailSender();
            //mail1.Send(mesaj);
            //mail1.Save();

            //SmsSender sms1 = new SmsSender();
            //sms1.Send(mesaj);
            //sms1.Save();


            CustomerManager cm = new CustomerManager();
            cm.MessageManagerBase = new MailSender();
            cm.UpdateCustomer();

            Console.ReadKey();
        }
    }

    abstract class MessageManagerBase
    {
        public void Save()
        {
            Console.WriteLine("Message saved.");
        }
        public abstract void Send(Body body);
    }

    class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }

    class MailSender : MessageManagerBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine($" Konu: {body.Title}\n Mesaj: {body.Text} \n Mail ile gönderildi  ");
        }
    }
    class SmsSender : MessageManagerBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine($"Konu:{body.Title}\nMesaj:{body.Text}\nSms ile gönderildi.");
        }
    }

    class CustomerManager 
    {
        public MessageManagerBase MessageManagerBase{ get; set; }
        public void UpdateCustomer() 
        {
            MessageManagerBase.Send(new Body() { Title="About the Customer"});
            Console.WriteLine("Customer updated.");
        }
    }
}
