using Microsoft.Maui.Controls;

namespace MauiAppEventos
{
    public partial class App : Application
    {
        // Construtor principal da aplicação
        public App()
        {
            // Carrega os componentes definidos no App.xaml
            InitializeComponent();

            // Define a primeira tela que será exibida ao iniciar o aplicativo
            MainPage = new NavigationPage(new Views.CadastroEvento());
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            // Cria a janela principal da aplicação
            var window = base.CreateWindow(activationState);

            // Define um tamanho padrão para melhor visualização em desktop
            window.Width = 430;
            window.Height = 740;

            return window;
        }
    }
}