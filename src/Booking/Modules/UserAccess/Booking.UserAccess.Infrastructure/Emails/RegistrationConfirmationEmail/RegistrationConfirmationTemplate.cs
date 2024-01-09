using Booking.BuildingBlocks.Infrastructure;

namespace Booking.UserAccess.Infrastructure.Emails.RegistrationConfirmationEmail
{
    public class RegistrationConfirmationTemplate : EmailTemplate
    {

        public static readonly string ConfirmationLink = "{{confirmation-link}}";

        private string template = $@"
            <!DOCTYPE html>
            <html>
            <head>
                <title>Confirmation Email</title>
                <style>
                    .button {{
                        display: inline-block;
                        padding: 10px 20px;
                        margin: 20px 0;
                        background-color: #4CAF50;
                        color: white;
                        text-align: center;
                        text-decoration: none;
                        font-size: 16px;
                        border-radius: 5px;
                        transition: background-color 0.3s;
                    }}
                    .button:hover {{
                        background-color: #45a049;
                    }}
                    .container {{
                        width: 80%;
                        margin: 0 auto;
                        padding: 20px;
                        text-align: center;
                    }}
                </style>
            </head>
            <body>
                <div class='container'>
                    <h1>Confirm Your Email</h1>
                    <p>To complete your registration, please confirm your email address by clicking the button below.</p>
                    <a href='{ConfirmationLink}' class='button'>Confirm Email</a>
                </div>
            </body>
            </html>";

        protected override string GetEmailTemplate()
        {
            return template;
        }
    }
}
