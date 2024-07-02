
using esantacruzS5.Models;
namespace esantacruzS5.Views;

public partial class vHome : ContentPage
{
    private Persona selectedPerson;
    public vHome()
	{
		InitializeComponent();
	}

    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        selectedPerson = e.CurrentSelection.FirstOrDefault() as Persona;
        if (selectedPerson != null)
        {
            txtNombre.Text = selectedPerson.Nombre;
        }
    }
    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        status.Text = "";
        App.personrepo.AddNewPerson(txtNombre.Text);
        status.Text = App.personrepo.StatusMessage;
        ListaPersonas.ItemsSource = App.personrepo.GetAllPeople();
    }

    private void btnListar_Clicked(object sender, EventArgs e)
    {
        status.Text = "";
        ListaPersonas.ItemsSource = App.personrepo.GetAllPeople();
    }

    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        status.Text = "";

        if (selectedPerson != null)
        {
            bool confirm = await DisplayAlert("Confirmar eliminación",
                                              $"¿Esta seguro de que desea eliminar a {selectedPerson.Nombre}?",
                                              "Sí", "No");

            if (confirm)
            {
                App.personrepo.DeletePerson(selectedPerson.Id);
                status.Text = App.personrepo.StatusMessage;
                ListaPersonas.ItemsSource = App.personrepo.GetAllPeople();
                selectedPerson = null;
                txtNombre.Text = string.Empty;
            }
        }
        else
        {
            status.Text = "Seleccione una persona para eliminar";
        }
    }
    private void btnModificar_Clicked(object sender, EventArgs e)
    {
        status.Text = "";

        if (selectedPerson != null)
        {
            selectedPerson.Nombre = txtNombre.Text;
            App.personrepo.UpdatePerson(selectedPerson);
            status.Text = App.personrepo.StatusMessage;
            ListaPersonas.ItemsSource = App.personrepo.GetAllPeople();
            selectedPerson = null;
            txtNombre.Text = string.Empty;
        }
        else
        {
            status.Text = "Seleccione una persona para modificar";
        }
    }
}