using System;
using System.Threading.Tasks;
using Twilio.Rest.Api.V2010.Account;
using AutoMapper;
using MessageService.Resources.Api.Models;
using MessageService.Send.Api.OperationsWithMessage;
using MessageService.Resources.Api.ModelsFilling;
using MessageService.Common.ExtraModels;

namespace MessageService.Send.Api.Repository
{
    public class SqlSendRepo : ISendRepo
    {
        private readonly MessageContext context;
        private readonly IMapper mapper;

        public SqlSendRepo(MessageContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task SendMessageAsync(SendModelDto request)
        {
            var transaction = await context.Database.BeginTransactionAsync();
            try
            {
                MessageResource resource = SendMessage.Send(request);

                SendModel processedRequest = mapper.Map<SendModel>(request);
                await context.SendModels.AddAsync(processedRequest);
                await context.SaveChangesAsync();

                InfoModel requestInfo = FillingOfInfoModel.GenerateInfo(processedRequest, resource, context);
                await context.InfoModels.AddAsync(requestInfo);
                await context.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
