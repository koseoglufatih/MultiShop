﻿using Dapper;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;
using System.Net.Http.Headers;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dapperContext;

        public DiscountService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            string query = "insert into Coupons(Code,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isActive", createCouponDto.IsActive);
            parameters.Add("@validDate", createCouponDto.ValidDate);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async Task DeleteCouponAsync(int id)
        {
            string query = "Delete From Coupons where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCouponDto>> GetAllCouponsAsync()
        {
            string query = "Select * from Coupons";
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdCouponDto> GetByIdCouponAsync(int id)
        {
            string query = "Select * from Coupons where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(query);
                return values;
            }
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "Update Coupons Set Code=@code,Rate=@rate,IsActive=@isActive,ValidDate=@validDate where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@isActive", updateCouponDto.IsActive);
            parameters.Add("@validDate", updateCouponDto.ValidDate);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
