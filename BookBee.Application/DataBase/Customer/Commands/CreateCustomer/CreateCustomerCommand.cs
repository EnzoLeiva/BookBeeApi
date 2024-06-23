using AutoMapper;
using BookBee.Domain.Entities.Customer;

namespace BookBee.Application.DataBase.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommand : ICreateCustomerCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        public CreateCustomerCommand(IDataBaseService dataBaseService,
            IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<CreateCustomerModel> Execute(CreateCustomerModel model)
        {
            var entity = _mapper.Map<CustomerEntity>(model);
            await _dataBaseService.Customers.AddAsync(entity);
            await _dataBaseService.SaveAsync();
            return model;
        }
    }
}
