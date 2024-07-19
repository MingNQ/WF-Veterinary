using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowGUI.Model;
using WindowGUI.Presenter;
using WindowGUI.View;
using WindowGUI._Repositories;
using Microsoft.Data.SqlClient;

namespace WindowGUI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string connectionString = "Data Source=ITK-20221221TUA\\SQLEXPRESS;Initial Catalog=VeterinaryDB;"
                + "Integrated Security=True";
            IPetView view = new PetView();
            IPetRepository repository = new PetRepository(connectionString);
            new PetPresenter(view, repository);

            Application.Run((Form) view);
        }
    }
}
