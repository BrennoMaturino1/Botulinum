using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Botulinum
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DialogResult dialogResult = MessageBox.Show("WARNING!\nYou are going to execute a malware called \"Botulinum.exe\"\nI am not responsible if you damage your computer with this, this malware was never made for malicious porpuses, run it at your own risk", "Botulinum.exe", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.No)
            {
                Environment.Exit(0);
            }
            dialogResult = MessageBox.Show("FINAL WARNING!\nYou are going to execute a malware called \"Botulinum.exe\"\nThe damage made by this malware is irreversible, and this was never made for malicious porpuses so\nUSE IT AT YOUR OWN RISK", "Botulinum.exe", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (dialogResult == DialogResult.No)
            {
                Environment.Exit(0);
            }

            dialogResult = MessageBox.Show("Do you wish to use safe mode (no system damage?)", "Botulinum.exe", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.Yes)
            {
                Form1.SafeMode = true;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
