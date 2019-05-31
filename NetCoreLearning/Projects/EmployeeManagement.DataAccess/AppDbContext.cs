/*-----------------------------------------------------------------
 *   Domain Name:     Ivan_Zhang
 *   Namespace:       EmployeeManagement.DataAccess     
 *   Machine Name:    IVAN_ZHANG
 *   Project Name:    $projectname$
 *   Description:     <Description>
 *   Author:          Ivan                    Date: <5/30/2019 9:28:47 PM>
 *   Notes:           <Notes>
 *   Revision History:
 *   Name:           Date:          Description:
 *-----------------------------------------------------------------
 */
using System;
using System.Collections.Generic;
using System.Text;
using EmployeeManagement.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.DataAccess
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions):base(dbContextOptions)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
