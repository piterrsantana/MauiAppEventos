using Microsoft.Maui.Controls;

namespace MauiAppEventos.Views
{
    // Página responsável por exibir as opções do cardápio de buffet
    public partial class CardapioBuffet : ContentPage
    {
        // Construtor da página
        public CardapioBuffet()
        {
            // Carrega os componentes definidos no arquivo XAML
            InitializeComponent();
        }

        // Evento executado quando o botão é clicado
        private async void Button_Clicked(object sender, EventArgs e)
        {
            // Retorna para a página anterior da navegação
            await Navigation.PopAsync();
        }
    }
}