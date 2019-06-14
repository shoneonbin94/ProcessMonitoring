using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Net;
using System.Media;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Newtonsoft.Json.Linq;
using System.Management;

namespace BServerMonitoring
{
    public partial class Form1 : Form
    {
        #region Cpu
        private PerformanceCounter cpu = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        private PerformanceCounter ram = new PerformanceCounter("Memory", "Available MBytes");
        private PerformanceCounter prcess_cpu = new PerformanceCounter("Process", "% Processor Time", Process.GetCurrentProcess().ProcessName);

        string strProcessName = Process.GetCurrentProcess().ProcessName;

        private bool bLoopState = true;

        Process[] processList;

        DriveInfo drvC = new DriveInfo("C");
        #endregion

        #region ini
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
                
        static string strIniPath = "ini file path";
        #endregion

        #region Music
        SoundPlayer simpleSound = new SoundPlayer(@"File path\\Filename.wav");
        #endregion

        #region Telegram
        private Telegram.Bot.TelegramBotClient Bot = new Telegram.Bot.TelegramBotClient("Token key");
        #endregion


        //------------------------------------- Event Handler ----------------------------------------------------
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread threadCpu = new Thread(Check_Cpu);
            Thread threadHard = new Thread(Load_HardDiskC);

            threadCpu.Start();
            threadHard.Start();
            
