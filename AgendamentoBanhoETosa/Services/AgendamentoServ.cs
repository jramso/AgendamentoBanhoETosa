using AgendamentoBanhoETosa.Model;

namespace SeuProjeto.Services
{
    public interface IAgendamentoServ
    {
        Task<List<Agendamento>> ObterTodosAsync();
        Task<Agendamento?> ObterPorIdAsync(int id);
        Task CriarAsync(Agendamento agendamento);
        Task AtualizarAsync(int id, Agendamento agendamentoAtualizado);
        Task DeletarAsync(int id);
    }
}
