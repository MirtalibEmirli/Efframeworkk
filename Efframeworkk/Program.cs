using Efframeworkk;
using Efframeworkk.Data;
using System.Configuration;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


//ORM
/*
*/


//ADO
var author1 = new Author
{
    Id = 151,
    FirstName="Mark",
    LastName="revan"
};
var context = new LibraryDbContext();
var authors = context.Authors .Where(b => b.FirstName.Contains("e")).ToList();
authors.ForEach(a => Console.WriteLine(a.LastName));

//context.Add(author1) ;
//context.SaveChanges();

var a = context.Authors.FirstOrDefault(a=> a.Id==15);
if(a is not null)
{
    a.FirstName = "Revan tutagaci";
    context.Update(a);
    context.Authors.Remove(a);
    context.SaveChanges();

}
/*
SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
    SqlDataReader sqlDataReader = null;
try
{

    connection.Open();
    var query = "Select FirstName from Authors";
    var command = new SqlCommand(cmdText: query, connection);
    sqlDataReader = command.ExecuteReader();
    while (sqlDataReader.Read())
    {
        Console.WriteLine(sqlDataReader["firstname"]);
    }

}
finally
{
    connection.Close();
    sqlDataReader.Close();
}*/


