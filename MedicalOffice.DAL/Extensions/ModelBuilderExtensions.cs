using System;
using MedicalOffice.DAL.Models;
using MedicalOffice.DAL.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace MedicalOffice.DAL.Extensions;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Specialization>().HasData(
            new Specialization {Id = 1, Name = "Хирург"},
            new Specialization {Id = 2, Name = "Онколог"},
            new Specialization {Id = 3, Name = "Анестезиолог"}
        );

        modelBuilder.Entity<Region>().HasData(
            new Region {Id = 1, Number = "26"},
            new Region {Id = 2, Number = "28"},
            new Region {Id = 3, Number = "29"}
        );

        modelBuilder.Entity<Cabinet>().HasData(
            new Cabinet {Id = 1, Number = "289a"},
            new Cabinet {Id = 2, Number = "335"},
            new Cabinet {Id = 3, Number = "258"}
        );

        modelBuilder.Entity<Doctor>().HasData(
            new Doctor()
            {
                Id = 1,
                FirstName = "Виктор",
                LastName = "Васильев",
                SecondName = "Петрович",
                CabinetId = 1,
                SpecializationId = 1
            },
            new Doctor()
            {
                Id = 2,
                FirstName = "Николай",
                LastName = "Илонов",
                SecondName = "Алексеевич",
                CabinetId = 2,
                SpecializationId = 2
            },
            new Doctor()
            {
                Id = 3,
                FirstName = "Василий",
                LastName = "Сдобов",
                SecondName = "Васильевич",
                CabinetId = 3,
                SpecializationId = 3,
                RegionId = 1
            }
        );

        modelBuilder.Entity<Patient>().HasData(
            new Patient()
            {
                Id = 1,
                FirstName = "Иван",
                LastName = "Иванов",
                SecondName = "Иванович",
                Gender = Gender.Male,
                Address = "ул Калатушкина",
                DateOfBirth = new DateTime(1995, 5, 13)
            },
            new Patient()
            {
                Id = 2,
                FirstName = "Петр",
                LastName = "Петрович",
                SecondName = "Петров",
                Gender = Gender.Male,
                Address = "ул Калатушкина",
                DateOfBirth = new DateTime(1995, 1, 2)
            },
            new Patient()
            {
                Id = 3,
                FirstName = "Алексей",
                LastName = "Алексеевич",
                SecondName = "Алексеев",
                Gender = Gender.Male,
                Address = "ул Калатушкина",
                DateOfBirth = new DateTime(1995, 7, 23)
            },
            new Patient()
            {
                Id = 4,
                FirstName = "Виктор",
                LastName = "Викторов",
                SecondName = "Викторович",
                Gender = Gender.Male,
                Address = "ул Калатушкина",
                DateOfBirth = new DateTime(1995, 12, 14)
            },
            new Patient()
            {
                Id = 5,
                FirstName = "Юлия",
                LastName = "Иванова",
                SecondName = "Ивановна",
                Gender = Gender.Female,
                Address = "ул Калатушкина",
                DateOfBirth = new DateTime(1995, 3, 19)
            }
        );

        modelBuilder.Entity<PatientRegionMapping>().HasData(
            new PatientRegionMapping {PatientId = 1, RegionId = 1},
            new PatientRegionMapping {PatientId = 1, RegionId = 2},
            new PatientRegionMapping {PatientId = 3, RegionId = 1}
        );
    }
}