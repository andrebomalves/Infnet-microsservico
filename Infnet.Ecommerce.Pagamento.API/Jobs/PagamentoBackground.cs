
using EasyNetQ;
using Infnet.Ecommerce.Pagamento.Dominio.Repositorios;
using Infnet.Ecommerce.Pagamento.Dominio.Repositorios.Consulta;

namespace Infnet.Ecommerce.Pagamento.API.Jobs
{
    public class PagamentoBackground : BackgroundService
    {
        private readonly ILogger<PagamentoBackground> logger;
        private readonly IPagamentoRepositorio pagamentoRepositorio;
        private readonly ICarrinhoRepositorio carrinhoRepositorio;
        private readonly IBus bus;
        private readonly string nomeFila;

        public PagamentoBackground(ILogger<PagamentoBackground> logger, IPagamentoRepositorio pagamentoRepositorio, ICarrinhoRepositorio carrinhoRepositorio)
        {
            this.logger = logger;
            this.pagamentoRepositorio = pagamentoRepositorio;
            this.carrinhoRepositorio = carrinhoRepositorio;
            bus = RabbitHutch.CreateBus("host=localhost;port=5672;username=guest;password=guest;");
            nomeFila = "Pagamento";
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {


            await bus.PubSub.SubscribeAsync<PagamentoConsulta>(nomeFila, async pagamentoRequest =>
            {
                Dominio.Entidades.Pagamento pagamento = new Dominio.Entidades.Pagamento();
                pagamento.CestaId = pagamentoRequest.CestaId;
                pagamento.UsuarioId = pagamentoRequest.UsuarioId;
                pagamento.ValorTotal = pagamentoRequest.ValorTotal;
                pagamento.Parcelas = pagamentoRequest.Parcelas;

                pagamentoRepositorio.Salvar(pagamento);
                carrinhoRepositorio.AtualizaStatus(pagamentoRequest.CestaId, "Fechada");

                Console.WriteLine($"Mensagem recebida.");
                await Task.Yield();
            });

            stoppingToken.Register(() =>
            {
                bus.Dispose();
            });

            await Task.Delay(Timeout.Infinite, stoppingToken);
        }

        public override void Dispose()
        {
            bus.Dispose();
            base.Dispose();
        }
    }
}
