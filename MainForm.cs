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
        private FormLogin.User user;

        public MainForm()
        {
            InitializeComponent();

            connection = new SqlConnection(connectionString);
            formLogin = new FormLogin(connection);
            formLogin.ShowDialog();

            InitializeForms();

            user = formLogin.user;
            PanelForm.Tag = user;
        }

        private void InitializeForms()
        {
            dashboardForm = new DashboardForm();
            ticketForm = new TicketForm(connection);
            packageForm = new PackageForm();
            staffForm = new StaffForm();
            customerForm = new CustomerForm();
            userForm = new UserForm();
            busForm = new BusForm();
            truckForm = new TruckForm();
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

            if (user.position == "Cashier")
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
