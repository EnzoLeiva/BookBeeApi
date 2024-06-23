using AutoMapper;
using BookBee.Domain.Entities.User;

namespace BookBee.Application.DataBase.User.Commands.UpdateUser
{
    public class UpdateUserCommand : IUpdateUserCommand
    {
        private readonly IDataBaseService _databaseService;
        private readonly IMapper _mapper;

        public UpdateUserCommand(IDataBaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<UpdateUserModel> Execute(UpdateUserModel model)
        {
            var entity = _mapper.Map<UserEntity>(model);
            _databaseService.Users.Update(entity);
            await _databaseService.SaveAsync();
            return model;
        }
    }
}
