using AutoMapper;
using AutoMapperConsoleApp;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace AutoMapperConsoleApp
{
    class Program
    {
        private static ILoggerFactory loggerFactory;
        // Sets up and returns a LoggerFactory for console logging
        static ILoggerFactory SetupLoggerFactory()
        {
            return LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
                builder.SetMinimumLevel(LogLevel.Information);
            });
        }

        // Sets up and returns a standard IMapper instance
        static IMapper SetupMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<FinanceProfile>(), loggerFactory);
            return config.CreateMapper();
        }

        // Sets up and returns an IMapper instance with custom currency conversion
        static IMapper SetupMapperWithConversion()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Transaction, TransactionDTO>()
                    .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => Math.Round(src.Amount * 0.9m, 2)))
                    .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.AccountName, opt => opt.MapFrom(src => src.Account.Name))
                    .ForMember(dest => dest.DateString, opt => opt.MapFrom(src => src.Date.ToString("yyyy-MM-dd")));
            }, loggerFactory);
            return config.CreateMapper();
        }

        // Logs a single TransactionDTO
        static void LogTransactionDTO(ILogger logger, TransactionDTO dto, string prefix = "")
        {
            logger.LogInformation($"{prefix}{dto.Id}, {dto.Amount}, {dto.Details}, {dto.AccountName}, {dto.DateString}");
        }

        // Logs a collection of TransactionDTOs
        static void LogTransactionDTOs(ILogger logger, IEnumerable<TransactionDTO> dtos, string prefix = "")
        {
            foreach (var dto in dtos)
                LogTransactionDTO(logger, dto, prefix);
        }

        static void Main()
        {
            loggerFactory = SetupLoggerFactory();
            ILogger logger = loggerFactory.CreateLogger<Program>();

            var mapper = SetupMapper();

            // 1. Simple object-to-object mapping
            var transaction = new Transaction
            {
                Id = 1,
                Amount = 1500.75m,
                Description = "Salary for June",
                Date = new DateTime(2024, 6, 30),
                Account = new Account { Name = "Checking" }
            };
            var dto = mapper.Map<TransactionDTO>(transaction);
            logger.LogInformation("Simple Mapping:");
            LogTransactionDTO(logger, dto);

            // 2. Mapping a collection
            var transactions = new List<Transaction>
            {
                transaction,
                new Transaction { Id = 2, Amount = -200.00m, Description = "Groceries", Date = new DateTime(2024, 6, 25), Account = new Account { Name = "Checking" } }
            };
            var dtos = mapper.Map<List<TransactionDTO>>(transactions);
            logger.LogInformation("\nCollection Mapping:");
            LogTransactionDTOs(logger, dtos);

            // 3. Custom transformation (e.g., currency conversion)
            var mapperWithConversion = SetupMapperWithConversion();
            var dtoEur = mapperWithConversion.Map<TransactionDTO>(transaction);
            logger.LogInformation("\nCustom Transformation (USD to EUR):");
            LogTransactionDTO(logger, dtoEur);
        }
    }
}