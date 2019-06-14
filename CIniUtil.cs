using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace BServerMonitoring
{
    public class CIniUtil
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        private string strIniPath;

        public CIniUtil(string strFilePath, string strIniName)
        {
            strIniPath = strFilePath + strIniName + ".ini";
        }

        public string GetIniPath()
		{
			return strIniPath;
		}

		public void SetIniPath(string strIniFullPath)
        {
			if (!System.IO.File.Exists(strIniFullPath))
			{
				//Msg.MsgErrOkOnly(strIniFullPath + "파일이 존재하지 않습니다.");
				strIniPath = "";
				return;
			}
			strIniPath = strIniFullPath;
		}

        public string Read_IniData(string section, string key)
        {
            StringBuilder strVal = new StringBuilder(255);
            
            GetPrivateProfileString(section, key, "", strVal, 255, strIniPath);

            return strVal.ToString();
        }

        public void Write_IniData(string section, string key, string val)
        {
            WritePrivateProfileString(section, key, val, strIniPath);
        }
    }
}
