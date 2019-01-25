using System;
using System.Runtime.Serialization;

namespace FileInputAndOutput.Models
{
    [DataContract]
    public sealed class Account
    {
        public Account() { }

        public Account(string username, string firstname, string lastname, DateTime birthDate, int income)
        {
            Username = username;
            Firstname = firstname;
            Lastname = lastname;
            BirthDate = birthDate;
            Income = income;
        }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Firstname { get; set; }

        [DataMember]
        public string Lastname { get; set; }

        [DataMember]
        public DateTime BirthDate { get; set; }

        [DataMember]
        public int Income { get; set; }

        public override string ToString()
        {
            return $"Username: {Username}\nFirstname: {Firstname}\nLastname: {Lastname}\nBirthDate: {BirthDate}\nIncome: {Income}";
        }
    }
}
