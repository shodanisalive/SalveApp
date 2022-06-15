using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalveApp.DAL;
using SalveApp.Infrastructure;
using SalveApp.Infrastructure.Entities;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SalveApp.Root
{
    public static class DataGenerator
    {
        public static void Initialise(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            using var context = scope.ServiceProvider.GetService<EFContext>();
            
            if (context.Clinics.Any() || context.Patients.Any())
            {
                return;   // Data was already seeded
            }

            var asm = Assembly.GetExecutingAssembly();

            ReadAndSaveAll<Clinic, ClinicMap>(asm, "SalveApp.Root.Files.clinics.csv", context);
            ReadAndSaveAll<Patient, PatientMap>(asm, "SalveApp.Root.Files.patients-1.csv", context);
            ReadAndSaveAll<Patient, PatientMap>(asm, "SalveApp.Root.Files.patients-2.csv", context);

            context.SaveChanges();
        }

        private static void ReadAndSaveAll<T, TMap>(Assembly asm, string resourceName, EFContext efContext)
            where T : class, IAggregateRoot
            where TMap : ClassMap<T>
        {
            using var stream = asm.GetManifestResourceStream(resourceName);
            using var reader = new StreamReader(stream);
            using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

            csvReader.Context.RegisterClassMap<TMap>();
            var records = csvReader.GetRecords<T>();

            efContext.Set<T>().AddRange(records);
        }

        private class ClinicMap : ClassMap<Clinic>
        {
            public ClinicMap()
            {
                Map(x => x.Id).Name("id");
                Map(x => x.Name).Name("name");
            }
        }

        private class PatientMap : ClassMap<Patient>
        {
            public PatientMap()
            {
                Map(x => x.Id).Ignore();
                Map(x => x.ClinicId).Name("clinic_id");
                Map(x => x.FirstName).Name("first_name");
                Map(x => x.LastName).Name("last_name");
                Map(x => x.DateOfBirth).Name("date_of_birth");
            }
        }
    }
}
