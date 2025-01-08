using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using controleDeContactos.src.Models;

/**
** @author Ramadan Ismael
*/
namespace controleDeContactos.src.config
{
    public static class Encrypt
    {
        private const int _workFactor = 12;
        public static string CreateEncrypt(this string value)
        {
            if(string.IsNullOrWhiteSpace(value)) { throw new ArgumentNullException("Error 501"); }
            try { return BCrypt.Net.BCrypt.HashPassword(value, workFactor: _workFactor); }
            catch(Exception error) { throw new InvalidOperationException(error.Message); }
        }
    }
}