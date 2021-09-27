using System;
using System.Collections.Generic;
using System.Text;

namespace swirepaysdk.Model.Account
{
   public class Account
    {
        string gid { get; set; }

        public Account(string gid)
        {
            this.gid = gid;
        }
    }
}
