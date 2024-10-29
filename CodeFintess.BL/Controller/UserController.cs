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
        public User User { get; }

        /// <summary>
        /// Created new controller users
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserController(string userName, string genderName, DateTime birdthDay, double weight, double height)
        {
            //TODO: Check

            var gender = new Gender(genderName);
            User = new User(userName, gender, birdthDay, weight, height);
        }

        /// <summary>
        /// Load data users
        /// </summary>
        /// <returns>Users app</returns>
        /// <exception cref="FileLoadException"></exception>
        public UserController()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
                //TODO: What work if users not reading
            }
        }

        /// <summary>
        /// Created data users
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using(var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }
    }
}
