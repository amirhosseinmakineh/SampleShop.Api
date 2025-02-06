using AutoMapper;
using SampleShop.ApplicationService.Contract.Convertor;
using SampleShop.ApplicationService.Contract.Dtos.OrderDto;
using SampleShop.ApplicationService.Contract.IServices;
using SampleShop.ApplicationService.UnitOfWork;
using SampleShop.Domain.IRepositories;
using SampleShop.Domain.Models;

namespace SampleShop.ApplicationService.Services
{
    public class OrderService : IOrderService
    {
        private readonly DateConvertor dateConvertor;
        private readonly IMapper mapper;
        private readonly IBaseRepository<long, Order> repository;
        private readonly IProductRepository productRepository;
        private readonly IBaseRepository<Guid, User> userRepository;
        private readonly IBaseRepository<long, OrderProduct> orderProductRepository;
        private readonly IBaseRepository<long, OrderDetail> orderDetailRepository;
        public OrderService(IBaseRepository<long, Order> repository, IProductRepository productRepository, IBaseRepository<Guid, User> userRepository, IMapper mapper, IBaseRepository<long, OrderProduct> orderProductRepository, DateConvertor dateConvertor)
        {
            this.repository = repository;
            this.productRepository = productRepository;
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.orderProductRepository = orderProductRepository;
            this.dateConvertor = dateConvertor;
        }
        [UnitOfWork]
        public void AddOrder(AddOrderDto dto)
        {
            var user = userRepository.GetById(dto.UserId);
            var order = mapper.Map<Order>(dto);
            List<OrderProduct> orderProducts = new List<OrderProduct>();
            repository.Add(order);
            foreach(var productId in dto.ProductIds)
            {
                var product = productRepository.GetById(productId);
                var orderProduct = new OrderProduct()
                {
                    ProductId = productId,
                    CreateObjectDat = dateConvertor.CreatePerisanDate(DateTime.Now, out string resultDate),
                    Id = dto.Id,
                    IsDelete = false,
                    OrderId = dto.OrderId,
                    ProductPrice = (decimal)product.Price
                };
                orderProducts.Add(orderProduct);
            }
            orderProductRepository.AddRange(orderProducts);
            var totalSum = orderProductRepository.GetAll()
                .Where(x => x.OrderId == order.Id)
                .Select(x => x.ProductPrice)
                .Sum();

            var orderDetail = new OrderDetail()
            {
                CreateObjectDat = dateConvertor.CreatePerisanDate(DateTime.Now, out string persianDate),
                Id = dto.DetailDto.Id,
                IsDelete = false,
                OrderId = order.Id,
                TotalOrderSum = totalSum
            };
            orderDetailRepository.Add(orderDetail);
            repository.SaveChanges();
        }
    }
}
