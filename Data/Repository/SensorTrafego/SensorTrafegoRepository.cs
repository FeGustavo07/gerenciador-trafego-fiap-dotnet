using fiap.gerenciador_trafego.Models;

namespace fiap.gerenciador_trafego.Data.Repository.SensorTrafego
{
    public class SensorTrafegoRepository : ISensorTrafegoRepository
    {
        private readonly DatabaseContext _context;

        public SensorTrafegoRepository(DatabaseContext context)
        {
            _context = context;
        }
        
        public SensorTrafegoModel Add(SensorTrafegoModel model)
        {
            _context.SensorTrafego.Add(model);
            _context.SaveChanges();
            return model;
        }

        public void DeleteById(SensorTrafegoModel model)
        {
            _context.SensorTrafego.Remove(model);
            _context.SaveChanges();
        }

        public IEnumerable<SensorTrafegoModel> GetAll()
        {
            return _context.SensorTrafego.ToList();
        }

        public SensorTrafegoModel GetById(int id)
        {
            return _context.SensorTrafego.Find(id) ?? throw new Exception("SensorTrafego não encontrado");
        }

        public SensorTrafegoModel Update(SensorTrafegoModel model)
        {
            _context.SensorTrafego.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
