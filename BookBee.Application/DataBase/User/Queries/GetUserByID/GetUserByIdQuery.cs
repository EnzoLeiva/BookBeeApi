﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BookBee.Application.DataBase.User.Queries.GetUserByID
{
    public class GetUserByIdQuery : IGetUserByIdQuery
    {
        private readonly IDataBaseService _databaseService;
        private readonly IMapper _mapper;
        public GetUserByIdQuery(IDataBaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<GetUserByIdModel> Execute(int userId)
        {
            var entity = await _databaseService.Users
                .FirstOrDefaultAsync(x => x.UserId == userId);
            return _mapper.Map<GetUserByIdModel>(entity);
        }
    }
}
