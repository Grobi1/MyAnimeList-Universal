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
        private static string resourceName = "MyAnimeListLogIn";
        public static async Task<bool> SaveCredentials(string username, string password)
        {
            var vault = new PasswordVault();
            RemoveCredentials();

            vault.Add(new PasswordCredential(resourceName, username, password));
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