            telegramAPIAsync();                    
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;          
                this.ShowIcon = false;         
                notifyIcon1.Visible = true;                     
            }

        }
                
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowIcon = true;
            this.Visible = true;
            notifyIcon1.Visible = false;                       
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            bLoopState = false;

            if (System.Windows.Forms.MessageBox.Show("Do you want exit?", "Notice", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
                
        private void button1_Click(object sender, EventArgs e)
        {
            string strPath = "";
            string strName = "";

            CIniUtil ini = null;
            ini = new CIniUtil(strPath, strName);   

            strPath = ini.Read_IniData("DataBase", "Password");
            strPath = ini.Read_IniData("DataBase", "User");
            strPath = ini.Read_IniData("DataBase", "DBName");
            strPath = ini.Read_IniData("DataBase", "Server");
        }

        private void btn_Excute_Click(object sender, EventArgs e)
        {
            Restart_Process();
        }

        private void btn_Kill_Click(object sender, EventArgs e)
        {
            Kill_Process();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Load_Process();
        }



                //-------------------------------------- Function -------------------------------------------------------            
        private void Load_HardDiskC()
        {
            long strDrvTotal = drvC.TotalSize;                                  
            long strAvailable = drvC.AvailableFreeSpace;                            
            long strUse = drvC.TotalSize - drvC.AvailableFreeSpace;             
        
            do
            {
                if (this.InvokeRequired)
                {
                    this.lbl_DrvTotal.BeginInvoke(new Action(() =>
                    {
                        this.lbl_DrvTotal.Text = "Driver Total : " + string.Format("{0:#,###}", strDrvTotal) + " Byte";
                        this.lbl_DrvAvailable.Text = "Driver Available : " + string.Format("{0:#,###}", strAvailable) + " Byte";
                        this.lbl_DrvUse.Text = "Driver Use : " + string.Format("{0:#,###}", strUse) + " Byte";
                    }));
                }
                else
                {
                    this.lbl_DrvTotal.Text = "Driver Total : " + string.Format("{0:#,###}", strDrvTotal) + " Byte";
                    this.lbl_DrvAvailable.Text = "Driver Available : " + string.Format("{0:#,###}", strAvailable) + " Byte";
                    this.lbl_DrvUse.Text = "Driver Use : " + string.Format("{0:#,###}", strUse) + " Byte";
                }

                Thread.Sleep(1000);

            } while (bLoopState);

        }

        private void Check_Cpu()
        {
            do
            {
                if (this.InvokeRequired)
                {
                    this.lbl_Cpu.BeginInvoke(new Action(() =>
                    {
                        this.lbl_Cpu.Text = "CPU Use : " + cpu.NextValue().ToString() + " %";
                        this.lbl_Ram.Text = "Ram Available : " + ram.NextValue().ToString() + " MB";
                        this.lbl_Cpu2.Text = strProcessName + " CPU Use : " + prcess_cpu.NextValue().ToString() + " %";
                    }));
                }
                else
                {
                    this.lbl_Cpu.Text = "CPU Use : " + cpu.NextValue().ToString() + " %";
                    this.lbl_Ram.Text = "Ram Available : " + ram.NextValue().ToString() + " MB";
                    this.lbl_Cpu2.Text = strProcessName + " CPU Use : " + prcess_cpu.NextValue().ToString() + " %";
                }

                Thread.Sleep(1000);

            } while (bLoopState);
        }

        private void Kill_Process()
        {
            processList = Process.GetProcesses();
            string strKill = tb_Text.Text;

            for (int i = 0; i < processList.Length; i++)
            {
                if (processList[i].ProcessName == strKill)
                {
                    processList[i].Kill();
                }
            }
        }

        private async void Load_Process()
        {
            processList = Process.GetProcesses();
            Process process = new Process();

            lb_Process.Items.Clear();
            
            Process[] pTelegram = Process.GetProcessesByName("Telegram");

            for (int i = 0; i < processList.Length; i++)
            {
                lb_Process.Items.Add(processList[i].ProcessName);
                lb_Process.Items.Add(processList[i].Id);
                lb_Process.Items.Add("\n");
            }

            lbl_Count.Text = processList.Length.ToString();
         
            if (pTelegram.Length < 1 || pTelegram == null)
            {
                string strLog = "Telegram Close";
                Write_Log(strLog);

                Send_Telegram(strLog);

                Send_Mail(strLog);

                simpleSound.Play();

                System.Threading.Thread.Sleep(2000);
                pTelegram = Process.GetProcessesByName("Telegram");

                var vRealTelPath = ReadIniFile("ExePath", "TelegramPath", strIniPath);

                Process.Start(vRealTelPath);
            }
            else
            {
                if (pTelegram.Length >= 1)
                {
                    string strLog = "Telegram Open";
                    Write_Log(strLog);

                    simpleSound.Stop();                             
                }
            }

        }

        private void Restart_Process()
        {
            string text = tb_Text.Text;

            Process process = new Process();
            process.StartInfo.FileName = text;
            process.Start();
        }               

        private string Get_DateTime()
        {
            DateTime dtNow = DateTime.Now;

            string strNowDate = dtNow.ToString("yyyy-MM-dd HH:mm:ss") + ":" + dtNow.Millisecond.ToString("000");

            return strNowDate;
        }

        private string ReadIniFile(string section, string key, string path)
        {
            StringBuilder sb = new StringBuilder(255);
            GetPrivateProfileString(section, key, "", sb, sb.Capacity, path);

            return sb.ToString();
        }        

        private void Write_Log(string strMsg)
        {
            var vRealLogPath = ReadIniFile("LogPath", "Log", strIniPath);

            string m_strLogPrefix = vRealLogPath;
            string m_strLogExt = @".LOG";
            DateTime dtNow = DateTime.Now;
            string strDate = dtNow.ToString("yyyyMMdd");
            string strPath = String.Format("{0}{1}{2}", m_strLogPrefix, strDate, m_strLogExt);
            string strDir = Path.GetDirectoryName(strPath);
            DirectoryInfo diDir = new DirectoryInfo(strDir);

            if (!diDir.Exists)
            {
                diDir.Create();
                diDir = new DirectoryInfo(strDir);
            }

            if (diDir.Exists)
            {
                System.IO.StreamWriter swStream = System.IO.File.AppendText(strPath);
                string strLog = String.Format("{0}: {1}", dtNow.ToString("[yyyy-MM-dd HH:mm:ss") + ":" + dtNow.Millisecond.ToString("000") + "] ", strMsg);
                swStream.WriteLine(strLog);
                swStream.Close(); 
            }
        }
                
        private void Send_Mail(string Msg)
        {
            const string SMTP_SERVER = "smtp.naver.com";    //google -> smtp.google.com
            const int SMTP_PORT = 587;                      
            const string MAIL_ID = "Email";                
            const string MAIL_ID_NAME = "Id";           
            const string MAIL_PW = "Password";                

            try
            {
                MailAddress mailFrom = new MailAddress(MAIL_ID, MAIL_ID_NAME, Encoding.UTF8);
                MailAddress mailTo = new MailAddress("From to email");                               
                SmtpClient client = new SmtpClient(SMTP_SERVER, SMTP_PORT);
                MailMessage message = new MailMessage(mailFrom, mailTo);

                message.Subject = "Title";
                message.Body = Msg;
                message.BodyEncoding = Encoding.UTF8;
                message.SubjectEncoding = Encoding.UTF8;

                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new System.Net.NetworkCredential(MAIL_ID, MAIL_PW);
                client.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void telegramAPIAsync()
        {            
            var Bot = new Telegram.Bot.TelegramBotClient("Token key");
            
            var me = await Bot.GetMeAsync();
            
            //Debug.WriteLine("Hello my name is {0}", me.FirstName);        
        }

        private void Send_Telegram(string strMsg)
        {
            string urlString = "https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}";
            string apiToken = "Token Key";          
            string chatId = "@Channel Name or Group Name";                                          
            string text = strMsg;

            urlString = String.Format(urlString, apiToken, chatId, text);
            WebRequest request = WebRequest.Create(urlString);
            Stream rs = request.GetResponse().GetResponseStream();
            StreamReader reader = new StreamReader(rs);            
            StringBuilder sb = new StringBuilder();

            string line = "";
            while (line != null)
            {
                line = reader.ReadLine();
                if (line != null)
                    sb.Append(line);
            }

            string response = sb.ToString();
            
        }

    }
}



 

   