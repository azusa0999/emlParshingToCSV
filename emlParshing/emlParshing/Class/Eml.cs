using System;
using System.Collections.Generic;
using System.Text;
using EAGetMail;

namespace emlParshing.Class
{
    public class Eml
    {
        /// <summary>
        /// eml 파일을 파싱하여 반환한다.
        /// </summary>
        /// <param name="emlFile"></param>
        public string ReadString(string emlFile)
        {
            Mail oMail = new Mail("TryIt");
            oMail.Load(emlFile, false);
            return oMail.TextBody;
        }

    }
}
