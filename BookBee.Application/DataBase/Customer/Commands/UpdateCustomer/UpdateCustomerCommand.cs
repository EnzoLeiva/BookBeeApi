using AutoMapper;
using BookBee.Domain.Entities.Customer;

namespace BookBee.Application.DataBase.Customer.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IUpdateCustomerCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        public UpdateCustomerCommand(IDataBaseService dataBaseService,
            IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<UpdateCustomerModel> Execute(UpdateCustomerModel model)
        {
            var entity = _mapper.Map<CustomerEntity>(model);
            _dataBaseService.Customers.Update(entity);
            await _dataBaseService.SaveAsync();
            return model;
        }
    }
}
