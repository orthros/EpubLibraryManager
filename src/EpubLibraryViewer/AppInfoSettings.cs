using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EpubLibraryViewer
{
    public class AppInfoSettings : IAppInfoSettings
    {
        public string AboutMessage { get; private set; }
        public string ContactEmail { get; private set; }

        public AppInfoSettings(string aboutMessage, string contactEmail)
        {
            AboutMessage = aboutMessage ?? string.Empty;
            ContactEmail = contactEmail ?? string.Empty;

            if (!string.IsNullOrWhiteSpace(ContactEmail))
            {

                if (!ContactEmail.IsValidEmail())
                {
                    throw new ArgumentException($"The given input {ContactEmail} is not a valid email");
                }
            }
        }
    }

    internal static class EmailValidator
    {
        public static bool IsValidEmail(this string target)
        {
            bool isEmail = Regex.IsMatch(target, 
                                         @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", 
                                         RegexOptions.IgnoreCase);
            return isEmail;
        }
    }
}
