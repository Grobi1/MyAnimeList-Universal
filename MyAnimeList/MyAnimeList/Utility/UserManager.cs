using MyAnimeList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Credentials;

namespace MyAnimeList.Utility
{
    public static class UserManager
    {

        private static User _serviceUser;
        private static string resourceName = "MyAnimeListLogIn";

        public static User ServiceUser
        {
            get
            {
                if (_serviceUser == null)
                    _serviceUser = new User();
                return _serviceUser;
            }

            set
            {
                _serviceUser = value;
            }
        }

        public static bool SaveCredentials(string username, string password)
        {
            var vault = new PasswordVault();
            RemoveCredentials();

            vault.Add(new PasswordCredential(resourceName, username, password));
            ServiceUser.Name = username;
            return true;
        }

        public static PasswordCredential GetCredentialFromLocker()
        {
            PasswordCredential credential = null;

            var vault = new PasswordVault();
            var credentialList = vault.FindAllByResource(resourceName);
            if (credentialList.Count > 0)
            {
                credential = credentialList[0];
            }
            ServiceUser.Name = credential.UserName;
            return credential;
        }

        public static void RemoveCredentials()
        {
            var vault = new PasswordVault();
            try
            {
                var credentialList = vault.FindAllByResource(resourceName);
                foreach (var credential in credentialList)
                    vault.Remove(credential);
                ServiceUser = null;
            }
            catch { }
        }

        public static bool HasCredentials()
        {
            var vault = new PasswordVault();
            try
            {
                var credentialList = vault.FindAllByResource(resourceName);
                if (credentialList.Count > 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
