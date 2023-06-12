namespace DAL.Migrations
{
    using DAL.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.CMS_db>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.CMS_db context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            Random random = new Random();

            //for (int i = 1; i <= 200; i++)
            //{
            //    var deliveryDate = random.Next(1, 150) % 3 == 0 ? DateTime.Now.AddDays(random.Next(1, 3)) : (DateTime?)null;
            //    context.Couriers.AddOrUpdate(new Courier
            //    {
            //        ParcelType = "type_" + random.Next(1, 3),
            //        Weight = random.Next(100, 2000),
            //        ShippingCost = random.Next(150, 2501),
            //        PlacingDate = DateTime.Now.AddDays(-random.Next(1, 4)),
            //        DeliveryDate = deliveryDate,
            //        CurrentLocation = "location_" + random.Next(1, 3),
            //        FromLocation = "location_" + random.Next(1, 3),
            //        Destination = "destination_" + random.Next(1, 4),
            //        ETA = random.Next(1, 5),
            //        Status = (deliveryDate != null) ? "Delivered" : (random.Next(1, 70) % 2 == 0 ? "Processing" : "On the way"),
            //    });
            //}

            //for (int i = 1; i <= 200; i++)
            //{
            //    context.CustomerInfos.AddOrUpdate(new CustomerInfo
            //    {
            //        ConsignmentNo = i,
            //        SenderName = "sndName_" + i,
            //        SenderMobile = $"011{i + 1}{i + 2}{i + 3}{i}",
            //        SenderAddress = "sndAdd_" + i,
            //        ReceiverName = "rcvName_" + i,
            //        ReceiverMobile = $"012{i + 1}{i + 2}{i + 3}{i}",
            //        ReceiverAddress = "rcvAdd_" + i
            //    });
            //}
            //for (int i = 1; i <= 5; i++)
            //{
            //    context.Admins.AddOrUpdate(new Admin
            //    {
            //        Name = "Admin_" + i,
            //        Mobile = $"0111{i + 1}{i + 2}{i + 3}{i}",
            //        Email = $"admin{i}@gmail.com",
            //        Username = $"admin{i}"
            //    });
            //}

            //for (int i = 1; i <= 5; i++)
            //{
            //    context.Users.AddOrUpdate(new User
            //    {
            //        Username = $"admin{i}",
            //        Password = "1234",
            //        UserType = "Admin"
            //    });
            //}
        }
    }
}
