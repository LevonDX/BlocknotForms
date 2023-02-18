using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlocknotForms
{
    public partial class FormAddRecord : Form
    {
        public Record Record { get; private set; }

        public FormAddRecord()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Record record = new Record()
            {
                Name = this.txtName.Text,
                Phone = this.txtPhone.Text
            };

            this.Record = record;
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.Cancel;
        }
    }
}
