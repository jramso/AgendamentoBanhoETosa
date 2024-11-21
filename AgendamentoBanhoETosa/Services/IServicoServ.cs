using AgendamentoBanhoETosa.Model;

namespace AgendamentoBanhoETosa.Services
{
    public interface IServicoServ
    {
        Task<IEnumerable<Servico>> GetAllServicosAsync();
        Task<Servico?> GetServicoByIdAsync(int id);
        Task<Servico> AddServicoAsync(Servico servico);
        Task<bool> UpdateServicoAsync(int id, Servico servico);
        Task<bool> DeleteServicoAsync(int id);
    }
}
