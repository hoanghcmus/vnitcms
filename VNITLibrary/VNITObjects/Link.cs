using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNITLibrary
{
    public class Link : BasePage
    {
        public const int TypeCustomId = 1;
        public const int TypeArticleViewId = 2;
        public const int TypeArticleCategoryId = 3;
        public const int TypeListArticleCategoryID = 4;
        public static ItemOption TypeCustom = new ItemOption(TypeCustomId, "# Người dùng định nghĩa #");
        public static ItemOption TypeArticleView = new ItemOption(TypeArticleViewId, "Chi tiết bài viết");
        public static ItemOption TypeArticleCategory = new ItemOption(TypeArticleCategoryId, "Danh sách bài viết theo thể loại");
        public static ItemOption TypeListArticleCategory = new ItemOption(TypeListArticleCategoryID, "Danh sách thể loại bài viết");
        public static List<ItemOption> GetLinkTypes()
        {
            return new List<ItemOption>
                   {
                       TypeArticleView,
                       TypeArticleCategory,
                       TypeListArticleCategory,
                       TypeCustom
                   };
        }

        //Position
        public const int Pos1Id = 1;
        public const int Pos2Id = 2;
        public const int Pos3Id = 3;
        public const int Pos4Id = 4;
        public const int Pos5Id = 5;
        public static ItemOption Pos1 = new ItemOption(Pos1Id, "Menu top");
        public static ItemOption Pos2 = new ItemOption(Pos2Id, "Menu chính");
        public static ItemOption Pos3 = new ItemOption(Pos3Id, "Menu trái");
        public static ItemOption Pos4 = new ItemOption(Pos4Id, "Menu phải");
        public static ItemOption Pos5 = new ItemOption(Pos5Id, "Menu bottom");

        public static List<ItemOption> GetPositionsStatic()
        {
            return new List<ItemOption> { Pos1, Pos2, Pos3, Pos4, Pos5 };
        }

        public static List<ItemOption> GetPositionsDynamic()
        {
            return new List<ItemOption> { Pos1, Pos2, Pos3, Pos4, Pos5 };
        }
    }
}
