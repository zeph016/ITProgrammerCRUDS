using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Linq;
using CRUDS_EXER.Presentation.vMainForm;
using CRUDS_EXER.DataAccess.RepositoryManager;
using CRUDS_EXER.Domain.UserAccounts;


namespace CRUDS_EXER.Presentation.vConfiguration.vUserAccount.vLogIn
{
    public partial class frmLogin : Telerik.WinControls.UI.RadForm
    {

        UserAccountRepository userAccountRepo;
        public UserAccount currentUserAccount;
        public frmLogin()
        {
            InitializeComponent();

            userAccountRepo = new UserAccountRepository();
        }

        public void LoginButton()
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                RadMessageBox.SetThemeName("Office2010Blue");
                RadMessageBox.Show("Please input Username", "Username is blank", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                RadMessageBox.SetThemeName("Office2010Blue");
                RadMessageBox.Show("Please input Username", "Username is blank", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            UserAccount CurUserAccount = new UserAccount();
            CurUserAccount.UserName = txtUsername.Text.Trim();
            CurUserAccount.Password = txtPassword.Text.Trim();

            currentUserAccount = userAccountRepo.AuthenticateUser(CurUserAccount);
            if (currentUserAccount != null)
            {
                var form = Application.OpenForms.OfType<frmMainDashboard>().FirstOrDefault();
                if (form != null)
                {
                    form.LogInPage = this;
                    form.CurrentUserAccount = currentUserAccount;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    form.ShowIcon = true;
                }
                else
                {
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                }
            }
            else
            {
                txtUsername.Text = "";
                txtPassword.Text = "";
                RadMessageBox.SetThemeName("Office2010Blue");
                RadMessageBox.Show("Please input the correct Username and Password", "Notice", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }


        private void BtnLogIn_Click(object sender, EventArgs e)
        {
            LoginButton();
        }

        #region textboxEnter_LeaveControl

        private void TxtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.Black;
            }
        }

        private void TxtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "Username";
                txtUsername.ForeColor = Color.Silver;
            }
        }

        private void TxtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.PasswordChar = '*';
            }
        }

        private void TxtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.Silver;
                txtPassword.PasswordChar = '\0';
            }
        }



        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnLogIn;
        }
        #endregion

        private void BtnExit_Click(object sender, EventArgs e)
        {
            RadMessageBox.SetThemeName("Office2010Blue");
            if (RadMessageBox.Show("Do you want to Exit?", "Exit", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else
            {

            }
        }
    }
}
