#r "System.Configuration"
 
#r "System.Data"

using System;
 
using System.Collections;
 
using System.Configuration;
 
using System.Collections.Generic;
 
using System.Data.Entity;
 
using System.Data.Entity.ModelConfiguration.Conventions;
 
using System.Data.Entity.SqlServer;
 
using System.Threading.Tasks;
 
using System.ComponentModel.DataAnnotations;


using(var db = new PersonDbContext(ConfigurationManager.ConnectionStrings["sql_connection"].ConnectionString))
{
    var person = new Person
    {
 
        Name = "Foo",
        Age = 32
 
    };
 
    db.Persons.Add(person);
 
    db.SaveChanges();
 
}


public class Person {
 
    [Key]
 
    public int Id {get;set;}
 
    public string Name {get;set}
 
    public int Age {get;set}
 
}

public partial class PersonDbContext : System.Data.Entity.DbContext
 
{
    public PersonDbContext(string cs) : base(cs){ }
    public DbSet<Person> Persons {get;set;}
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    }
 
}