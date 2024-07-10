using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace PABMS
{
    public partial class StaffForm : Form
    {
        // these are all the component of this form:
        //txtID
        //txtFullName
        //sex: cbMale and cbFemale
        //dtpBirthDate
        //txtStaffPosition
        //txtStaffSalary
        //txtStaffAddress
        //txtStaffTel
        //pbStaffPhoto
        //cbStoppedWork
        //txtSearch

        // these are the column in tbStaff
        //StaffID INT PRIMARY KEY IDENTITY(1,1),
        //StaffName NVARCHAR(50),
        //StaffSex CHAR(1),
        //StaffBirthDate DATE,
        //StaffPosition NVARCHAR(50),
        //StaffAddress NVARCHAR(100),
        //StaffTel NVARCHAR(20),
        //Salary MONEY,
        //HiredDate DATE,
        //Photo VARBINARY(MAX),
        //StoppedWork BIT

        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        DataTable staffTable = new DataTable();
        DataTable saveTable = new DataTable();
        DataRow updateRow = null;

        byte[] staffPhoto = null;

        public StaffForm()
        {
            InitializeComponent();

            fillStaffTable();
            saveTable = staffTable.Clone();
            txtID.Text = getLastestStaffID().ToString();
        }

        void fillStaffTable()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tbStaff", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(staffTable);
                gridStaff.DataSource = staffTable;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pbStaffPhoto_Click(object sender, EventArgs e)
        {
            try
            {
                staffPhoto = GetPhotoData();
                Console.WriteLine("Photo data loaded successfully.");
                pbStaffPhoto.Image = Image.FromStream(new MemoryStream(staffPhoto));
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public byte[] GetPhotoData()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Select a Photo";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    using (Image image = Image.FromFile(filePath))
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            image.Save(memoryStream, image.RawFormat);
                            return memoryStream.ToArray();
                        }
                    }
                }
                else
                {
                    throw new OperationCanceledException("Photo selection was canceled.");
                }
            }
        }

        byte[] getImageByteArray()
        {
            if (pbStaffPhoto.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                pbStaffPhoto.Image.Save(ms, pbStaffPhoto.Image.RawFormat);
                staffPhoto = ms.ToArray();
                return staffPhoto;
            }
            return null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataRow newRow = saveTable.NewRow();
            newRow["StaffName"] = txtFullName.Text;
            newRow["StaffSex"] = cbMale.Checked ? 'M' : 'F';
            newRow["StaffBirthDate"] = dtpBirthDate.Value;
            newRow["StaffPosition"] = txtStaffPosition.Text;
            newRow["StaffAddress"] = txtStaffAddress.Text;
            newRow["StaffTel"] = txtStaffTel.Text;
            newRow["Salary"] = Convert.ToDecimal(txtStaffSalary.Text);
            newRow["HiredDate"] = DateTime.Now;
            newRow["Photo"] = pbStaffPhoto.Image == null ? DBNull.Value : getImageByteArray();
            newRow["StoppedWork"] = cbStoppedWork.Checked;

            saveTable.Rows.Add(newRow);
            MessageBox.Show("Data added successfully");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SavingDialogue savingDialogue = new SavingDialogue(saveTable);
            savingDialogue.ShowDialog();

            saveTable = savingDialogue.save_table;

            staffTable.Merge(saveTable);

            if (saveTable != null)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    foreach (DataRow row in saveTable.Rows)
                    {
                        string query = "INSERT INTO tbStaff (StaffName, StaffSex, StaffBirthDate, StaffPosition, StaffAddress, StaffTel, Salary, HiredDate, Photo, StoppedWork) " +
                                       "VALUES (@StaffName, @StaffSex, @StaffBirthDate, @StaffPosition, @StaffAddress, @StaffTel, @Salary, @HiredDate, @Photo, @StoppedWork)";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@StaffName", row["StaffName"]);
                            cmd.Parameters.AddWithValue("@StaffSex", row["StaffSex"]);
                            cmd.Parameters.AddWithValue("@StaffBirthDate", row["StaffBirthDate"]);
                            cmd.Parameters.AddWithValue("@StaffPosition", row["StaffPosition"]);
                            cmd.Parameters.AddWithValue("@StaffAddress", row["StaffAddress"]);
                            cmd.Parameters.AddWithValue("@StaffTel", row["StaffTel"]);
                            cmd.Parameters.AddWithValue("@Salary", row["Salary"]);
                            cmd.Parameters.AddWithValue("@HiredDate", row["HiredDate"]);

                            SqlParameter photoParam = new SqlParameter("@Photo", SqlDbType.VarBinary);
                            photoParam.Value = row["Photo"] == DBNull.Value ? DBNull.Value : (byte[])row["Photo"];
                            cmd.Parameters.Add(photoParam);

                            cmd.Parameters.AddWithValue("@StoppedWork", row["StoppedWork"]);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    conn.Close();
                }

                staffTable.AcceptChanges();
                gridStaff.Refresh();
                saveTable.Clear();
                MessageBox.Show("Data saved successfully");
            }
            else
            {
                MessageBox.Show("No changes to save");
            }
        }

        private void gridStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = gridStaff.CurrentRow;
            try
            {
                txtID.Text = row.Cells["StaffID"].Value.ToString();
                txtFullName.Text = row.Cells["StaffName"].Value.ToString();
                cbMale.Checked = row.Cells["StaffSex"].Value.ToString() == "M";
                cbFemale.Checked = row.Cells["StaffSex"].Value.ToString() == "F";
                dtpBirthDate.Value = Convert.ToDateTime(row.Cells["StaffBirthDate"].Value);
                txtStaffPosition.Text = row.Cells["StaffPosition"].Value.ToString();
                txtStaffAddress.Text = row.Cells["StaffAddress"].Value.ToString();
                txtStaffTel.Text = row.Cells["StaffTel"].Value.ToString();
                txtStaffSalary.Text = row.Cells["Salary"].Value.ToString();
                try
                {
                    pbStaffPhoto.Image = Image.FromStream(new MemoryStream((byte[])row.Cells["Photo"].Value));
                }
                catch (Exception ex)
                {
                    pbStaffPhoto.Image = pbStaffPhoto.ErrorImage;
                }
                cbStoppedWork.Checked = Convert.ToBoolean(row.Cells["StoppedWork"].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // also update staffTable in this row that was updated
            DataRow[] rows = staffTable.Select("StaffID = " + txtID.Text);
            if (rows.Length > 0)
            {
                updateRow = rows[0];
                updateRow["StaffName"] = txtFullName.Text;
                updateRow["StaffSex"] = cbMale.Checked ? 'M' : 'F';
                updateRow["StaffBirthDate"] = dtpBirthDate.Value;
                updateRow["StaffPosition"] = txtStaffPosition.Text;
                updateRow["StaffAddress"] = txtStaffAddress.Text;
                updateRow["StaffTel"] = txtStaffTel.Text;
                updateRow["Salary"] = Convert.ToDecimal(txtStaffSalary.Text);
                updateRow["Photo"] = pbStaffPhoto.Image == null ? DBNull.Value : getImageByteArray();
                updateRow["StoppedWork"] = cbStoppedWork.Checked;
            }
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "UPDATE tbStaff SET StaffName = @StaffName, StaffSex = @StaffSex, StaffBirthDate = @StaffBirthDate, StaffPosition = @StaffPosition, StaffAddress = @StaffAddress, StaffTel = @StaffTel, Salary = @Salary, Photo = @Photo, StoppedWork = @StoppedWork WHERE StaffID = @StaffID";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@StaffID", txtID.Text);
                        cmd.Parameters.AddWithValue("@StaffName", txtFullName.Text);
                        cmd.Parameters.AddWithValue("@StaffSex", cbMale.Checked ? 'M' : 'F');
                        cmd.Parameters.AddWithValue("@StaffBirthDate", dtpBirthDate.Value);
                        cmd.Parameters.AddWithValue("@StaffPosition", txtStaffPosition.Text);
                        cmd.Parameters.AddWithValue("@StaffAddress", txtStaffAddress.Text);
                        cmd.Parameters.AddWithValue("@StaffTel", txtStaffTel.Text);
                        cmd.Parameters.AddWithValue("@Salary", Convert.ToDecimal(txtStaffSalary.Text));
                        cmd.Parameters.AddWithValue("@Photo", pbStaffPhoto.Image == null ? DBNull.Value : getImageByteArray());
                        cmd.Parameters.AddWithValue("@StoppedWork", cbStoppedWork.Checked);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data updated successfully");
                    }
                    con.Close();
                    staffTable.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        int getLastestStaffID()
        {
            return int.Parse(staffTable.Rows[staffTable.Rows.Count - 1]["StaffID"].ToString()) + 1;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            // clear all controls
            txtID.Text = getLastestStaffID().ToString();
            txtFullName.Text = "";
            cbMale.Checked = false;
            cbFemale.Checked = false;
            dtpBirthDate.Value = DateTime.Now;
            txtStaffPosition.Text = "";
            txtStaffAddress.Text = "";
            txtStaffTel.Text = "";
            txtStaffSalary.Text = "";
            pbStaffPhoto.Image = null;
            cbStoppedWork.Checked = false;
            cbMale.Checked = false;
            cbFemale.Checked = false;
            dtpBirthDate.Value = DateTime.Now;
        }

        private void StaffForm_Load(object sender, EventArgs e)
        {

        }
    }
}
