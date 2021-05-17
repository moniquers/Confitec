using System.ComponentModel;

namespace Confitec.Domain.Model
{
    public enum EducationLevel
    {
        [Description("Infantil")]
        ElementarySchool = 1,

        [Description("Fundamental")]
        MiddleSchool = 2,

        [Description("Médio")]
        HighSchool = 3,

        [Description("Superior")]
        College = 4,
    }
}

