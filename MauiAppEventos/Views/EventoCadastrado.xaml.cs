using Microsoft.Maui.Controls;
using MauiAppEventos.Models;

namespace MauiAppEventos.Views
{
    public partial class EventoCadastrado : ContentPage
    {
        public EventoCadastrado()
        {
            InitializeComponent();
        }

        // Recebe a entidade preenchida na tela anterior.
        public EventoCadastrado(Evento evento)
        {
            InitializeComponent();

            //Atribui a entidade diretamente ao BindingContext da página para vinculação automática
            BindingContext = evento;
        }

        // Método de clique para retornar à visualização anterior
        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            // Remove a página atual da pilha de navegação do NavigationPage
            await Navigation.PopAsync();
        }
    }
}