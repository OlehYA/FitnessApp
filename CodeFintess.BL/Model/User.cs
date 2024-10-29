using System;

namespace CodeFintess.BL.Model
{
    /// <summary>
    /// User
    /// </summary>
    [Serializable]
    public class User
    {
        #region Propertis
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gender
        /// </summary>
        public Gender Gender { get; }

        /// <summary>
        /// BirthDate
        /// </summary>
        public DateTime BirthDate { get; }

        /// <summary>
        /// Weight
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Height
        /// </summary>
        public double Height { get; set; }
        #endregion

        /// <summary>
        /// Created new Users
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="gender">Gender</param>
        /// <param name="birthDate">BirthDate</param>
        /// <param name="weight">Weight</param>
        /// <param name="height">Height</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public User(string name,
                    Gender gender,
                    DateTime birthDate,
                    double weight,
                    double height)
        {
            #region Checking the condition
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name cannot be empty or null.", nameof(name));
            }

            if (gender == null)
            {
                throw new ArgumentNullException("Gender cannot be empty or null.", nameof(gender));
            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Date of birth is not valid.", nameof(birthDate));
            }

            if (weight <= 0)
            {
                throw new ArgumentException("Weight cannot be less than or equal to zero.", nameof(weight));
            }

            if (height <= 0)
            {
                throw new ArgumentException("The growth cannot be less than or equal to zero.", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;

        }

        public override string ToString()
        {
            return Name;
        }

    }
}
