using System;

namespace SqlSearchQuery.BackroundServices;

public interface IEmailSender
{
    Task SendEmailAsync(string CompanyEmail, string CompanyName, string OfferEmail, string Title, string Message, string NameSurname);

}
