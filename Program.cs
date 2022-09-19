using Microsoft.EntityFrameworkCore;

namespace EntityAdvansedOneProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (AppContext appContext = new AppContext())
            {
                appContext.Database.EnsureDeleted();
                appContext.Database.EnsureCreated();

                Company company1 = new Company() { Name = "Yandex" };
                Company company2 = new Company() { Name = "Mail Group" };
                appContext.Companies.AddRange(company1, company2);

                User user1 = new User() { Login = "login1", Password = "password1", Company = company1 };
                User user2 = new User() { Login = "login2", Password = "password2", Company = company2 };
                User user3 = new User() { Login = "login3", Password = "password3", Company = company1 };
                User user4 = new User() { Login = "login4", Password = "password4", Company = company2 };
                appContext.Users.AddRange(user1, user2, user3, user4);

                UserProfile profile1 = new() { Name = "Bob", User = user1 };
                UserProfile profile2 = new() { Name = "Joe", User = user2 };
                UserProfile profile3 = new() { Name = "Sam", User = user3 };
                UserProfile profile4 = new() { Name = "Tim", User = user4 };
                appContext.UserProfiles.AddRange(profile1, profile2);

                appContext.SaveChanges();
            }

            //// output info
            //using (AppContext appContext = new AppContext())
            //{
            //    var users = appContext.Users
            //                            .Include(u => u.Profile).ToList();
                
            //    foreach(var user in users)
            //        Console.WriteLine($"{user.Profile?.Name} {user.Login} {user.Password}");
            //}

            ////edit
            //using (AppContext appContext = new AppContext())
            //{
            //    User? user = appContext.Users.FirstOrDefault();
            //    if (user != null)
            //    {
            //        user.Password = "qwerty";
            //        appContext.SaveChanges();
            //    }

            //    UserProfile? profile = appContext.UserProfiles.FirstOrDefault(p => p.User.Login == "login2");
            //    if (profile != null)
            //    {
            //        profile.Name = "Sam";
            //        appContext.SaveChanges();
            //    }
            //}

            //Console.WriteLine("---------------------------");
            //// output info
            //using (AppContext appContext = new AppContext())
            //{
            //    var users = appContext.Users
            //                            .Include(u => u.Profile).ToList();

            //    foreach (var user in users)
            //        Console.WriteLine($"{user.Profile?.Name} {user.Login} {user.Password}");
            //}

            //// delete
            //using (AppContext appContext = new AppContext())
            //{
            //    User? user = appContext.Users.FirstOrDefault();
            //    if (user != null)
            //    {
            //        appContext.Users.Remove(user);
            //        appContext.SaveChanges();
            //    }

            //    //UserProfile? profile = appContext.UserProfiles.FirstOrDefault(p => p.User.Login == "login2");
            //    //if (profile != null)
            //    //{
            //    //    appContext.UserProfiles.Remove(profile);
            //    //    appContext.SaveChanges();
            //    //}
            //}

            //Console.WriteLine("---------------------------");
            //// output info
            //using (AppContext appContext = new AppContext())
            //{
            //    var users = appContext.Users
            //                            .Include(u => u.Profile).ToList();

            //    foreach (var user in users)
            //        Console.WriteLine($"{user.Profile?.Name} {user.Login} {user.Password}");
            //}

        }
    }
}