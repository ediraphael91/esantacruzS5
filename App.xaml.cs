using esantacruzS5.Utils;

namespace esantacruzS5
{

    public partial class App : Application
    {
        public static PersonRepository personrepo { get; set; }

        public App(PersonRepository person)
        {
            InitializeComponent();

            MainPage = new Views.vHome();
            personrepo = person;
        }
    }
}
