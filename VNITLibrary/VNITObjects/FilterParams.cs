namespace VNITLibrary
{
    public class FilterParams
    {
        public string KeyWord { get; set; }
        public int CatId { get; set; }
        public int Status { get; set; }
        public int ModuleId { get; set; }
        public int ObjID { get; set; }
        public string ObjType { get; set; }
        public string ObjField { get; set; }
        public int LangID { get; set; }

        public FilterParams()
        {
            KeyWord = string.Empty;
            CatId = 0;
            Status = 1;
            ModuleId = 0;
            ObjID = 0;
            ObjType = string.Empty;
            ObjField = string.Empty;
        }
    }
}
