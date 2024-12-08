using fiap.gerenciador_trafego.Models;

namespace fiap.gerenciador_trafego.Data.Repository.Rota
{
    public class RotaRepository : IRotaRepository
    {
        
        private readonly DatabaseContext _context;

        public RotaRepository(DatabaseContext context)
        {
            _context = context;
        }
        
        public RotaModel Add(RotaModel model)
        {
            _context.Rota.Add(model);
            _context.SaveChanges();
            return model;
        }

        public void DeleteById(RotaModel model)
        {
            _context.Rota.Remove(model);
            _context.SaveChanges();
        }

        public IEnumerable<RotaModel> GetAll()
        {
            _context.Rota.ToList();
            return _context.Rota.ToList();
        }

        public RotaModel GetById(int id)
        {
            return _context.Rota.Find(id) ?? throw new Exception("Rota não encontrada");
        }

        public RotaModel Update(RotaModel model)
        {
            _context.Rota.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
