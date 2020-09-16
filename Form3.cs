using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using CsvFile;
using System.IO;

namespace COVID_19Calc
{
    public partial class Form3 : Form
    {
        private const int MaxColumns = 64;
        private protected string FileName;
        private protected bool Modified;
        public IFormatProvider Provider { get; }

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            InitializeGrid();
            ClearFile();
            OpenToolStripMenuItem_Click(sender, e);
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveIfModified())
                ClearFile();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveIfModified())
            {
                if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
                    ReadFile(openFileDialog1.FileName);
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FileName != null)
            {
                WriteFile(FileName);
            }
            else
            {
                SaveAsToolStripMenuItem_Click(sender, e);
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = FileName;
            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                WriteFile(saveFileDialog1.FileName);
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveIfModified())
            {
                Close();
            }
        }

        private void InitializeGrid()
        {
            for (int i = 1; i <= MaxColumns; i++)
            {
                dataGridView1.Columns.Add(
                    String.Format(Provider, "Column{0}", i),
                    String.Format(Provider, "Column {0}", i));
            }

        }

        private void ClearFile()
        {
            dataGridView1.Rows.Clear();
            FileName = null;
            Modified = false;
        }

        private bool ReadFile(string filename)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                dataGridView1.Rows.Clear();
                List<string> columns = new List<string>();
                using (var reader = new CsvFileReader(filename))
                {
                    while (reader.ReadRow(columns))
                    {
                        dataGridView1.Rows.Add(columns.ToArray());
                    }
                }
                FileName = filename;
                Modified = false;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(Provider, "Error reading from {0}.\r\n\r\n{1}", filename, ex.Message));
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            return false;
        }

        private bool WriteFile(string filename)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                // Like Excel, we'll get the highest column number used,
                // and then write out that many columns for every row
                int numColumns = GetMaxColumnUsed();
                using (var writer = new CsvFileWriter(filename))
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            List<string> columns = new List<string>();
                            for (int col = 0; col < numColumns; col++)
                                columns.Add((string)row.Cells[col].Value ?? String.Empty);
                            writer.WriteRow(columns);
                        }
                    }
                }
                FileName = filename;
                Modified = false;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(Provider, "Error writing to {0}.\r\n\r\n{1}", filename, ex.Message));
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            return false;
        }

        // Determines the maximum column number used in the grid
        private int GetMaxColumnUsed()
        {
            int maxColumnUsed = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    for (int col = row.Cells.Count - 1; col >= 0; col--)
                    {
                        if (row.Cells[col].Value != null)
                        {
                            if (maxColumnUsed < (col + 1))
                            {
                                maxColumnUsed = (col + 1);
                            }

                            continue;
                        }
                    }
                }
            }
            return maxColumnUsed;
        }

        private bool SaveIfModified()
        {
            if (!Modified)
            {
                return true;
            }

            DialogResult result = MessageBox.Show("The current file has changed. Save changes?", "Save Changes", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                if (FileName != null)
                {
                    return WriteFile(FileName);
                }
                else
                {
                    saveFileDialog1.FileName = FileName;
                    if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
                        return WriteFile(saveFileDialog1.FileName);
                    return false;
                }
            }
            else if (result == DialogResult.No)
            {
                return true;
            }
            else // DialogResult.Cancel
            {
                return false;
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Modified = true;
        }
    }
}
