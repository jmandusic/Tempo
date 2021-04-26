using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tempo.Data.Entities.Models;
using Tempo.Data.Enums;

namespace Tempo.Data.Seed
{
    public class DatabaseSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Gym>()
                .HasData(new List<Gym>
                {
                    new Gym
                    {
                        Id = 1,
                        Name = "Fitness Centar Joker",
                        Rating = 4.6f,
                        ContactEmail = "joker@mail.com",
                        MembershipFee = 250f,
                        Capacity = 120,
                        StartOfWork = new DateTime(576000),
                        EndOfWork = new DateTime(1656000),
                        Latitude = 43.5198509f,
                        Longitude = 16.4472581f,
                        AdminId = 1,
                        AdressId = 1,
                    },
                    new Gym
                    {
                        Id = 2,
                        Name = "Guliver energija",
                        Rating = 4.7f,
                        ContactEmail = "guliver@mail.com",
                        MembershipFee = 200f,
                        Capacity = 200,
                        StartOfWork = new DateTime(576000),
                        EndOfWork = new DateTime(1656000),
                        Latitude = 43.5292475f,
                        Longitude = 16.4912269f,
                        AdminId = 2,
                        AdressId = 2,
                    }
                });

            builder.Entity<Admin>()
                .HasData(new List<Admin>
                {
                    new Admin
                    {
                        Id = 1,
                        Name = "Mate",
                        Email = "adminJ@mail.com",
                        Password = "adminJoker",
                        Oib = "28903610827",
                    },
                    new Admin
                    {
                        Id = 2,
                        Name = "Ivan",
                        Email = "adminG@mail.com",
                        Password = "adminGuliver",
                        Oib = "10927489362",
                    }
                });


            builder.Entity<Adress>()
                .HasData(new List<Adress>
                {
                    new Adress
                    {
                        Id = 1,
                        City = "Split",
                        Street = "Put Brodarice",
                        StreetNumber = 6,
                    },
                    new Adress
                    {
                        Id = 2,
                        City = "Split",
                        Street = "Ul. Bilice II",
                        StreetNumber = 53,
                    }
                });
        }
    }
}
