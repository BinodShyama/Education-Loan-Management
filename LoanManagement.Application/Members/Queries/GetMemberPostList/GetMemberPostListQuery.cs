using AutoMapper;
using Dapper;
using LoanManagement.Domain;
using LoanManagement.ViewModel.Datatable;
using LoanManagement.ViewModel.Members;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanManagement.Application.Members.Queries.GetMemberPostList
{
    public class GetMemberPostListQuery : IRequest<DataTableResponseModel>
    {
        public DataTablePostModel dtModel { get; set; }
        public MemberSearchModel searchModel { get; set; }
        public class GetMemberPostListQueryHandler : IRequestHandler<GetMemberPostListQuery, DataTableResponseModel>
        {

            private readonly IConfiguration _config;

            public GetMemberPostListQueryHandler(IConfiguration config)
            {
                _config = config;
            }

            public async Task<DataTableResponseModel> Handle(GetMemberPostListQuery request, CancellationToken cancellationToken)
            {
                var totalCount = 0;
                try
                {
                    var sqlTotal = "";
                    var sql = $@"with m as(select m.Id,[FirstName] +' '+
                            case when [MiddleName] is null then '' else trim([MiddleName]) end +' '+ trim([LastName]) Name
                            ,[NationalIdentiryCardNumber]
                            ,[Gender]
                            ,[BirthofDateBS]
                            ,[CitizenShipNumber]
                            ,[MobileNumber]
                            ,[PermanentMunicipality] +' '+ [PermanentWardNumber] +',' +[PermanentStreet] + 
	                        case when [PermanentHouseNo] is null then '' else [PermanentHouseNo] end Address
                            ,[FatherFullName] FatherName
                             ,[Degree]
                            ,[Institution]
                            ,[University]
	                        ,[PermanentWardNumber] [WardNumber]
	                        ,[LoanAmount] SanctionAmount
                            from Member m left join MemberLoanDetail ld on m.Id = ld.MemberId)";
                    sqlTotal = $"{sql} select count(1) from m";
                    sql = $"{sql} select * from m where 1=1";


                    var orderBy = $"order by {request.dtModel.columns[request.dtModel.order[0].column].data} {request.dtModel.order[0].dir}  offset {request.dtModel.start} rows fetch next {request.dtModel.length} rows only";


                    var searchPram = "";
                    var searchList = new List<string>();
                    var filterList = new List<string>();
                    if (!String.IsNullOrEmpty(request.searchModel.degree))
                        filterList.Add($"degree ='{request.searchModel.degree}'");
                    if (!String.IsNullOrEmpty(request.searchModel.ward))
                        filterList.Add($"WardNumber = '{request.searchModel.ward}'");
                    if (!String.IsNullOrEmpty(request.searchModel.university))
                        filterList.Add($"university = '{request.searchModel.university}'");
                    if (!String.IsNullOrEmpty(request.searchModel.instiution))
                        filterList.Add($"Institution = '{request.searchModel.instiution}'");
                    if (!String.IsNullOrEmpty(request.searchModel.gender))
                        filterList.Add($"gender = '{request.searchModel.gender}'");
                    if (filterList.Count > 0)
                        searchList.Add($"({ string.Join(" and ", filterList)})");

                    if (!string.IsNullOrEmpty(request.dtModel.search.value))
                    {
                        request.dtModel.search.value = request.dtModel.search.value.Replace("'", "''");
                        filterList = new List<string>();
                        filterList.Add($" [Name] like '%{request.dtModel.search.value}%'");
                        filterList.Add($" [NationalIdentiryCardNumber] like '%{request.dtModel.search.value}%'");
                        filterList.Add($" [Gender] like '%{request.dtModel.search.value}%'");
                        filterList.Add($" [BirthofDateBS] like '%{request.dtModel.search.value}%'");
                        filterList.Add($" [CitizenShipNumber] like '%{request.dtModel.search.value}%'");
                        filterList.Add($" [MobileNumber] like '%{request.dtModel.search.value}%'");
                        filterList.Add($" [Address] like '%{request.dtModel.search.value}%'");
                        filterList.Add($" [FatherName] like '%{request.dtModel.search.value}%'");
                        filterList.Add($" [Degree] like '%{request.dtModel.search.value}%'");
                        filterList.Add($" [Institution] like '%{request.dtModel.search.value}%'");
                        filterList.Add($" [University] like '%{request.dtModel.search.value}%'");
                        filterList.Add($" [WardNumber] like '%{request.dtModel.search.value}%'");
                        filterList.Add($" [SanctionAmount] like '%{request.dtModel.search.value}%'");
                        searchList.Add($"({ string.Join(" or ", filterList)})");
                    }
                    if (searchList.Count > 0)
                    {
                        searchPram = $"({ string.Join(" or ", searchList)})";
                        sql = $"{sql} and {searchPram}";
                    }
                    sql = $"{sql}  {orderBy}";
                    using (var connection = new SqlConnection(_config.GetConnectionString("model")))
                    {
                        totalCount = connection.Query<int>(sqlTotal).First();

                        var dt = connection.Query<MemberListDto>(sql).ToList();
                        return new DataTableResponseModel()
                        {
                            data = dt,
                            draw = request.dtModel.draw,
                            recordsFiltered = dt.Count(),
                            recordsTotal = totalCount
                        };
                    }
                }
                catch (Exception ex)
                {
                    return new DataTableResponseModel()
                    {
                        data = new List<MemberListDto>(),
                        draw = request.dtModel.draw,
                        recordsFiltered = 0,
                        recordsTotal = totalCount
                };
            }
        }
    }
}
}
