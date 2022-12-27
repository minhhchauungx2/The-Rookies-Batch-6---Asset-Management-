namespace Automation.DAO
{
    public class NewUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DOBYear { get; set; }
        public string DOBMonth { get; set; }
        public int DOBDay { get; set; }
        public string JoinedDate { get; set; }
        public int JoinedDay { get; set; }
        public int Gender { get; set; }
        public string Type { get; set; }
        public NewUser(string firstname, string lastname,
                       int DOByear, string DOBmonth, int DOBday,
                       string joinedDate, int joinedDay, int gender, string type)
        {
            FirstName = firstname;
            LastName = lastname;
            DOBYear = DOByear;
            DOBMonth = DOBmonth;
            DOBDay = DOBday;
            JoinedDate = joinedDate;
            JoinedDay = joinedDay;
            Gender = gender;
            Type = type;
        }
    }
}