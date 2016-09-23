using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSLA.Classess
{
    public class AccountInfo
    {
        public string UserId { get; private set; }
        public string Lastname { get; private set; }
        public string Firstname { get; private set; }
        public string Middlename { get; private set; }
        public AccountTypeEnum AccountType { get; private set; }
        public Image Avatar { get; private set; }

        public enum AccountTypeEnum { Student, Teacher, Administrator, LimitedAccount }

        public AccountInfo(string userid,
            string lastname,
            string firstname,
            string middlename,
            AccountTypeEnum accounttype,
            Image avatar)
        {
            UserId = userid;
            Lastname = lastname;
            Firstname = firstname;
            Middlename = middlename;
            AccountType = accounttype;
            Avatar = avatar;
        }
    }
}
