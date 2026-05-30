using Microsoft.Maui.Controls;

namespace MauiAppEventos.Views
{
    public partial class CardapioBuffet : ContentPage
    {
        public CardapioBuffet()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}