namespace Automation.DAO
{
    public class NewAssignment
    {
        public string StaffInfo { get; set; }
        public string AssetInfo { get; set; }
        public int AssignedYear { get; set; }
        public string AssignedMonth { get; set; }
        public int AssignedDay { get; set; }

        public NewAssignment(string staffCode, string assetInfo, int assignedYear, string assignedMonth, int assignedDay)
        {
            StaffInfo = staffCode;
            AssetInfo = assetInfo;
            AssignedYear = assignedYear;
            AssignedMonth = assignedMonth;
            AssignedDay = assignedDay;
        }
    }
}
