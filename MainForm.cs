#region old codes

/*using Microsoft.VisualBasic;
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
            //f.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.PanelForm.Controls.Add(f);
            this.PanelForm.Tag = f;
            f.Hide();

        }

        public void hideAllForms(params Form[] forms)
        {
            // hides all forms in visibleForms excepts the forms in forms
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
                
                ticketForm.Show();
                hideAllForms(ticketForm);
            }
            else
            {
                
            }
        }   

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            
            if (dashboardForm.Visible == false)
            {
                
                dashboardForm.Show();
                hideAllForms(dashboardForm);
            }
            else
            {
                
            }
        }

        private void btnPackage_Click(object sender, EventArgs e)
        {
            
            if (packageForm.Visible == false)
            {
                
                packageForm.Show();
                hideAllForms(packageForm);
            }
            else
            {
                
            }
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            
            if (staffForm.Visible == false)
            {
                
                staffForm.Show();
                hideAllForms(staffForm);
            }
            else
            {
                
            }
        }

        private void btnBus_Click(object sender, EventArgs e)
        {
            
            if (busForm.Visible == false)
            {
                
                busForm.Show();
                hideAllForms(busForm);
            }
            else
            {
                
            }
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            
            if (userForm.Visible == false)
            {
                
                userForm.Show();
                hideAllForms(userForm);
            }
            else
            {
                
            }
        }

        private void btnTruck_Click(object sender, EventArgs e)
        {
            
            if (truckForm.Visible == false)
            {
                
                truckForm.Show();
                hideAllForms(truckForm);
            }
            else
            {
                
            }
        }
        private void btnPayPackage_Click(object sender, EventArgs e)
        {
            
            if (paymentPackageForm.Visible == false)
            {
                
                paymentPackageForm.Show();
                hideAllForms(paymentPackageForm);
            }
            else
            {
                
            }
        }

        private void btnPayTicket_Click(object sender, EventArgs e)
        {
            
            if (paymentTicketForm.Visible == false)
            {
                
                paymentTicketForm.Show();
                hideAllForms(paymentTicketForm);
            }
            else
            {
                
            }
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            
            if (customerForm.Visible == false)
            {
                
                customerForm.Show();
                hideAllForms(customerForm);
            }
            else
            {
                
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

            user.position = "Customer Service";
            if (user.position == "Customer Service")
            {
                btnUser.Hide();
                btnStaff.Hide();
                btnBus.Hide();
                btnTruck.Hide();
                sideBar.RowStyles[3].Height = 0;
                sideBar.RowStyles[4].Height = 0;
                sideBar.RowStyles[6].Height = 0;
                sideBar.RowStyles[7].Height = 0;
            }

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

            visibleForms.Add(ticketForm);
            visibleForms.Add(dashboardForm);
            visibleForms.Add(packageForm);
            visibleForms.Add(staffForm);
            visibleForms.Add(busForm);
            visibleForms.Add(userForm);
            visibleForms.Add(truckForm);
            visibleForms.Add(paymentPackageForm);
            visibleForms.Add(paymentTicketForm);
            visibleForms.Add(customerForm);


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
}*/

#endregion

