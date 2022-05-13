﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEye
{
    public class SubProcess
    {
        public void RunEncod()
        {
            //if (Program.Ip == null)
            //{
            //    MessageBox.Show("Set IP first");
            //    return;
            //}
            //run_cmd(".\\CommunicationModule\\client.py", "-i " + Program.Ip.ToString() + " -p 64000");
        }
        public void RunDecod()
        {
            MessageBox.Show("In RunDecod");
        }

        private void run_cmd(string cmd, string args)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python.exe";
            start.Arguments = string.Format("{0} {1}", cmd, args);
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            Process? process = Process.Start(start);
            if (process == null)
            {
                Program.log += "[ERROR][RUN_CMD] Cannot start process\n";
                return;
            }
            else
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Program.log += "[PYTHON][" + cmd + "] " + result + "\n";
                }
            }
        }

        internal void ClientPythonLaunch(object? obj)
        {
            if (Program.Ip == null)
            {
                MessageBox.Show("Set IP first");
                return;
            }
            run_cmd(".\\CommunicationModule\\client.py", "-i " + Program.Ip.ToString() + " -p 64000");
        }
    }
}
