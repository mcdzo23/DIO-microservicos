using ProductService.Data;
using ProductService.Models;

namespace ProductService.Services {
    public class ProductService {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context) {
            _context = context;
        }

        public void Add(Product product) {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public List<Product> GetAll() {
            return _context.Products.ToList();
        }

        public void ReduceStock(int id, int quantity) {
            var product = _context.Products.Find(id);
            if (product != null && product.Quantity >= quantity) {
                product.Quantity -= quantity;
                _context.SaveChanges();
            }
        }
    }
}
