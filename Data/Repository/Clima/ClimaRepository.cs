using fiap.gerenciador_trafego.Models;


namespace fiap.gerenciador_trafego.Data.Repository.Clima;

public class ClimaRepository : IClimaRepository
{
    private readonly DatabaseContext _context;

    public ClimaRepository(DatabaseContext context)
    {
        _context = context;
    }

    public IEnumerable<ClimaModel> GetAll()
    {
        return _context.Clima.ToList();
    }

    public ClimaModel GetById(long id) => _context.Clima.Find(id) ?? throw new Exception("Clima não encontrado");

    public ClimaModel Add(ClimaModel clima)
    {
        _context.Clima.Add(clima);
        _context.SaveChanges();
        return clima;
    }

    public ClimaModel Update(ClimaModel clima)
    {
        _context.Clima.Update(clima);
        _context.SaveChanges();
        return clima;
    }

    public void Delete(ClimaModel clima)
    {
        _context.Clima.Remove(clima);
        _context.SaveChanges();
    }
}