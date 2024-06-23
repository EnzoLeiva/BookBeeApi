using AutoMapper;
using BookBee.Application.DataBase.Bookings.Commands.CreateBooking;
using BookBee.Application.DataBase.Customer.Commands.CreateCustomer;
using BookBee.Application.DataBase.Customer.Commands.UpdateCustomer;
using BookBee.Application.DataBase.Customer.Queries.GetAllCustomers;
using BookBee.Application.DataBase.Customer.Queries.GetCustomerByDocumentNumber;
using BookBee.Application.DataBase.Customer.Queries.GetCustomerById;
using BookBee.Application.DataBase.User.Commands.CreateUser;
using BookBee.Application.DataBase.User.Commands.UpdateUser;
using BookBee.Application.DataBase.User.Queries.GetAllUser;
using BookBee.Application.DataBase.User.Queries.GetUserByID;
using BookBee.Application.DataBase.User.Queries.GetUserByUserNameAndPassword;
using BookBee.Domain.Entities.Booking;
using BookBee.Domain.Entities.Customer;
using BookBee.Domain.Entities.User;

namespace BookBee.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region User
            CreateMap<UserEntity, CreateUserModel>().ReverseMap();
            CreateMap<UserEntity, UpdateUserModel>().ReverseMap();
            CreateMap<UserEntity, GetAllUserModel>().ReverseMap();
            CreateMap<UserEntity, GetUserByIdModel>().ReverseMap();
            CreateMap<UserEntity, GetUserByUserNameAndPasswordModel>().ReverseMap();
            #endregion

            #region Customer
            CreateMap<CustomerEntity, CreateCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, UpdateCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, GetAllCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, GetCustomerByIdModel>().ReverseMap();
            CreateMap<CustomerEntity, GetCustomerByDocumentNumberModel>().ReverseMap();

            #endregion

            #region Booking
            CreateMap<BookingEntity, CreateBookingModel>().ReverseMap();


            #endregion
        }
    }
}
