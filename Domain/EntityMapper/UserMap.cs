using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntityMapper
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            

            builder.HasKey(x => x.UserID);
            builder.Property(x => x.UserID).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Role).WithMany(y => y.Users).HasForeignKey(x => x.RoleID);
                   


            // foreign key -> User has one Role but Role can have multiple users and foreign key is added.

            //    builder.HasOne(x => x.Role).WithMany(y => y.Users).HasForeignKey("User_RoleID");



        }
    }

}