using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {
        Thread serverThread;
        Server server;

        string dirPath;
        int workstationNumber;

        public Form1()
        {
            dirPath = AppDomain.CurrentDomain.BaseDirectory;
            workstationNumber = 0;
            InitializeComponent();
        }

        private void StartThread()
        {
            serverThread = new Thread(() =>
            {
                server = new Server(workstationNumber, dirPath);
                server.StartServer();
            });

            serverThread.Start();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if(serverThread == null)
            { 
                StartThread();

                statusBar.Value = 999;
                statusLabel.Text = "Server status: Active";
            }
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {

            if (serverThread.ThreadState == ThreadState.Running || serverThread != null)
            {
                server.StopServer();
                serverThread.Abort();
                serverThread = null;

                statusBar.Value = 0;
                statusLabel.Text = "Server status: Not active";
            }
        }

        private void chooseFolderBtn_Click(object sender, EventArgs e)
        {
            folderBrowser.ShowDialog();

            dirPath = folderBrowser.SelectedPath;
            filePathLabel.Text = dirPath;
        }

        private void currentPortInput_OnChangeValue(object sender, EventArgs e)
        {
            workstationNumber = int.Parse(currentPortInput.Text);
            currentPortLabel.Text = "Current port: " + (8000 + workstationNumber).ToString();
        }
    }
}
