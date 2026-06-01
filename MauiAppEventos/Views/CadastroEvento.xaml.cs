using MauiAppEventos.Models;

namespace MauiAppEventos.Views
{
    public partial class CadastroEvento : ContentPage
    {
        public CadastroEvento()
        {
            InitializeComponent();

            // Impede a seleção de datas anteriores à atual.
            dtpck_inicio.MinimumDate = DateTime.Now;

            // Permite reservas com até três meses de antecedência.
            dtpck_inicio.MaximumDate = DateTime.Now.AddMonths(3);

            // Define a menor data possível para o término da reserva.
            dtpck_termino.MinimumDate = DateTime.Now;
        }


        // Abre a página com os detalhes dos pacotes oferecidos pelo buffet.
        private async void VerPacotes_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CardapioBuffet());
        }

        // Atualiza os limites da data de término conforme a data inicial escolhida.
        private void dtpck_inicio_DateSelected(object sender, DateChangedEventArgs e)
        {
            // Verifica se uma data válida foi selecionada.
            if (e.NewDate == null) return;

            DateTime dataInicioSelecionada = e.NewDate.Value;

            // Mantém a data de término alinhada com a nova data inicial.
            dtpck_termino.Date = dataInicioSelecionada;

            // Permite reservas no mesmo dia ou em até dois dias após o início.
            dtpck_termino.MinimumDate = dataInicioSelecionada;
            dtpck_termino.MaximumDate = dataInicioSelecionada.AddDays(2);
        }

        // Valida os dados e gera o orçamento do evento.
        [Obsolete]
        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Confirma que as datas foram informadas.
                if (string.IsNullOrWhiteSpace(txt_nome.Text) ||
                    pck_tipo.SelectedItem == null ||
                    pck_local.SelectedItem == null)
                {
                    await DisplayAlert("Campos Incompletos", "Por favor, preencha o nome do cliente e selecione o tipo de evento e o salão.", "Ok");
                    return;
                }

                if (dtpck_inicio.Date == null || dtpck_termino.Date == null)
                {
                    await DisplayAlert("Datas Ausentes", "Por favor, selecione as datas de início e término do evento.", "Ok");
                    return;
                }

                // Verifica se o período escolhido atende às regras da reserva.
                if (dtpck_termino.Date.Value < dtpck_inicio.Date.Value ||
                    dtpck_termino.Date.Value > dtpck_inicio.Date.Value.AddDays(2))
                {
                    await DisplayAlert("Período Inválido", "O término do evento deve ser no mesmo dia ou em até 2 dias após o início (limite de fim de semana).", "Ok");
                    return;
                }

                // Cria o objeto com os dados informados pelo usuário.
                Evento novoEvento = new Evento
                {
                    NomeCliente = txt_nome.Text,
                    TipoEvento = pck_tipo.SelectedItem.ToString(),
                    LocalSalao = pck_local.SelectedItem.ToString(),
                    QntAdultos = Convert.ToInt32(stp_adultos.Value),
                    QntCriancas = Convert.ToInt32(stp_criancas.Value),
                    DataInicio = dtpck_inicio.Date.Value,
                    DataTermino = dtpck_termino.Date.Value
                };

                // Abre a tela de resumo do orçamento.
                await Navigation.PushAsync(new EventoCadastrado(novoEvento));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro no Cadastro", $"Verifique os dados informados. Detalhes: {ex.Message}", "Ok");
            }
        }
    }
}