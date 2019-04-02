using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopSoft.ExcelExport.Attributes;
using TopSoft.ExcelExport.Entity;

namespace TfsTimeSheetHelper
{
    public class TimesheetExcel : ExcelRow
    {
        [CellData("A")]
        public string Project { get; set; }

        [CellData("B")]
        public string ProjectName { get; set; }

        [CellData("C")]
        public string TaskNumber { get; set; }

        [CellData("D")]
        public string TaskName { get; set; }

        [CellData("E")]
        public string Type { get; set; }

        [CellData("F")]
        public string Monday { get; set; }

        [CellData("G")]
        public string Comment1 { get; set; }

        [CellData("H")]
        public string Timefrom1 { get; set; }

        [CellData("I")]
        public string Timeto1 { get; set; }

        [CellData("J")]
        public string Tuesday { get; set; }

        [CellData("K")]
        public string Comment2 { get; set; }

        [CellData("L")]
        public string Timefrom2 { get; set; }

        [CellData("M")]
        public string Timeto2 { get; set; }

        [CellData("N")]
        public string Wednesday { get; set; }

        [CellData("O")]
        public string Comment3 { get; set; }

        [CellData("P")]
        public string Timefrom3 { get; set; }

        [CellData("Q")]
        public string Timeto3 { get; set; }

        [CellData("R")]
        public string Thursday { get; set; }

        [CellData("S")]
        public string Comment4 { get; set; }

        [CellData("T")]
        public string Timefrom4 { get; set; }

        [CellData("U")]
        public string Timeto4 { get; set; }

        [CellData("V")]
        public string Friday { get; set; }

        [CellData("W")]
        public string Comment5 { get; set; }

        [CellData("X")]
        public string Timefrom5 { get; set; }

        [CellData("Y")]
        public string Timeto5 { get; set; }

        [CellData("Z")]
        public string Saturday { get; set; }

        [CellData("AA")]
        public string Comment6 { get; set; }

        [CellData("AB")]
        public string Timefrom6 { get; set; }

        [CellData("AC")]
        public string Timeto6 { get; set; }

        [CellData("AD")]
        public string Sunday { get; set; }

        [CellData("AE")]
        public string Comment7 { get; set; }

        [CellData("AF")]
        public string Timefrom7 { get; set; }

        [CellData("AG")]
        public string Timeto7 { get; set; }
    }
}
