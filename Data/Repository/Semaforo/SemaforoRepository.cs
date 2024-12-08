using fiap.gerenciador_trafego.Models;

namespace fiap.gerenciador_trafego.Data.Repository.Semaforo
{
    public class SemaforoRepository : ISemaforoRepository
    {
        private readonly DatabaseContext _context;
        
        public SemaforoRepository(DatabaseContext context)
        {
            _context = context;
        }
        
        public SemaforoModel Add(SemaforoModel model)
        {
            _context.Semaforo.Add(model);
            _context.SaveChanges();
            return model;
        }

        public void DeleteById(SemaforoModel model)
        {
            _context.Semaforo.Remove(model);
            _context.SaveChanges();
        }

        public IEnumerable<SemaforoModel> GetAll()
        {
            return _context.Semaforo.ToList();
        }

        public SemaforoModel GetById(int id)
        {
            return _context.Semaforo.Find(id) ?? throw new Exception("Clima não encontrado");
        }

        public SemaforoModel Update(SemaforoModel model)
        {
            _context.Semaforo.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
