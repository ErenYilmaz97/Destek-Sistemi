using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using AspCoreSupportSystem.Enums;
using Entities.Dto;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreIdentity.SMTP
{
    public static class MailHelper
    {
        
        public static void SendPetitionCreated(Petition petition, string email)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient client = new SmtpClient();

                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("erenbaba1212@gmail.com", "03123897461eren");
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;



                mail.From = new MailAddress("erenbaba1212@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Dilekçeniz Başarıyla Oluşturuldu";
                mail.Body = "<h2>Dilekçeniz Oluşturuldu. Dilekçe Bilgilerinizi Aşşağıdan Öğrenebilirsiniz.</h2><hr/>";
                mail.Body += $"<h4>Dilekçe Numarası : <b>{petition.PetitionID}</b></h4>";
                mail.Body += $"<h4>Dilekçe Konusu : <b>{petition.Summary}</b></h4>";
                mail.Body += $"<h4>Dilekçe Oluşturulma Tarihi : <b>{petition.Date}</b></h4>";
            
            
                mail.IsBodyHtml = true;


                client.Send(mail);
               
            }
            catch 
            {
               throw new ApplicationException("Mail Gönderilemedi.");
            }
        }



        public static void SendPetitionOnProcess(ListPetitionsDto petition, string email)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient client = new SmtpClient();

                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("erenbaba1212@gmail.com", "03123897461eren");
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;



                mail.From = new MailAddress("erenbaba1212@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Dilekçeniz İşleme Alındı";
                mail.Body = "<h2>Dilekçeniz İşleme Alındı. En Kısa Zamanda Size Geri Dönüş Yapılacaktır.</h2>";
                mail.Body += $"<h4>Dilekçe Numarası : <b>{petition.PetitionID}</b></h4>";
                mail.Body += $"<h4>Dilekçe Konusu : <b>{petition.Summary}</b></h4>";
                mail.Body += $"<h4>İşlem Tarihi : <b>{DateTime.Now}</b></h4>";
                mail.Body += $"<h4>Dilekçe Sahibi : <b>{petition.UserName}</b></h4>";
                mail.Body += $"<h4>Dilekçe Durumu : <b>İşleme Alındı</b></h4>";


                mail.IsBodyHtml = true;


                client.Send(mail);
            }
            catch 
            {
                throw new ApplicationException("Bir Hata Oluştu.");
            }
        }




        public static void SendPetitionToDone(ListPetitionsDto petition, string email)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient client = new SmtpClient();

                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("erenbaba1212@gmail.com", "03123897461eren");
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;



                mail.From = new MailAddress("erenbaba1212@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Dilekçeniz Tamamlandı";
                mail.Body = "<h2>Dilekçeniz Çözüme Ulaştı.</h2>";
                mail.Body += $"<h4>Dilekçe Numarası : <b>{petition.PetitionID}</b></h4>";
                mail.Body += $"<h4>Dilekçe Konusu : <b>{petition.Summary}</b></h4>";
                mail.Body += $"<h4>İşlem Tarihi : <b>{DateTime.Now}</b></h4>";
                mail.Body += $"<h4>Dilekçe Sahibi : <b>{petition.UserName}</b></h4>";
                mail.Body += $"<h4>Dilekçe Durumu : <b>Çözüldü </b></h4>";


                mail.IsBodyHtml = true;


                client.Send(mail);
                
            }
            catch
            {
                throw new ApplicationException("Bir Hata Oluştu.");
            }
        }



        public static bool SendPasswordResetMail(string link, string email)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient client = new SmtpClient();

                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("erenbaba1212@gmail.com", "03123897461eren");
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;



                mail.From = new MailAddress("erenbaba1212@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Asp Net Core Identity Şifre Sıfırlama";
                mail.Body = "<h2>Şifrenizi Sıfırlamak İçin Aşağıdaki Linke Tıklayınız</h2><hr/>";
                mail.Body += $"<a href ='{link}'> Şifre Değiştir</a>";
                mail.IsBodyHtml = true;


                client.Send(mail);
                return true;
            }
            catch
            {
                return false;
            }
        }



        public static bool SendConfirmEmail(string link, string email)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient client = new SmtpClient();

                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("erenbaba1212@gmail.com", "03123897461eren");
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;



                mail.From = new MailAddress("erenbaba1212@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Asp Net Core Identity Hesap Onaylama İşlemi";
                mail.Body = "<h2>Hesabınızı Onaylamak İçin Aşağıdaki Linke Tıklayınız</h2><hr/>";
                mail.Body += $"<a href ='{link}'> Hesabı Onaylar</a>";
                mail.IsBodyHtml = true;


                client.Send(mail);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}