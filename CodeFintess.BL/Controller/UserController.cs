using CodeFintess.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CodeFintess.BL.Controller
{
    /// <summary>
    /// Controller Users
    /// </summary>
    public class UserController
    {

        /// <summary>
        /// Users app
        /// </summary>
        public List<User> Users { get; }
        public User CurrentUser { get; }
        public bool ISNewUser { get; } = false;

        /// <summary>
        /// Created new controller users
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserController(string userName)
        {
            if(string .IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("The username cannot be empty", nameof(userName));
            }

            Users = GetUsersData(); ;

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName); 

            if(CurrentUser == null) 
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                ISNewUser = true;
                Save();
            }

        }

        /// <summary>
        /// Get list users
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length> 0 && formatter.Deserialize(fs) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
            }
        }

        public void SetNewUserData(string genderName, DateTime birtDate, double weight = 1, double height = 1)
        {
          //Check
          
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birtDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }

        /// <summary>
        /// Created data users
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using(var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }
        }
    }
}
