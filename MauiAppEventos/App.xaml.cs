using Microsoft.Maui.Controls;

namespace MauiAppEventos
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Inicializa o aplicativo abrindo a tela de cadastro do Buffet dentro da navegação
            MainPage = new NavigationPage(new Views.CadastroEvento());
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);

            // Redimensiona a janela para uma proporção agradável no computador/gravação do vídeo
            window.Width = 430;
            window.Height = 750;

            return window;
        }
    }
}
