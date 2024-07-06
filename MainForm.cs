using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace PABMS
{
    public partial class MainForm : Form
    {
        //private string connectionString = "Server=ASUS-EXPERTBOOK\\SQLEXPRESS;Database=ISADE5G5;Integrated Security=True;";
        private string connectionString = "Data Source=LAPTOP-2O9AK3I7\\SQLISADE5;Initial Catalog=NewISAD;Integrated Security=True";

        SqlConnection connection;

        DashboardForm dashboardForm;
        TicketForm ticketForm;
        PackageForm packageForm;
        StaffForm staffForm;
        CustomerForm customerForm;
        UserForm userForm;
        BusForm busForm;
        TruckForm truckForm;
        PaymentTicketForm paymentTicketForm;
        PaymentPackageForm paymentPackageForm;

        List<Form> visibleForms = new List<Form>();
        List<Form> mainPanelForms = new List<Form>();

        FormLogin formLogin;
        public static FormLogin.User staticUser = null;

        public MainForm()
        {
            InitializeComponent();

            connection = new SqlConnection(connectionString);
            formLogin = new FormLogin();
            formLogin.ShowDialog();

            staticUser = formLogin.user;
        }
        public void loadForm(object Form)
        {
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            f.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.PanelForm.Controls.Add(f);
            this.PanelForm.Tag = f;
            f.Hide();

        }

        public void hideAllForms(params Form[] forms)
        {
            foreach (Form f in visibleForms)
            {
                if (!forms.Contains(f))
                {
                    f.Hide();
                }
            }
        }
        private void btnTicket_Click(object sender, EventArgs e)
        {
            
            if (ticketForm.Visible == false)
            {
                visibleForms.Add(ticketForm);
                ticketForm.Show();
            }
            else
            {
                hideAllForms(ticketForm, staffForm);
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            
            if (dashboardForm.Visible == false)
            {
                visibleForms.Add(dashboardForm);
                dashboardForm.Show();
            }
            else
            {
                hideAllForms(dashboardForm, staffForm);
            }
        }

        private void btnPackage_Click(object sender, EventArgs e)
        {
            
            if (packageForm.Visible == false)
            {
                visibleForms.Add(packageForm);
                packageForm.Show();
            }
            else
            {
                hideAllForms(packageForm);
            }
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            
            if (staffForm.Visible == false)
            {
                visibleForms.Add(staffForm);
                staffForm.Show();
            }
            else
            {
                hideAllForms(staffForm);
            }
        }

        private void btnBus_Click(object sender, EventArgs e)
        {
            
            if (busForm.Visible == false)
            {
                visibleForms.Add(busForm);
                busForm.Show();
            }
            else
            {
                hideAllForms(busForm);
            }
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            
            if (userForm.Visible == false)
            {
                visibleForms.Add(userForm);
                userForm.Show();
            }
            else
            {
                hideAllForms(userForm);
            }
        }

        private void btnTruck_Click(object sender, EventArgs e)
        {
            
            if (truckForm.Visible == false)
            {
                visibleForms.Add(truckForm);
                truckForm.Show();
            }
            else
            {
                hideAllForms(truckForm);
            }
        }
        private void btnPayPackage_Click(object sender, EventArgs e)
        {
            
            if (paymentPackageForm.Visible == false)
            {
                visibleForms.Add(paymentPackageForm);
                paymentPackageForm.Show();
            }
            else
            {
                hideAllForms(paymentPackageForm);
            }
        }

        private void btnPayTicket_Click(object sender, EventArgs e)
        {
            
            if (paymentTicketForm.Visible == false)
            {
                visibleForms.Add(paymentPackageForm);
                paymentTicketForm.Show();
            }
            else
            {
                hideAllForms(paymentTicketForm);
            }
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            
            if (customerForm.Visible == false)
            {
                visibleForms.Add(customerForm);
                customerForm.Show();
            }
            else
            {
                hideAllForms(customerForm);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async void MainForm_Load(object sender, EventArgs e)
        {
            if (!formLogin.isLogin)
            {
                this.Close();
                return;
            }
            //this.Dispose();


            // Get login information of user
            FormLogin.User user;
            user = formLogin.user;
            labelUsername.Text = $"Login as : {user.username}";

            dashboardForm = new DashboardForm();
            ticketForm = new TicketForm();
            packageForm = new PackageForm();
            staffForm = new StaffForm();
            customerForm = new CustomerForm();
            userForm = new UserForm();
            busForm = new BusForm();
            truckForm = new TruckForm();
            paymentTicketForm = new PaymentTicketForm();
            paymentPackageForm = new PaymentPackageForm();

            loadForm(ticketForm);
            loadForm(dashboardForm);
            loadForm(packageForm);
            loadForm(staffForm);
            loadForm(busForm);
            loadForm(userForm);
            loadForm(truckForm);
            loadForm(paymentPackageForm);
            loadForm(paymentTicketForm);
            loadForm(customerForm);

            mainPanelForms.Add(ticketForm);
            mainPanelForms.Add(dashboardForm);
            mainPanelForms.Add(packageForm);
            mainPanelForms.Add(staffForm);
            mainPanelForms.Add(busForm);
            mainPanelForms.Add(userForm);
            mainPanelForms.Add(truckForm);
            mainPanelForms.Add(paymentPackageForm);
            mainPanelForms.Add(paymentTicketForm);
            mainPanelForms.Add(customerForm);
        }

        bool sideBarExpand = true;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sideBarExpand)
            {
                sideBar.Width -= 10;

                btnDashboard.Text = removeChar(btnDashboard.Text);
                btnBus.Text = removeChar(btnBus.Text);
                btnUser.Text = removeChar(btnUser.Text);
                btnPackage.Text = removeChar(btnPackage.Text);
                btnStaff.Text = removeChar(btnStaff.Text);
                btnTicket.Text = removeChar(btnTicket.Text);
                btnTruck.Text = removeChar(btnTruck.Text);
                btnCustomer.Text = removeChar(btnCustomer.Text);
                btnPayTicket.Text = removeChar(btnPayTicket.Text);
                btnPayPackage.Text = removeChar(btnPayPackage.Text);

                if (sideBar.Width < 101)
                {
                    sideBarExpand = false;
                    sideBarTransition.Stop();
                }

            }
            else
            {
                sideBar.Width += 10;

                if (sideBar.Width > 200)
                {
                    btnDashboard.Text = "Dashboard";
                    btnBus.Text = "Bus";
                    btnUser.Text = "User";
                    btnPackage.Text = "Bagage";
                    btnStaff.Text = "Staff";
                    btnTicket.Text = "Ticket";
                    btnTruck.Text = "Payment";
                    btnCustomer.Text = "Customer";
                    btnPayPackage.Text = "Payment Package";
                    btnPayTicket.Text = "Payment Ticket";
                }

                if (sideBar.Width > 319)
                {
                    sideBarExpand = true;
                    sideBarTransition.Stop();
                }
            }

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            sideBarTransition.Start();

        }

        private string removeChar(string text)
        {
            string ret = "";
            for (int i = 0; i < text.Count() - 1; i++)
            {
                ret += text[i];
            }

            return ret;
        }
    }
}