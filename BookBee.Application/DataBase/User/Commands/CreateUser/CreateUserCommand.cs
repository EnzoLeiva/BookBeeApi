using AutoMapper;
using BookBee.Application.External.Password;
using BookBee.Domain.Entities.User;

namespace BookBee.Application.DataBase.User.Commands.CreateUser
{
    public class CreateUserCommand : ICreateUserCommand
    {
        private readonly IDataBaseService _databaseService;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;

        public CreateUserCommand(IDataBaseService databaseService, IMapper mapper, IPasswordService passwordService)
        {
            _databaseService = databaseService;
            _mapper = mapper;
            _passwordService = passwordService;
        }
        public async Task<CreateUserModel> Execute(CreateUserModel model)
        {
            var entity = _mapper.Map<UserEntity>(model);
            entity.Password = _passwordService.Hash(entity.Password);
            await _databaseService.Users.AddAsync(entity);
            await _databaseService.SaveAsync();
            return model;
        }
    }
}
