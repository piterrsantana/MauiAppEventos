using System;
using Microsoft.Maui.Controls;
using MauiAppEventos.Models;

namespace MauiAppEventos.Views
{
    public partial class CadastroEvento : ContentPage
    {
        public CadastroEvento()
        {
            InitializeComponent();

            // Define limites para impedir reservas retroativas.
            dtpck_inicio.MinimumDate = DateTime.Now;

            // Restringe reservas para até três meses à frente.
            dtpck_inicio.MaximumDate = DateTime.Now.AddMonths(3);

            // A data mínima de encerramento deve ser posterior à data atual.
            dtpck_termino.MinimumDate = DateTime.Now.AddDays(1);
        }
        private async void VerPacotes_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CardapioBuffet());
        }

        // Atualiza automaticamente a menor data possível para término da reserva.
        private void dtpck_inicio_DateSelected(object sender, DateChangedEventArgs e)
        {
            DateTime dataInicioSelecionada = (DateTime)dtpck_inicio.Date;

            dtpck_termino.MinimumDate = dataInicioSelecionada.AddDays(1);
        }

        // Responsável pela validação dos dados, criação do objeto Evento e navegação para a página de orçamento.
        [Obsolete]
        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Verificação básica dos campos obrigatórios.
                if (string.IsNullOrWhiteSpace(txt_nome.Text) ||
                    pck_tipo.SelectedItem == null ||
                    pck_local.SelectedItem == null)
                {
                    await DisplayAlert(
                        "Campos Incompletos",
                        "Por favor, preencha o nome do cliente e selecione o tipo de evento e o salão.",
                        "Ok");

                    return;
                }

                // Instanciação e preenchimento da entidade de negócio.
                Evento novoEvento = new Evento
                {
                    NomeCliente = txt_nome.Text,
                    TipoEvento = pck_tipo.SelectedItem.ToString(),
                    LocalSalao = pck_local.SelectedItem.ToString(),
                    QntAdultos = Convert.ToInt32(stp_adultos.Value),
                    QntCriancas = Convert.ToInt32(stp_criancas.Value),
                    DataInicio = (DateTime)dtpck_inicio.Date,
                    DataTermino = (DateTime)dtpck_termino.Date
                };

                // Navega para a página de resumo enviando o objeto preenchido por parâmetro.
                await Navigation.PushAsync(new EventoCadastrado(novoEvento));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro no Cadastro", $"Verifique os dados informados. Detalhes: {ex.Message}", "Ok");
            }
        }
    }
}