using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace PABMS
{
    public partial class MainForm : Form
    {
        private string connectionString = "Data Source=LAPTOP-2O9AK3I7\\SQLISADE5;Initial Catalog=NewISAD;Integrated Security=True";
        private SqlConnection connection;

        private DashboardForm dashboardForm;
        private TicketForm ticketForm;
        private PackageForm packageForm;
        private StaffForm staffForm;
        private CustomerForm customerForm;
        private UserForm userForm;
        private BusForm busForm;
        private TruckForm truckForm;
        private PaymentTicketForm paymentTicketForm;
        private PaymentPackageForm paymentPackageForm;

        private List<Form> visibleForms = new List<Form>();
        private List<Form> mainPanelForms = new List<Form>();

        private FormLogin formLogin;
        public static FormLogin.User staticUser = null;

        public MainForm()
        {
            InitializeComponent();

            connection = new SqlConnection(connectionString);
            formLogin = new FormLogin(connection);
            formLogin.ShowDialog();

            InitializeForms();
            staticUser = formLogin.user;
        }

        private void InitializeForms()
        {
            dashboardForm = new DashboardForm();
            ticketForm = new TicketForm(connection);
            packageForm = new PackageForm(connection);
            staffForm = new StaffForm();
            customerForm = new CustomerForm();
            userForm = new UserForm();
            busForm = new BusForm(connection);
            truckForm = new TruckForm(connection);
            paymentTicketForm = new PaymentTicketForm();
            paymentPackageForm = new PaymentPackageForm();

            AddFormsToList(visibleForms, dashboardForm, ticketForm, packageForm, staffForm, customerForm, userForm, busForm, truckForm, paymentTicketForm, paymentPackageForm);
            AddFormsToList(mainPanelForms, dashboardForm, ticketForm, packageForm, staffForm, customerForm, userForm, busForm, truckForm, paymentTicketForm, paymentPackageForm);
        }

        private void AddFormsToList(List<Form> list, params Form[] forms)
        {
            list.AddRange(forms);
        }

        public void LoadForm(Form form)
        {
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.PanelForm.Controls.Add(form);
            this.PanelForm.Tag = form;
            form.Hide();
        }

        public void HideAllForms(params Form[] forms)
        {
            foreach (Form f in visibleForms)
            {
                if (!forms.Contains(f))
                {
                    f.Hide();
                }
            }
        }

        private void ShowForm(Form form)
        {
            if (!form.Visible)
            {
                form.Show();
                HideAllForms(form);
            }
        }

        private void btnTicket_Click(object sender, EventArgs e) => ShowForm(ticketForm);
        private void btnDashboard_Click(object sender, EventArgs e) => ShowForm(dashboardForm);
        private void btnPackage_Click(object sender, EventArgs e) => ShowForm(packageForm);
        private void btnStaff_Click(object sender, EventArgs e) => ShowForm(staffForm);
        private void btnBus_Click(object sender, EventArgs e) => ShowForm(busForm);
        private void btnUser_Click(object sender, EventArgs e) => ShowForm(userForm);
        private void btnTruck_Click(object sender, EventArgs e) => ShowForm(truckForm);
        private void btnPayPackage_Click(object sender, EventArgs e) => ShowForm(paymentPackageForm);
        private void btnPayTicket_Click(object sender, EventArgs e) => ShowForm(paymentTicketForm);
        private void btnCustomer_Click(object sender, EventArgs e) => ShowForm(customerForm);
        private void btnExit_Click(object sender, EventArgs e) => this.Close();

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!formLogin.isLogin)
            {
                this.Close();
                return;
            }

            FormLogin.User user = formLogin.user;
            labelUsername.Text = $"Login as : {user.username}";

            if (user.position == "Customer Service")
            {
                HideButtons(btnUser, btnStaff, btnBus, btnTruck);
                SetRowHeights(0, 0, 0, 0);
            }
            LoadAllForms();
        }

        private void HideButtons(params Button[] buttons)
        {
            foreach (var button in buttons)
            {
                button.Hide();
            }
        }

        private void SetRowHeights(params int[] heights)
        {
            sideBar.RowStyles[3].Height = heights[0];
            sideBar.RowStyles[4].Height = heights[1];
            sideBar.RowStyles[6].Height = heights[2];
            sideBar.RowStyles[7].Height = heights[3];
        }

        private void LoadAllForms()
        {
            foreach (var form in mainPanelForms)
            {
                LoadForm(form);
            }
        }

        private bool sideBarExpand = true;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sideBarExpand)
            {
                sideBar.Width -= 10;
                UpdateButtonText(removeChar);
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
                    ResetButtonText();
                }
                if (sideBar.Width > 319)
                {
                    sideBarExpand = true;
                    sideBarTransition.Stop();
                }
            }
        }

        private void UpdateButtonText(Func<string, string> updateFunc)
        {
            btnDashboard.Text = updateFunc(btnDashboard.Text);
            btnBus.Text = updateFunc(btnBus.Text);
            btnUser.Text = updateFunc(btnUser.Text);
            btnPackage.Text = updateFunc(btnPackage.Text);
            btnStaff.Text = updateFunc(btnStaff.Text);
            btnTicket.Text = updateFunc(btnTicket.Text);
            btnTruck.Text = updateFunc(btnTruck.Text);
            btnCustomer.Text = updateFunc(btnCustomer.Text);
            btnPayTicket.Text = updateFunc(btnPayTicket.Text);
            btnPayPackage.Text = updateFunc(btnPayPackage.Text);
        }

        private void ResetButtonText()
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

        private void btnMenu_Click(object sender, EventArgs e) => sideBarTransition.Start();

        private string removeChar(string text) => text.Length > 0 ? text.Substring(0, text.Length - 1) : text;
    }
}
