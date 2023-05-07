using Mapster;
using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Configuration
{
    public class MapsterConfig
    {
        public MapsterConfig() 
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<Product, ProductDto>()
                .Map(name => name.Name, src => src.Name)
                .Map(weight => weight.Weight, src => src.Weight)
                .Map(price => price.Price, src => src.Price)
                .Map(quantity => quantity.QuantityInStorage, src => src.QuantityInStorage);
            config.NewConfig<OrderDetail, OrderDetailDto>()
                .Map(quantity => quantity.Quantity, src => src.Quantity);
            config.NewConfig<Order, OrderDto>();
            config.NewConfig<AppUser, AppUserDto>()
                .Map(name => name.Name, src => src.Name)
                .Map(address => address.Address, src => src.Address);

        }
    }
}
