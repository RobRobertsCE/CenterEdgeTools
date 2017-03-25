using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CECode.Authentication;

namespace CECodeHelper.Forms
{
    public partial class AccountProfilesDialog : Form
    {
        #region enumerations
        private enum FormStates
        {
            Loading,
            Viewing,
            Editing
        }
        #endregion

        #region fields
        private AccountProfile _selectedIdentity;
        private FormStates _formState = FormStates.Loading;
        #endregion


        #region public properties
        public bool AccountProfilesChanged { get; set; }
        #endregion

        #region ctor / load
        public AccountProfilesDialog()
        {
            InitializeComponent();
        }

        private void Accounts_Load(object sender, EventArgs e)
        {
            try
            {
                SetFormState(FormStates.Loading);

                lblWinUser.Text = String.Format("Accounts for {0}", Environment.UserName);

                LoadAccountSelectionList();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
            finally
            {
                SetFormState(FormStates.Viewing);
                cboAccounts.SelectedIndex = 0;
            }
        }
        #endregion

        #region private methods
        private void ExceptionHandler(Exception ex)
        {
            MessageBox.Show(ex.Message);
            Console.WriteLine(ex.ToString());
        }

        private void LoadAccountSelectionList()
        {
            List<AccountType> accounts = Enum.GetValues(typeof(AccountType)).Cast<AccountType>().ToList();
            cboAccounts.DataSource = accounts;
            cboAccounts.SelectedIndex = -1;
        }

        private void SetFormState(FormStates state)
        {
            switch (state)
            {
                case FormStates.Loading:
                    {
                        cboAccounts.Enabled = false;
                        pnlAccountDetails.Enabled = false;
                        btnEditSave.Enabled = false;
                        btnEditSave.Text = "Edit";
                        btnEditSave.Enabled = false;
                        btnCancelClose.Text = "Close";
                        break;
                    }
                case FormStates.Viewing:
                    {
                        cboAccounts.Enabled = true;
                        pnlAccountDetails.Enabled = false;
                        btnEditSave.Enabled = true;
                        btnEditSave.Text = "Edit";
                        btnEditSave.Enabled = true;
                        btnCancelClose.Text = "Close";
                        break;
                    }
                case FormStates.Editing:
                    {
                        cboAccounts.Enabled = false;
                        pnlAccountDetails.Enabled = true;
                        btnEditSave.Enabled = true;
                        btnEditSave.Text = "Save";
                        btnEditSave.Enabled = true;
                        btnCancelClose.Text = "Cancel";
                        break;
                    }
            }
            _formState = state;
        }

        private void ClearAccountDetailsDisplay()
        {
            txtLogin.Clear();
            txtPassword.Clear();
            txtToken.Clear();
            txtUrl.Clear();
            txtOwner.Clear();

            _selectedIdentity = null;
        }

        private void AccountSelectionChanged()
        {
            try
            {
                ClearAccountDetailsDisplay();

                if (_formState == FormStates.Loading) return;

                if (null == cboAccounts.SelectedItem) return;

                var selectedAccount = (AccountType)cboAccounts.SelectedItem;

                _selectedIdentity = AccountProfileHelper.GetTAccountInfo(selectedAccount);

                if (null != _selectedIdentity)
                {
                    ViewAccount(_selectedIdentity);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void EditAccount()
        {
            try
            {
                SetFormState(FormStates.Editing);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void SaveAccount(AccountProfile account)
        {
            try
            {
                if (string.IsNullOrEmpty(txtLogin.Text))
                    MessageBox.Show("Login name is required");
                else
                {
                    account.Login = txtLogin.Text;
                    account.Password = txtPassword.Text;
                    account.Token = txtToken.Text;
                    account.URL = txtUrl.Text;
                    account.Owner = txtOwner.Text;
                    AccountProfileHelper.UpdateAccountInfo(account);
                    AccountProfilesChanged = true;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void ViewAccount(AccountProfile account)
        {
            try
            {
                SetFormState(FormStates.Viewing);

                switch (account.Account)
                {
                    case AccountType.GitHub:
                        {
                            pnlLogin.Visible = true;
                            pnlPassword.Visible = false;
                            pnlToken.Visible = true;
                            pnlOwner.Visible = true;
                            pnlUrl.Visible = false;

                            break;
                        }
                    case AccountType.JIRA:
                        {
                            pnlLogin.Visible = true;
                            pnlPassword.Visible = true;
                            pnlToken.Visible = false;
                            pnlOwner.Visible = false;
                            pnlUrl.Visible = true;

                            break;
                        }
                    case AccountType.TeamCity:
                        {
                            pnlLogin.Visible = true;
                            pnlPassword.Visible = true;
                            pnlToken.Visible = false;
                            pnlOwner.Visible = false;
                            pnlUrl.Visible = false;

                            break;
                        }
                }

                txtLogin.Text = account.Login;
                txtPassword.Text = account.Password;
                txtToken.Text = account.Token;
                txtOwner.Text = account.Owner;
                txtUrl.Text = account.URL;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        #endregion

        #region private event handlers
        private void btnEditSave_Click(object sender, EventArgs e)
        {
            if (_formState == FormStates.Viewing)
            {
                EditAccount();
            }
            else if (_formState == FormStates.Editing)
            {
                SaveAccount(_selectedIdentity);
            }
        }

        private void btnCancelClose_Click(object sender, EventArgs e)
        {
            if (_formState == FormStates.Viewing)
            {
                this.Close();
            }
            else if (_formState == FormStates.Editing)
            {
                var confirmation = MessageBox.Show("Cancel without saving changes?", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmation == System.Windows.Forms.DialogResult.Yes)
                {
                    var selectedIdx = cboAccounts.SelectedIndex;
                    cboAccounts.SelectedIndex = -1;
                    cboAccounts.SelectedIndex = selectedIdx;
                }
            }
        }

        private void cboAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            AccountSelectionChanged();
        }
        #endregion
    }
}
