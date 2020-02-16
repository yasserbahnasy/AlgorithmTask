using AlgorithmTaskYasserBahnasy.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(AlgorithmTaskYasserBahnasy.Startup))]
namespace AlgorithmTaskYasserBahnasy
{
    public partial class Startup
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateDefaultRolesAndUsers();
            CreateDefaultDepartment();
        }

        public void CreateDefaultRolesAndUsers()
        {
            var roleManger = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            IdentityRole role = new IdentityRole();
            IdentityRole role2 = new IdentityRole();
            IdentityRole role3 = new IdentityRole();
            
            if (!roleManger.RoleExists("SuperAdmin"))
            {
                role.Name = "SuperAdmin";
                roleManger.Create(role);
                role2.Name = "Admin";
                roleManger.Create(role2);

                role3.Name = "User";
                roleManger.Create(role3);

                ApplicationUser user = new ApplicationUser();
                user.UserName = "user";
                user.Email = "maile@gmail.com";
                var check = userManager.Create(user, "user");
                if (check.Succeeded)
                {
                    userManager.AddToRole(user.Id, "SuperAdmin");
                }


                
            }
        }

        public void CreateDefaultDepartment()
        {
            Depart dep1 = new Depart()
            {
                DepName = "New Department",
                ManagerId = "3509be8d-77e8-4287-867a-c27ffc27061a",
                Employees = new List<Employee>()
               {
                   new Employee()
                   {
                       FirstName = "user1", LastName = "user1",EmployeeImage = "default.png"
                       ,DOB= DateTime.Parse("2/11/1999 12:00:00 AM"),HiringDate= DateTime.Parse("2/11/1999 12:00:00 AM")
                   },
                   new Employee()
                   {
                       FirstName = "user2", LastName = "user2",EmployeeImage = "default.png"
                       ,DOB= DateTime.Parse("2/11/1999 12:00:00 AM"),HiringDate= DateTime.Parse("2/11/1999 12:00:00 AM")
                   },
                   new Employee()
                   {
                       FirstName = "user3", LastName = "user3",EmployeeImage = "default.png"
                       ,DOB= DateTime.Parse("2/11/1999 12:00:00 AM"),HiringDate= DateTime.Parse("2/11/1999 12:00:00 AM")
                   },
                   new Employee()
                   {
                       FirstName = "user4", LastName = "user4",EmployeeImage = "default.png"
                       ,DOB= DateTime.Parse("2/11/1999 12:00:00 AM"),HiringDate= DateTime.Parse("2/11/1999 12:00:00 AM")
                   },
                   new Employee()
                   {
                       FirstName = "user5", LastName = "user6",EmployeeImage = "default.png"
                       ,DOB= DateTime.Parse("2/11/1999 12:00:00 AM"),HiringDate= DateTime.Parse("2/11/1999 12:00:00 AM")
                   },
                   new Employee()
                   {
                       FirstName = "user6", LastName = "user6",EmployeeImage = "default.png"
                       ,DOB= DateTime.Parse("2/11/1999 12:00:00 AM"),HiringDate= DateTime.Parse("2/11/1999 12:00:00 AM")
                   },
                   new Employee()
                   {
                       FirstName = "user7", LastName = "user7",EmployeeImage = "default.png"
                       ,DOB= DateTime.Parse("2/11/1999 12:00:00 AM"),HiringDate= DateTime.Parse("2/11/1999 12:00:00 AM")
                   },
                   new Employee()
                   {
                       FirstName = "user8", LastName = "user8",EmployeeImage = "default.png"
                       ,DOB= DateTime.Parse("2/11/1999 12:00:00 AM"),HiringDate= DateTime.Parse("2/11/1999 12:00:00 AM")
                   },
                   new Employee()
                   {
                       FirstName = "user9", LastName = "user9",EmployeeImage = "default.png"
                       ,DOB= DateTime.Parse("2/11/1999 12:00:00 AM"),HiringDate= DateTime.Parse("2/11/1999 12:00:00 AM")
                   },
                   new Employee()
                   {
                       FirstName = "user10", LastName = "user10",EmployeeImage = "default.png"
                       ,DOB= DateTime.Parse("2/11/1999 12:00:00 AM"),HiringDate= DateTime.Parse("2/11/1999 12:00:00 AM")
                   }
               }
            };

            Depart dep2 = new Depart()
            {
                DepName = "New Department2",
                ManagerId = "3509be8d-77e8-4287-867a-c27ffc27061a",
                Employees = new List<Employee>()
               {
                   new Employee()
                   {
                       FirstName = "user11", LastName = "user1",EmployeeImage = "default.png"
                       ,DOB= DateTime.Parse("2/11/1999 12:00:00 AM"),HiringDate= DateTime.Parse("2/11/1999 12:00:00 AM")
                   },
                   new Employee()
                   {
                       FirstName = "user12", LastName = "user2",EmployeeImage = "default.png"
                       ,DOB= DateTime.Parse("2/11/1999 12:00:00 AM"),HiringDate= DateTime.Parse("2/11/1999 12:00:00 AM")
                   },
                   new Employee()
                   {
                       FirstName = "user13", LastName = "user3",EmployeeImage = "default.png"
                       ,DOB= DateTime.Parse("2/11/1999 12:00:00 AM"),HiringDate= DateTime.Parse("2/11/1999 12:00:00 AM")
                   },
                   new Employee()
                   {
                       FirstName = "user14", LastName = "user4",EmployeeImage = "default.png"
                       ,DOB= DateTime.Parse("2/11/1999 12:00:00 AM"),HiringDate= DateTime.Parse("2/11/1999 12:00:00 AM")
                   },
                   new Employee()
                   {
                       FirstName = "user15", LastName = "user6",EmployeeImage = "default.png"
                       ,DOB= DateTime.Parse("2/11/1999 12:00:00 AM"),HiringDate= DateTime.Parse("2/11/1999 12:00:00 AM")
                   },
                   new Employee()
                   {
                       FirstName = "user16", LastName = "user6",EmployeeImage = "default.png"
                       ,DOB= DateTime.Parse("2/11/1999 12:00:00 AM"),HiringDate= DateTime.Parse("2/11/1999 12:00:00 AM")
                   },
                   new Employee()
                   {
                       FirstName = "user17", LastName = "user7",EmployeeImage = "default.png"
                       ,DOB= DateTime.Parse("2/11/1999 12:00:00 AM"),HiringDate= DateTime.Parse("2/11/1999 12:00:00 AM")
                   },
                   new Employee()
                   {
                       FirstName = "user18", LastName = "user8",EmployeeImage = "default.png"
                       ,DOB= DateTime.Parse("2/11/1999 12:00:00 AM"),HiringDate= DateTime.Parse("2/11/1999 12:00:00 AM")
                   },
                   new Employee()
                   {
                       FirstName = "user19", LastName = "user9",EmployeeImage = "default.png"
                       ,DOB= DateTime.Parse("2/11/1999 12:00:00 AM"),HiringDate= DateTime.Parse("2/11/1999 12:00:00 AM")
                   },
                   new Employee()
                   {
                       FirstName = "user20", LastName = "user20",EmployeeImage = "default.png"
                       ,DOB= DateTime.Parse("2/11/1999 12:00:00 AM"),HiringDate= DateTime.Parse("2/11/1999 12:00:00 AM")
                   }
               }
            };
            db.Departs.Add(dep1);
            db.SaveChanges();
        }


        }
}
