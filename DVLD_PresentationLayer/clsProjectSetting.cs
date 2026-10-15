using System;

namespace CommonUseThings
{
    public static class clsProjectSetting
    {
        public static string ImageDefaultPath = AppDomain.CurrentDomain.BaseDirectory + "Images";
        public static string FilesPath = AppDomain.CurrentDomain.BaseDirectory + "Files";
        public static string FemaleDefaultImagePath = ImageDefaultPath + "\\Default_Female_Img.png";
        public static string MaleDefaultImagePath = ImageDefaultPath + "\\Default_Male_Img.png";
    }
}
