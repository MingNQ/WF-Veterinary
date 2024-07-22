using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowGUI.View
{
    public partial class PetView : Form, IPetView
    {
        // Fields
        private string message;
        private bool isSuccessful;
        private bool isEdit;

        // Constructor
        public PetView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            tabPagePet.TabPages.Remove(tabPagePetDetail);
            btnClose.Click += delegate { this.Close(); };
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };
        }

        // Properties
        public string PetID
        {
            get { return txtPetId.Text; }
            set { txtPetId.Text = value; }
        }

        public string PetName
        {
            get { return txtPetName.Text; }
            set { txtPetName.Text = value; }
        }

        public string PetType 
        { 
            get { return txtPetType.Text; } 
            set { txtPetType.Text = value; }
        }

        public string PetColor 
        { 
            get { return txtPetColor.Text; }
            set { txtPetColor.Text = value; }
        }

        public string SearchValue
        {
            get { return txtSearch.Text; }
            set { txtSearch.Text = value; }
        }

        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }
        }

        public bool IsSuccessful
        {
            get { return isSuccessful; }
            set { isSuccessful = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        // Events
        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancleEvent;

        // Methods
        public void SetPetListBindingSource(BindingSource petList)
        {
            dataGridView.DataSource = petList;
        }

        // Singleton pattern (Open a single form instance)
        private static PetView instance;

        public static PetView GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)// If not exist
            {
                instance = new PetView();
                instance.MdiParent = parentContainer;
                instance.FormBorderStyle = FormBorderStyle.None;
                instance.Dock = DockStyle.Fill;
            }
            else // else if exist => bring to front
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;

                instance.BringToFront();
            }

            return instance;
        }
    }
}
