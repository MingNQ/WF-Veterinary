using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowGUI.View
{
    public interface IPetView
    {
        // Properties - Fields
        string PetID { get; set; }
        string PetName { get; set; }
        string PetType { get; set; }
        string PetColor { get; set; }

        string SearchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        // Events
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancleEvent;

        // Methods
        void SetPetListBindingSource(BindingSource petList);
        void Show();
    }
}
