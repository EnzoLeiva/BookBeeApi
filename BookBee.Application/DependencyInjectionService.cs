using AutoMapper;
using BookBee.Application.Configuration;
using BookBee.Application.DataBase.Bookings.Commands.CreateBooking;
using BookBee.Application.DataBase.Bookings.Queries.GetAllBookings;
using BookBee.Application.DataBase.Bookings.Queries.GetBookingsByDocumentNumber;
using BookBee.Application.DataBase.Bookings.Queries.GetBookingsByType;
using BookBee.Application.DataBase.Customer.Commands.CreateCustomer;
using BookBee.Application.DataBase.Customer.Commands.DeleteCustomer;
using BookBee.Application.DataBase.Customer.Commands.UpdateCustomer;
using BookBee.Application.DataBase.Customer.Queries.GetAllCustomers;
using BookBee.Application.DataBase.Customer.Queries.GetCustomerByDocumentNumber;
using BookBee.Application.DataBase.Customer.Queries.GetCustomerById;
using BookBee.Application.DataBase.User.Commands.CreateUser;
using BookBee.Application.DataBase.User.Commands.DeleteUser;
using BookBee.Application.DataBase.User.Commands.UpdateUser;
using BookBee.Application.DataBase.User.Commands.UpdateUserPassword;
using BookBee.Application.DataBase.User.Queries.GetAllUser;
using BookBee.Application.DataBase.User.Queries.GetUserByID;
using BookBee.Application.DataBase.User.Queries.GetUserByUserNameAndPassword;
using BookBee.Application.Validators.Booking;
using BookBee.Application.Validators.Customer;
using BookBee.Application.Validators.User;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BookBee.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var mapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperProfile());
            });

            services.AddSingleton(mapper.CreateMapper());

            #region User
            services.AddTransient<ICreateUserCommand, CreateUserCommand>();
            services.AddTransient<IUpdateUserCommand, UpdateUserCommand>();
            services.AddTransient<IDeleteUserCommand, DeleteUserCommand>();
            services.AddTransient<IUpdateUserPasswordCommand, UpdateUserPasswordCommand>();
            services.AddTransient<IGetAllUserQuery, GetAllUserQuery>();
            services.AddTransient<IGetUserByIdQuery, GetUserByIdQuery>();
            services.AddTransient<IGetUserByUserNameAndPasswordQuery, GetUserByUserNameAndPasswordQuery>();
            #endregion

            #region Customer
            services.AddTransient<ICreateCustomerCommand, CreateCustomerCommand>();
            services.AddTransient<IUpdateCustomerCommand, UpdateCustomerCommand>();
            services.AddTransient<IDeleteCustomerCommand, DeleteCustomerCommand>();
            services.AddTransient<IGetAllCustomerQuery, GetAllCustomerQuery>();
            services.AddTransient<IGetCustomerByIdQuery, GetCustomerByIdQuery>();
            services.AddTransient<IGetCustomerByDocumentNumberQuery, GetCustomerByDocumentNumberQuery>();

            #endregion

            #region Booking

            services.AddTransient<ICreateBookingCommand, CreateBookingCommand>();
            services.AddTransient<IGetAllBookingsQuery, GetAllBookingsQuery>();
            services.AddTransient<IGetBookingsByDocumentNumberQuery, GetBookingsByDocumentNumberQuery>();
            services.AddTransient<IGetBookingsByTypeQuery, GetBookingsByTypeQuery>();
            #endregion

            #region Validator
            services.AddScoped<IValidator<CreateUserModel>, CreateUserValidator>();
            services.AddScoped<IValidator<UpdateUserModel>, UpdateUserValidator>();
            services.AddScoped<IValidator<UpdateUserPasswordModel>, UpdateUserPasswordValidator>();
            services.AddScoped<IValidator<(string, string)>, GetUserByUserNameAndPasswordValidator>();

            services.AddScoped<IValidator<CreateCustomerModel>, CreateCustomerValidator>();
            services.AddScoped<IValidator<UpdateCustomerModel>, UpdateCustomerValidator>();


            services.AddScoped<IValidator<CreateBookingModel>, CreateBookingValidator>();


            #endregion


            return services;
        }
    }
}
