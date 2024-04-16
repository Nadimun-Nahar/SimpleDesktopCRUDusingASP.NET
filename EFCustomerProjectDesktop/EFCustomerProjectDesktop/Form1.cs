using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFCustomerProjectDesktop
{
    public partial class Form1 : Form
    {
        Customer model = new Customer();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            model.FirstName = txtFirstName.Text.Trim();
            model.LastName = txtLastName.Text.Trim();
            model.City = txtCity.Text.Trim();
            model.Address = txtAddress.Text.Trim();

            using (EFDBEntities1 db = new EFDBEntities1())
            {
                if(model.CustomerID == 0) // insert
                    db.Customers.Add(model);
                else
                    db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
            }
            clear();
            loadDataInGridView();
            MessageBox.Show("Submited Successfully");
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure to delete this record","Message",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    var entry = db.Entry(model);
                    if(entry.State == EntityState.Detached)
                    {
                        db.Customers.Attach(model);
                        db.Customers.Remove(model);
                        db.SaveChanges();
                        loadDataInGridView();
                        clear();
                        MessageBox.Show("deleted successfully");
                    }
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
        }

        void clear()
        {
            txtFirstName.Text = txtLastName.Text = txtCity.Text = txtAddress.Text = "";
            btnSave.Text = "Save";
            btndelete.Enabled = false;
            model.CustomerID = 0;
            this.ActiveControl = txtFirstName;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clear();
            this.ActiveControl = txtFirstName;
            loadDataInGridView();
        }

        void loadDataInGridView()
        {
            dgvCustomer.AutoGenerateColumns = false;
            using(EFDBEntities1 db = new EFDBEntities1())
            {
                dgvCustomer.DataSource = db.Customers.ToList<Customer>();
            }
        }

        private void dgvCustomer_DoubleClick(object sender, EventArgs e)
        {
            if(dgvCustomer.CurrentRow.Index != -1)
            {
                model.CustomerID = Convert.ToInt32(dgvCustomer.CurrentRow.Cells["dgCustomerID"].Value);
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    model = db.Customers.Where(x => x.CustomerID == model.CustomerID).FirstOrDefault();
                    txtFirstName.Text = model.FirstName;
                    txtLastName.Text = model.LastName;
                    txtCity.Text = model.City;
                    txtAddress.Text = model.Address;
                }
                btnSave.Text = "Update";
                btndelete.Enabled = true;
            }

        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
