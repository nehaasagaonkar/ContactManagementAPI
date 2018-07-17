using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Models.ApplicationLogger
{
    public static class LogException
    {

        private static readonly string _LogFilePath = ConfigurationManager.AppSettings["Err_File_Path"].ToString();
        public static void Write(object message, Exception ex = null)
        {
            try {
                FileStream objFilestream = new FileStream(_LogFilePath, FileMode.Append, FileAccess.Write);
                StreamWriter objStreamWriter = new StreamWriter((Stream)objFilestream);
                objStreamWriter.WriteLine(message+ "\t" + DateTime.Now);
                objStreamWriter.WriteLine(ex+"\n");
                objStreamWriter.Close();
                objFilestream.Close();
                
            }
            catch (Exception exception)
            {

            }
        }
    }
}
