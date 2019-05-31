using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using Telerik.WinControls;
using CRUDS_EXER.Presentation.vConfiguration.vUserAccount.vLogIn;
using CRUDS_EXER.Presentation.vConfiguration.vUserAccount.vUserAccountConfig;
using CRUDS_EXER.DataAccess.RepositoryManager;
using CRUDS_EXER.Domain.UserAccounts;

namespace CRUDS_EXER.Presentation.vMainForm
{
    public partial class frmMainDashboard : Telerik.WinControls.UI.RadForm
    {

        public frmLogin LogInPage;
        public UserAccount CurrentUserAccount;
        public UserAccountConfig accountConfig;
        public UserAccountRepository userAccountRepo;

        public frmMainDashboard()
        {
            InitializeComponent();
        }

        private bool LogInUser()
        {
            bool Success = true;
            frmLogin _frmLogin = new frmLogin();
            DialogResult Result = _frmLogin.ShowDialog();
            if(Result == System.Windows.Forms.DialogResult.OK)
            {

            }
            else
            {
                this.Close();
                Success = false;
            }

            return Success;

        }

        private void hideAllTabs()
        {
            radpgDashboard.Item.Visibility = ElementVisibility.Collapsed;
            radpgUserAccounts.Item.Visibility = ElementVisibility.Collapsed;
            radpgReports.Item.Visibility = ElementVisibility.Collapsed;
            
        }
        private void FrmMainDashboard_Load(object sender, EventArgs e)
        {
            LogInUser();
            hideAllTabs();
            radpgDashboard.Item.Visibility = ElementVisibility.Visible;
            radpageMenu.SelectedPage = radpgDashboard;
            
        }

        private void BtnUserAccount_Click(object sender, EventArgs e)
        {
            hideAllTabs();
            radpgUserAccounts.Item.Visibility = ElementVisibility.Visible;
            radpageMenu.SelectedPage = radpgUserAccounts;
            
        }

        void LoadAllUserAccount()
        {
            
        }
    }
}
