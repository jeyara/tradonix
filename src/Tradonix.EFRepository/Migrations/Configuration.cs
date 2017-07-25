﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tradonix.EFRepository.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TradonixContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TradonixContext context)
        {

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            //context.Setting.AddOrUpdate(new Core.Entities.Setting { Id = 1, Key = "SendGridEmailFrom", Value = "tradonix@jeyara.com" });
        }
    }
}
