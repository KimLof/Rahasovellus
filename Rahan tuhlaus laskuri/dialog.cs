using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rahan_tuhlaus_laskuri
{
    public partial class dialog : Form
    {
        public dialog(string message)
        {
            InitializeComponent();

            Label messageLabel = new Label();
            messageLabel.Text = message;
            messageLabel.Dock = DockStyle.Fill;
            messageLabel.TextAlign = ContentAlignment.MiddleCenter;
            messageLabel.Font = new Font("Arial", 16);

            Button okButton = new Button();
            okButton.Text = "OK";
            okButton.DialogResult = DialogResult.OK;

            okButton.Width = 100; // Leveys pikseleinä
            okButton.Height = 30; // Korkeus pikseleinä

            okButton.Dock = DockStyle.Bottom;

            this.Controls.Add(okButton);

            this.AcceptButton = okButton;
            this.CancelButton = okButton;
            this.Controls.Add(messageLabel);
        }

        public static DialogResult Show(string message)
        {
            using (dialog cmb = new dialog(message))
            {
                return cmb.ShowDialog();
            }
        }
    }
}
