using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFintess.BL.Model
{
    /// <summary>
    /// Gender
    /// </summary>
    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Created new Gender
        /// </summary>
        /// <param name="name">Name Gender</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Gender name cannot be empty or null", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
