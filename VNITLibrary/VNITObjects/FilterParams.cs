namespace VNITLibrary
{
    public class FilterParams
    {
        public string KeyWord { get; set; }
        public int ModuleId { get; set; }
        public int PostId { get; set; }
        public int CatId { get; set; }
        public int Status { get; set; }
        /***
         * Objectype sự dụng để phân biệt đối tượng khi dịch thuật, dùng cho table translate
         * tl => Thể loại, bv => Bài viết, ha => Hình ảnh, vd => Video, sp => Sản phẩm
         ***/
        public string ObjType { get; set; }
        /***         
         * ID xác nhận định danh của đối tượng
         ***/
        public int ObjID { get; set; }
        /***         
        * Field dùng để xác định thuộc tính cần dịch thuật của đối tượng, tùy người dùng quy định
        ***/
        public string ObjField { get; set; }
        public int LangID { get; set; }

        public FilterParams()
        {
            KeyWord = string.Empty;
            ModuleId = 0;
            CatId = 0;
            Status = -1;
            PostId = 0;
            ObjType = string.Empty;
            ObjID = 0;
            ObjField = string.Empty;
            LangID = 0;
        }
    }
}
