namespace Automation.DAO
{
    public class NewAsset
    {
        public string AssetName { get; set; }
        public string Category { get; set; }
        public int InstalledYear { get; set; }
        public string InstalledMonth { get; set; }
        public int InstalledDay { get; set; }
        public string Specification { get; set; }

        public NewAsset(string assetName, string category, 
               int installedYear, string installedMonth, int installedDay,
               string specification)
        {
            AssetName = assetName;
            Category = category;
            InstalledYear = installedYear;
            InstalledMonth = installedMonth;
            InstalledDay = installedDay;
            Specification = specification;
        }
    }
}
