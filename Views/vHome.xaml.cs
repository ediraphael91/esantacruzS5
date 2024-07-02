
using esantacruzS5.Models;
namespace esantacruzS5.Views;

public partial class vHome : ContentPage
{
	public vHome()
	{
		InitializeComponent();
	}
	private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        status.Text = "";
        App.personrepo.AddNewPerson(txtNombre.Text);
        status.Text = App.personrepo.StatusMessage;
    }

    private void btnListar_Clicked(object sender, EventArgs e)
    {
        status.Text = "";
        List<Persona> people = App.personrepo.GetAllPeople();
        ListaPersonas.ItemsSource = people;
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {

    }
}