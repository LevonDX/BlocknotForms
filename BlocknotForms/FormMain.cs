namespace BlocknotForms
{
    public partial class FormMain : Form
    {
        List<Record> records = new List<Record>();
        private const string FileName = "Blocknot.txt";

        public FormMain()
        {
            InitializeComponent();

            LoadFromFile();
            UpdateListBox(this.records);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAddRecord formAddRecord = new FormAddRecord();
            if (formAddRecord.ShowDialog() == DialogResult.OK)
            {
                Record record = formAddRecord.Record;

                this.records.Add(record);
                UpdateListBox(this.records);
            }
        }

        void UpdateListBox(IEnumerable<Record> records)
        {
            this.lbRecords.Items.Clear();

            foreach (Record item in records)
            {
                this.lbRecords.Items.Add(item);
            }
        }

        void SaveToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(FileName))
                {
                    foreach (Record record in this.records)
                    {
                        writer.WriteLine(record);
                    }
                }

                MessageBox.Show("Successfuly saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void LoadFromFile()
        {
            if (!File.Exists(FileName))
                return;

            using (StreamReader reader = new StreamReader(FileName))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    Record record = Record.Parse(line);
                    this.records.Add(record);
                }
            }
        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            var filteredRecords = this.records
                .Where(r => r.Name.Contains(this.txtFilter.Text.Trim(), StringComparison.OrdinalIgnoreCase));


            filteredRecords = from r in filteredRecords
                              where r.Name.Contains(this.txtFilter.Text.Trim(), StringComparison.OrdinalIgnoreCase)
                              select r;

            UpdateListBox(filteredRecords);
        }
    }
}