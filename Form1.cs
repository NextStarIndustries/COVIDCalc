using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using CsvFile;

namespace COVID_19Calc
{
    public partial class Form1 : Form
    {
        private const int MaxColumns = 64;
        private protected string FileName;
        private protected bool Modified;
        public IFormatProvider Provider { get; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
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

        //CSV cell data

        int erowv;
        private string erown;
        string newd3acv;
        string d1d3acv;
        string d2d3acv;
        string newd5acv;
        string d1d5acv;
        string d2d5acv;
        string d3d5acv;
        string d4d5acv;
        string newd7acv;
        string d1d7acv;
        string d2d7acv;
        string d3d7acv;
        string d4d7acv;
        string d5d7acv;
        string d6d7acv;
        double newd3aci;
        double d1d3aci;
        double d2d3aci;
        double newd5aci;
        double d1d5aci;
        double d2d5aci;
        double d3d5aci;
        double d4d5aci;
        double newd7aci;
        double d1d7aci;
        double d2d7aci;
        double d3d7aci;
        double d4d7aci;
        double d5d7aci;
        double d6d7aci;
        string newd3adv;
        string d1d3adv;
        string d2d3adv;
        string newd5adv;
        string d1d5adv;
        string d2d5adv;
        string d3d5adv;
        string d4d5adv;
        string newd7adv;
        string d1d7adv;
        string d2d7adv;
        string d3d7adv;
        string d4d7adv;
        string d5d7adv;
        string d6d7adv;
        double newd3adi;
        double d1d3adi;
        double d2d3adi;
        double newd5adi;
        double d1d5adi;
        double d2d5adi;
        double d3d5adi;
        double d4d5adi;
        double newd7adi;
        double d1d7adi;
        double d2d7adi;
        double d3d7adi;
        double d4d7adi;
        double d5d7adi;
        double d6d7adi;
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Modified = true;
            erowv = e.RowIndex - 2;
            //erowi = Convert.ToDouble(erowv, Provider);
            //erow = erowv - 2;
            erown = Convert.ToString(erowv, Provider);
            label71.Text = erown;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                oncv = row.Cells[1].Value.ToString();
                ondv = row.Cells[2].Value.ToString();
                d1av = row.Cells[3].Value.ToString();
                d1dav = row.Cells[4].Value.ToString();
                icv = row.Cells[5].Value.ToString();
                acv = row.Cells[6].Value.ToString();
                DataGridViewRow row1 = dataGridView1.Rows[e.RowIndex - 1];
                d2av = row1.Cells[3].Value.ToString();
                d2dav = row1.Cells[4].Value.ToString();
                DataGridViewRow row2 = dataGridView1.Rows[e.RowIndex - 2];
                d3av = row2.Cells[3].Value.ToString();
                d3dav = row2.Cells[4].Value.ToString();
                if (String.IsNullOrEmpty(row1.Cells[12].Value as String) && String.IsNullOrEmpty(row2.Cells[12].Value as String))
                {
                    newd3acv = row.Cells[12].Value.ToString();
                    newd3aci = Convert.ToDouble(newd3acv, Provider);
                    label79.Text = oncn;
                    label74.Text = newd3acv;
                }
                else
                {
                    if (String.IsNullOrEmpty(row1.Cells[12].Value as String) && !String.IsNullOrEmpty(row2.Cells[12].Value as String))
                    {
                        d2d3acv = row2.Cells[12].Value.ToString();
                        d2d3aci = Convert.ToDouble(d2d3acv, Provider);
                        label79.Text = d2an;
                        label74.Text = d2d3acv;
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(row1.Cells[12].Value as String))
                        {
                            d1d3acv = row1.Cells[12].Value.ToString();
                            d1d3aci = Convert.ToDouble(d1d3acv, Provider);
                            label79.Text = d1an;
                            label74.Text = d1d3acv;
                        }
                    }
                }
                if (String.IsNullOrEmpty(row1.Cells[15].Value as String) && String.IsNullOrEmpty(row2.Cells[15].Value as String))
                {
                    newd3adv = row.Cells[15].Value.ToString();
                    newd3adi = Convert.ToDouble(newd3adv, Provider);
                    label90.Text = ondn;
                    label95.Text = newd3adv;
                }
                else
                {
                    if (String.IsNullOrEmpty(row1.Cells[15].Value as String) && !String.IsNullOrEmpty(row2.Cells[15].Value as String))
                    {
                        d2d3adv = row2.Cells[15].Value.ToString();
                        d2d3adi = Convert.ToDouble(d2d3adv, Provider);
                        label90.Text = d2dan;
                        label95.Text = d2d3adv;
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(row1.Cells[15].Value as String))
                        {
                            d1d3adv = row1.Cells[15].Value.ToString();
                            d1d3adi = Convert.ToDouble(d1d3adv, Provider);
                            label90.Text = d1dan;
                            label95.Text = d1d3adv;
                        }
                    }
                }
                DataGridViewRow row3 = dataGridView1.Rows[e.RowIndex - 3];
                d4av = row3.Cells[3].Value.ToString();
                d4dav = row3.Cells[4].Value.ToString();
                DataGridViewRow row4 = dataGridView1.Rows[e.RowIndex - 4];
                d5av = row4.Cells[3].Value.ToString();
                d5dav = row4.Cells[4].Value.ToString();
                if (String.IsNullOrEmpty(row1.Cells[13].Value as String) && String.IsNullOrEmpty(row2.Cells[13].Value as String) && String.IsNullOrEmpty(row3.Cells[13].Value as String) && String.IsNullOrEmpty(row4.Cells[13].Value as String))
                {
                    label80.Text = oncn;
                    newd5acv = row.Cells[13].Value.ToString();
                    newd5aci = Convert.ToDouble(newd5acv, Provider);
                    label76.Text = newd5acv;
                }
                else
                {
                    if (String.IsNullOrEmpty(row1.Cells[13].Value as String) && String.IsNullOrEmpty(row2.Cells[13].Value as String) && String.IsNullOrEmpty(row3.Cells[13].Value as String) && !String.IsNullOrEmpty(row4.Cells[13].Value as String))
                    {
                        label80.Text = d4an;
                        d4d5acv = row4.Cells[13].Value.ToString();
                        d4d5aci = Convert.ToDouble(d4d5acv, Provider);
                        label76.Text = d4d5acv;
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(row1.Cells[13].Value as String) && String.IsNullOrEmpty(row2.Cells[13].Value as String) && !String.IsNullOrEmpty(row3.Cells[13].Value as String))
                        {
                            label80.Text = d3an;
                            d3d5acv = row3.Cells[13].Value.ToString();
                            d3d5aci = Convert.ToDouble(d3d5acv, Provider);
                            label76.Text = d3d5acv;
                        }
                        else
                        {
                            if (String.IsNullOrEmpty(row1.Cells[13].Value as String) && !String.IsNullOrEmpty(row2.Cells[13].Value as String))
                            {
                                label80.Text = d2an;
                                d2d5acv = row2.Cells[13].Value.ToString();
                                d2d5aci = Convert.ToDouble(d2d5acv, Provider);
                                label76.Text = d2d5acv;
                            }
                            else
                            {
                                if (!String.IsNullOrEmpty(row1.Cells[13].Value as String))
                                {
                                    label80.Text = d1an;
                                    d1d5acv = row1.Cells[13].Value.ToString();
                                    d1d5aci = Convert.ToDouble(d1d5acv, Provider);
                                    label76.Text = d1d5acv;
                                }
                            }
                        }
                    }
                }
                if (String.IsNullOrEmpty(row1.Cells[16].Value as String) && String.IsNullOrEmpty(row2.Cells[16].Value as String) && String.IsNullOrEmpty(row3.Cells[16].Value as String) && String.IsNullOrEmpty(row4.Cells[16].Value as String))
                {
                    label89.Text = ondn;
                    newd5adv = row.Cells[16].Value.ToString();
                    newd5adi = Convert.ToDouble(newd5adv, Provider);
                    label93.Text = newd5adv;
                }
                else
                {
                    if (String.IsNullOrEmpty(row1.Cells[16].Value as String) && String.IsNullOrEmpty(row2.Cells[16].Value as String) && String.IsNullOrEmpty(row3.Cells[16].Value as String) && !String.IsNullOrEmpty(row4.Cells[16].Value as String))
                    {
                        label89.Text = d4dan;
                        d4d5adv = row4.Cells[16].Value.ToString();
                        d4d5adi = Convert.ToDouble(d4d5adv, Provider);
                        label93.Text = d4d5adv;
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(row1.Cells[16].Value as String) && String.IsNullOrEmpty(row2.Cells[16].Value as String) && !String.IsNullOrEmpty(row3.Cells[16].Value as String))
                        {
                            label89.Text = d3dan;
                            d3d5adv = row3.Cells[16].Value.ToString();
                            d3d5adi = Convert.ToDouble(d3d5adv, Provider);
                            label93.Text = d3d5adv;
                        }
                        else
                        {
                            if (String.IsNullOrEmpty(row1.Cells[16].Value as String) && !String.IsNullOrEmpty(row2.Cells[16].Value as String))
                            {
                                label89.Text = d2dan;
                                d2d5adv = row2.Cells[16].Value.ToString();
                                d2d5adi = Convert.ToDouble(d2d5adv, Provider);
                                label93.Text = d2d5adv;
                            }
                            else
                            {
                                if (!String.IsNullOrEmpty(row1.Cells[16].Value as String))
                                {
                                    label89.Text = d1dan;
                                    d1d5adv = row1.Cells[16].Value.ToString();
                                    d1d5adi = Convert.ToDouble(d1d5adv, Provider);
                                    label93.Text = d1d5adv;
                                }
                            }
                        }
                    }
                }
                DataGridViewRow row5 = dataGridView1.Rows[e.RowIndex - 5];
                d6av = row5.Cells[3].Value.ToString();
                d6dav = row5.Cells[4].Value.ToString();
                DataGridViewRow row6 = dataGridView1.Rows[e.RowIndex - 6];
                if (String.IsNullOrEmpty(row1.Cells[14].Value as String) && String.IsNullOrEmpty(row2.Cells[14].Value as String) && String.IsNullOrEmpty(row3.Cells[14].Value as String) && String.IsNullOrEmpty(row4.Cells[14].Value as String) && String.IsNullOrEmpty(row5.Cells[14].Value as String) && String.IsNullOrEmpty(row6.Cells[14].Value as String))
                {
                    label81.Text = oncn;
                    newd7acv = row.Cells[14].Value.ToString();
                    newd7aci = Convert.ToDouble(newd7acv, Provider);
                    label78.Text = newd7acv;
                }
                else
                {
                    if (String.IsNullOrEmpty(row1.Cells[14].Value as String) && String.IsNullOrEmpty(row2.Cells[14].Value as String) && String.IsNullOrEmpty(row3.Cells[14].Value as String) && String.IsNullOrEmpty(row4.Cells[14].Value as String) && String.IsNullOrEmpty(row5.Cells[14].Value as String) && !String.IsNullOrEmpty(row6.Cells[14].Value as String))
                    {
                        label81.Text = d6an;
                        d6d7acv = row6.Cells[14].Value.ToString();
                        d6d7aci = Convert.ToDouble(d6d7acv, Provider);
                        label78.Text = d6d7acv;
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(row1.Cells[14].Value as String) && String.IsNullOrEmpty(row2.Cells[14].Value as String) && String.IsNullOrEmpty(row3.Cells[14].Value as String) && String.IsNullOrEmpty(row4.Cells[14].Value as String) && !String.IsNullOrEmpty(row5.Cells[14].Value as String))
                        {
                            label81.Text = d5an;
                            d5d7acv = row5.Cells[14].Value.ToString();
                            d5d7aci = Convert.ToDouble(d5d7acv, Provider);
                            label78.Text = d5d7acv;
                        }
                        else
                        {
                            if (String.IsNullOrEmpty(row1.Cells[14].Value as String) && String.IsNullOrEmpty(row2.Cells[14].Value as String) && String.IsNullOrEmpty(row3.Cells[14].Value as String) && !String.IsNullOrEmpty(row4.Cells[14].Value as String))
                            {
                                label81.Text = d4an;
                                d4d7acv = row4.Cells[14].Value.ToString();
                                d4d7aci = Convert.ToDouble(d4d7acv, Provider);
                                label78.Text = d4d7acv;
                            }
                            else
                            {
                                if (String.IsNullOrEmpty(row1.Cells[14].Value as String) && String.IsNullOrEmpty(row2.Cells[14].Value as String) && !String.IsNullOrEmpty(row3.Cells[14].Value as String))
                                {
                                    label81.Text = d3an;
                                    d3d7acv = row3.Cells[14].Value.ToString();
                                    d3d7aci = Convert.ToDouble(d3d7acv, Provider);
                                    label78.Text = d3d7acv;
                                }
                                else
                                {
                                    if (String.IsNullOrEmpty(row1.Cells[14].Value as String) && !String.IsNullOrEmpty(row2.Cells[14].Value as String))
                                    {
                                        label81.Text = d2an;
                                        d2d7acv = row2.Cells[14].Value.ToString();
                                        d2d7aci = Convert.ToDouble(d2d7acv, Provider);
                                        label78.Text = d2d7acv;
                                    }
                                    else
                                    {
                                        if (!String.IsNullOrEmpty(row1.Cells[14].Value as String))
                                        {
                                            label81.Text = d1an;
                                            d1d7acv = row1.Cells[14].Value.ToString();
                                            d1d7aci = Convert.ToDouble(d1d7acv, Provider);
                                            label78.Text = d1d7acv;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (String.IsNullOrEmpty(row1.Cells[17].Value as String) && String.IsNullOrEmpty(row2.Cells[17].Value as String) && String.IsNullOrEmpty(row3.Cells[17].Value as String) && String.IsNullOrEmpty(row4.Cells[17].Value as String) && String.IsNullOrEmpty(row5.Cells[17].Value as String) && String.IsNullOrEmpty(row6.Cells[17].Value as String))
                {
                    label88.Text = ondn;
                    newd7adv = row.Cells[17].Value.ToString();
                    newd7adi = Convert.ToDouble(newd7adv, Provider);
                    label91.Text = newd7adv;
                }
                else
                {
                    if (String.IsNullOrEmpty(row1.Cells[17].Value as String) && String.IsNullOrEmpty(row2.Cells[17].Value as String) && String.IsNullOrEmpty(row3.Cells[17].Value as String) && String.IsNullOrEmpty(row4.Cells[17].Value as String) && String.IsNullOrEmpty(row5.Cells[17].Value as String) && !String.IsNullOrEmpty(row6.Cells[17].Value as String))
                    {
                        label88.Text = d6dan;
                        d6d7adv = row6.Cells[17].Value.ToString();
                        d6d7adi = Convert.ToDouble(d6d7adv, Provider);
                        label91.Text = d6d7adv;
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(row1.Cells[17].Value as String) && String.IsNullOrEmpty(row2.Cells[17].Value as String) && String.IsNullOrEmpty(row3.Cells[17].Value as String) && String.IsNullOrEmpty(row4.Cells[17].Value as String) && !String.IsNullOrEmpty(row5.Cells[17].Value as String))
                        {
                            label88.Text = d5dan;
                            d5d7adv = row5.Cells[17].Value.ToString();
                            d5d7adi = Convert.ToDouble(d5d7adv, Provider);
                            label91.Text = d5d7adv;
                        }
                        else
                        {
                            if (String.IsNullOrEmpty(row1.Cells[17].Value as String) && String.IsNullOrEmpty(row2.Cells[17].Value as String) && String.IsNullOrEmpty(row3.Cells[17].Value as String) && !String.IsNullOrEmpty(row4.Cells[17].Value as String))
                            {
                                label88.Text = d4dan;
                                d4d7adv = row4.Cells[17].Value.ToString();
                                d4d7adi = Convert.ToDouble(d4d7adv, Provider);
                                label91.Text = d4d7adv;
                            }
                            else
                            {
                                if (String.IsNullOrEmpty(row1.Cells[17].Value as String) && String.IsNullOrEmpty(row2.Cells[17].Value as String) && !String.IsNullOrEmpty(row3.Cells[17].Value as String))
                                {
                                    label88.Text = d3dan;
                                    d3d7adv = row3.Cells[17].Value.ToString();
                                    d3d7adi = Convert.ToDouble(d3d7adv, Provider);
                                    label91.Text = d3d7adv;
                                }
                                else
                                {
                                    if (String.IsNullOrEmpty(row1.Cells[17].Value as String) && !String.IsNullOrEmpty(row2.Cells[17].Value as String))
                                    {
                                        label88.Text = d2dan;
                                        d2d7adv = row2.Cells[17].Value.ToString();
                                        d2d7adi = Convert.ToDouble(d2d7adv, Provider);
                                        label91.Text = d2d7adv;
                                    }
                                    else
                                    {
                                        if (!String.IsNullOrEmpty(row1.Cells[17].Value as String))
                                        {
                                            label88.Text = d1dan;
                                            d1d7adv = row1.Cells[17].Value.ToString();
                                            d1d7adi = Convert.ToDouble(d1d7adv, Provider);
                                            label91.Text = d1d7adv;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            PopConvert();
            TCperPopConvert();
            TDperPopConvert();
        }

        //Population to per Population Convert

        private string upv;
        private double upi;
        private double okc;
        private double omc;
        private string okcn;
        private string omcn;

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            PopConvert();
            TCperPopConvert();
            TDperPopConvert();
        }

        private void PopConvert()
        {
            upv = textBox1.Text;
            upi = Convert.ToDouble(upv, Provider);
            okc = upi / 100000f;
            omc = upi / 1000000f;
            okcn = Convert.ToString(okc, Provider);
            omcn = Convert.ToString(omc, Provider);
            label7.Text = okcn;
            label9.Text = omcn;
        }

        //Total Cases per Population Convert

        string utciv;
        double utci;
        double otck;
        double otcm;
        string otckn;
        string otcmn;

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
                TCperPopConvert();
                TDperPopConvert();
                PopConvert();
        }

        private void TCperPopConvert()
        {
            utciv = textBox2.Text;
            utci = Convert.ToDouble(utciv, Provider);
            otck = utci / okc;
            otcm = utci / omc;
            otckn = Convert.ToString(otck, Provider);
            otcmn = Convert.ToString(otcm, Provider);
            label11.Text = otckn;
            label13.Text = otcmn;
        }

        //Total Deaths per Population Convert Plus Other Converts

        string utdiv;
        string oncv;
        string ondv;
        string d1av;
        string d2av;
        string d3av;
        string d4av;
        string d5av;
        string d6av;
        string d1dav;
        string d2dav;
        string d3dav;
        string d4dav;
        string d5dav;
        string d6dav;
        string icv;
        string acv;
        string uicv;
        string uacv;
        double onci;
        double ondi;
        double utdi;
        double otdk;
        double otdm;
        double mort;
        double ptpi;
        double ptpd;
        double onc;
        double ond;
        double ocpc;
        double odpc;
        double d1ai;
        double d1a;
        double d2ai;
        double d2a;
        double d3ai;
        double d3a;
        double d4ai;
        double d4a;
        double d5ai;
        double d5a;
        double d6ai;
        double d6a;
        double d1dai;
        double d1da;
        double d2dai;
        double d2da;
        double d3dai;
        double d3da;
        double d4dai;
        double d4da;
        double d5dai;
        double d5da;
        double d6dai;
        double d6da;
        double ici;
        double dic;
        double aci;
        double dac;
        double uici;
        double uaci;
        double dicc;
        double dacc;
        string otdkn;
        string otdmn;
        string mortn;
        string ptpin;
        string ptpdn;
        string oncn;
        string ondn;
        string ocpcn;
        string odpcn;
        string d1an;
        string d2an;
        string d3an;
        string d4an;
        string d5an;
        string d6an;
        string d1dan;
        string d2dan;
        string d3dan;
        string d4dan;
        string d5dan;
        string d6dan;
        string dicn;
        string dacn;
        string diccn;
        string daccn;
        readonly string incr = "Increasing";
        readonly string decr = "Decreasing";
        readonly string flat = " Flat";
        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
                TDperPopConvert();
                TCperPopConvert();
                PopConvert();
        }

        private void TDperPopConvert()
        {
            utdiv = textBox3.Text;
            utdi = Convert.ToDouble(utdiv, Provider);
            otdk = utdi / okc;
            otdm = utdi / omc;
            otdkn = Convert.ToString(otdk, Provider);
            otdmn = Convert.ToString(otdm, Provider);
            label15.Text = otdkn;
            label17.Text = otdmn;

            //Other Converts

            //Mortality Convert
            mort = utdi / utci * 100f;
            mortn = Convert.ToString(mort, Provider);
            label19.Text = mortn;

            //Percent of Total Population Converts
            ptpi = utci / upi * 100f;
            ptpin = Convert.ToString(ptpi, Provider);
            label21.Text = ptpin;
            ptpd = utdi / upi * 100f;
            ptpdn = Convert.ToString(ptpd, Provider);
            label23.Text = ptpdn;

            //New Cases and Deaths

            onci = Convert.ToDouble(oncv, Provider);
            ondi = Convert.ToDouble(ondv, Provider);
            onc = utci - onci;
            ond = utdi - ondi;
            oncn = Convert.ToString(onc, Provider);
            ondn = Convert.ToString(ond, Provider);
            label25.Text = oncn;
            label27.Text = ondn;
            ocpc = (onc / utci) * 100f;
            odpc = (ond / utdi) * 100f;
            ocpcn = Convert.ToString(ocpc, Provider);
            odpcn = Convert.ToString(odpc, Provider);
            label29.Text = ocpcn;
            label31.Text = odpcn;

            //Inactive Active Cases
            ici = Convert.ToDouble(icv, Provider);
            aci = Convert.ToDouble(acv, Provider);
            uicv = textBox4.Text;
            uacv = textBox5.Text;
            uici = Convert.ToDouble(uicv, Provider);
            uaci = Convert.ToDouble(uacv, Provider);
            dic = uici - ici;
            dac = uaci - aci;
            dicn = Convert.ToString(dic, Provider);
            dacn = Convert.ToString(dac, Provider);
            label33.Text = dicn;
            label35.Text = dacn;
            if (dic > 0.00f)
            {
                dicc = (dic / ici) * 100f;
            }
            else
            {
                dicc = (((dic * -1.0f) / ici) * 100f) / -1f;
            }
            if (dac > 0.00f)
            {
                dacc = (dac / aci) * 100f;
            }
            else
            {
                dacc = (((dac * -1.0f) / aci) * 100f) / -1f;
            }
            diccn = Convert.ToString(dicc, Provider);
            daccn = Convert.ToString(dacc, Provider);
            label37.Text = diccn;
            label39.Text = daccn;

            //Averages
            label54.Text = oncn;
            d1ai = Convert.ToDouble(d1av, Provider);
            d1a = (onc + d1ai) / 2f;
            d1an = Convert.ToString(d1a, Provider);
            label52.Text = d1an;
            d2ai = Convert.ToDouble(d2av, Provider);
            d2a = (onc + d1ai + d2ai) / 3f;
            d2an = Convert.ToString(d2a, Provider);
            label50.Text = d2an;
            d3ai = Convert.ToDouble(d3av, Provider);
            d3a = (onc + d1ai + d2ai + d3ai) / 4f;
            d3an = Convert.ToString(d3a, Provider);
            label48.Text = d3an;
            d4ai = Convert.ToDouble(d4av, Provider);
            d4a = (onc + d1ai + d2ai + d3ai + d4ai) / 5f;
            d4an = Convert.ToString(d4a, Provider);
            label46.Text = d4an;
            d5ai = Convert.ToDouble(d5av, Provider);
            d5a = (onc + d1ai + d2ai + d3ai + d4ai + d5ai) / 6f;
            d5an = Convert.ToString(d5a, Provider);
            label44.Text = d5an;
            d6ai = Convert.ToDouble(d6av, Provider);
            d6a = (onc + d1ai + d2ai + d3ai + d4ai + d5ai + d6ai) / 7f;
            d6an = Convert.ToString(d6a, Provider);
            label42.Text = d6an;
            label69.Text = ondn;
            d1dai = Convert.ToDouble(d1dav, Provider);
            d1da = (ond + d1dai) / 2f;
            d1dan = Convert.ToString(d1da, Provider);
            label68.Text = d1dan;
            d2dai = Convert.ToDouble(d2dav, Provider);
            d2da = (ond + d1dai + d2dai) / 3f;
            d2dan = Convert.ToString(d2da, Provider);
            label67.Text = d2dan;
            d3dai = Convert.ToDouble(d3dav, Provider);
            d3da = (ond + d1dai + d2dai + d3dai) / 4f;
            d3dan = Convert.ToString(d3da, Provider);
            label66.Text = d3dan;
            d4dai = Convert.ToDouble(d4dav, Provider);
            d4da = (ond + d1dai + d2dai + d3dai + d4dai) / 5f;
            d4dan = Convert.ToString(d4da, Provider);
            label65.Text = d4dan;
            d5dai = Convert.ToDouble(d5dav, Provider);
            d5da = (ond + d1dai + d2dai + d3dai + d4dai + d5dai) / 6f;
            d5dan = Convert.ToString(d5da, Provider);
            label64.Text = d5dan;
            d6dai = Convert.ToDouble(d6dav, Provider);
            d6da = (ond + d1dai + d2dai + d3dai + d4dai + d5dai + d6dai) / 7f;
            d6dan = Convert.ToString(d6da, Provider);
            label63.Text = d6dan;
            if (onc < newd3aci || d2a < d2d3aci || d1a < d1d3aci || onc < newd5aci || d4a < d4d5aci || d3a < d3d5aci || d2a < d2d5aci || d1a < d1d5aci)
            {
                label82.Text = decr;
            }
            else
            {
                if (onc > newd3aci || d2a > d2d3aci || d1a < d1d3aci || onc > newd5aci || d4a > d4d5aci || d3a > d3d5aci || d2a > d2d5aci || d1a > d1d5aci)
                {
                    label82.Text = incr;
                }
                else
                {
                    if (onc == newd3aci || d2a == d2d3aci || d1a == d1d3aci || onc == newd5aci || d4a == d4d5aci || d3a == d3d5aci || d2a == d2d5aci || d1a == d1d5aci)
                    {
                        label82.Text = flat;
                    }
                }
            }
            if (onc < newd5aci || d4a < d4d5aci || d3a < d3d5aci || d2a < d2d5aci || d1a < d1d5aci)
            {
                label83.Text = decr;
            }
            else
            {
                if (onc > newd5aci || d4a > d4d5aci || d3a > d3d5aci || d2a > d2d5aci || d1a > d1d5aci)
                {
                    label83.Text = incr;
                }
                else
                {
                    if (onc == newd5aci || d4a == d4d5aci || d3a == d3d5aci || d2a == d2d5aci || d1a == d1d5aci)
                    {
                        label83.Text = flat;
                    }
                }
            }
            if (onc < newd7aci || d6a < d6d7aci || d5a < d5d7aci || d4a < d4d7aci || d3a < d3d7aci || d2a < d2d7aci || d1a < d1d7aci)
            {
                label84.Text = decr;
            }
            else
            {
                if (onc > newd7aci || d6a > d6d7aci || d4a > d4d7aci || d4a > d4d7aci || d3a > d3d7aci || d2a > d2d7aci || d1a > d1d7aci)
                {
                    label84.Text = incr;
                }
                else
                {
                    if (onc == newd7aci || d6a == d6d7aci || d5a == d5d7aci || d4a == d4d7aci || d3a == d3d7aci || d2a == d2d7aci || d1a == d1d7aci)
                    {
                        label84.Text = flat;
                    }
                }
            }
            if (ond < newd3adi || d2da < d2d3adi || d1da < d1d3adi || ond < newd5adi || d4da < d4d5adi || d3da < d3d5adi || d2da < d2d5adi || d1da < d1d5adi)
            {
                label87.Text = decr;
            }
            else
            {
                if (ond > newd3adi || d2da > d2d3adi || d1da < d1d3adi || ond > newd5adi || d4da > d4d5adi || d3da > d3d5adi || d2da > d2d5adi || d1da > d1d5adi)
                {
                    label87.Text = incr;
                }
                else
                {
                    if (ond == newd3adi || d2da == d2d3adi || d1da == d1d3adi || ond == newd5adi || d4da == d4d5adi || d3da == d3d5adi || d2da == d2d5adi || d1da == d1d5adi)
                    {
                        label87.Text = flat;
                    }
                }
            }
            if (ond < newd5adi || d4da < d4d5adi || d3da < d3d5adi || d2da < d2d5adi || d1da < d1d5adi)
            {
                label86.Text = decr;
            }
            else
            {
                if (ond > newd5adi || d4da > d4d5adi || d3da > d3d5adi || d2da > d2d5adi || d1da > d1d5adi)
                {
                    label86.Text = incr;
                }
                else
                {
                    if (ond == newd5adi || d4da == d4d5adi || d3da == d3d5adi || d2da == d2d5adi || d1da == d1d5adi)
                    {
                        label86.Text = flat;
                    }
                }
            }
            if (ond < newd7adi || d6da < d6d7adi || d5da < d5d7adi || d4da < d4d7adi || d3da < d3d7adi || d2da < d2d7adi || d1da < d1d7adi)
            {
                label85.Text = decr;
            }
            else
            {
                if (ond > newd7adi || d6da > d6d7adi || d4da > d4d7adi || d4da > d4d7adi || d3da > d3d7adi || d2da > d2d7adi || d1da > d1d7adi)
                {
                    label85.Text = incr;
                }
                else
                {
                    if (ond == newd7adi || d6da == d6d7adi || d5da == d5d7adi || d4da == d4d7adi || d3da == d3d7adi || d2da == d2d7adi || d1da == d1d7adi)
                    {
                        label85.Text = flat;
                    }
                }
            }
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
                TDperPopConvert();
                TCperPopConvert();
                PopConvert();
        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {
                TDperPopConvert();
                TCperPopConvert();
                PopConvert();
        }

        private void WriteNextLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rowId = dataGridView1.Rows.Add();
            DataGridViewRow rownew = dataGridView1.Rows[rowId];

            rownew.Cells["Column2"].Value = utciv;
            rownew.Cells["Column3"].Value = utdiv;
            rownew.Cells["Column4"].Value = oncn;
            rownew.Cells["Column5"].Value = ondn;
            rownew.Cells["Column6"].Value = uicv;
            rownew.Cells["Column7"].Value = uacv;
            rownew.Cells["Column8"].Value = otckn;
            rownew.Cells["Column9"].Value = otcmn;
            rownew.Cells["Column10"].Value = mortn;
            rownew.Cells["Column11"].Value = ptpin;
            rownew.Cells["Column12"].Value = ptpdn;
            rownew.Cells["Column13"].Value = label79.Text;
            rownew.Cells["Column14"].Value = label80.Text;
            rownew.Cells["Column15"].Value = label81.Text;
            rownew.Cells["Column19"].Value = ocpcn;
            rownew.Cells["Column20"].Value = odpcn;
        }

        private void FillGridTC()
        {
            chart1.Update();
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Series[3].Points.Clear();
            chart1.Series[4].Points.Clear();
            for (int i = 1; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 1; j < dataGridView1.Columns.Count; j++)
                {
                    _ = chart1.Series[0].Points.AddXY(dataGridView1[0, i].Value, dataGridView1[1, i].Value);
                }
            }
            chart1.SaveImage("chart.png", ChartImageFormat.Png);
        }
        private void FillGridTD()
        {
            chart1.Update();
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Series[3].Points.Clear();
            chart1.Series[4].Points.Clear();
            for (int i = 1; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 1; j < dataGridView1.Columns.Count; j++)
                {
                    _ = chart1.Series[1].Points.AddXY(dataGridView1[0, i].Value, dataGridView1[2, i].Value);
                }
            }
        }
        private void FillGridDC()
        {
            chart1.Update();
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Series[3].Points.Clear();
            chart1.Series[4].Points.Clear();
            for (int i = 1; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 1; j < dataGridView1.Columns.Count; j++)
                {
                    _ = chart1.Series[2].Points.AddXY(dataGridView1[0, i].Value, dataGridView1[3, i].Value);
                }
            }
        }
        private void FillGridDD()
        {
            chart1.Update();
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Series[3].Points.Clear();
            chart1.Series[4].Points.Clear();
            for (int i = 1; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 1; j < dataGridView1.Columns.Count; j++)
                {
                    _ = chart1.Series[3].Points.AddXY(dataGridView1[0, i].Value, dataGridView1[4, i].Value);
                }
            }
        }
        private void FillGridMort()
        {
            chart1.Update();
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Series[3].Points.Clear();
            chart1.Series[4].Points.Clear();
            for (int i = 1; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 1; j < dataGridView1.Columns.Count; j++)
                {
                    _ = chart1.Series[4].Points.AddXY(dataGridView1[0, i].Value, dataGridView1[9, i].Value);
                }
            }
        }

        private void TotalCasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
                FillGridTC();
        }

        private void TotalDeathsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FillGridTD();
        }

        private void DailyCasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FillGridDC();
        }

        private void DailyDeathsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FillGridDD();
        }

        private void MortalityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FillGridMort();
        }
    }
}
