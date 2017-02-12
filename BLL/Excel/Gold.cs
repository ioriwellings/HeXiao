using Common;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Langben.BLL
{
    public static partial class Gold
    {


        public static string Make(DAL.MYResult entity)
        {
            string err = string.Empty;
            try
            {


                HSSFWorkbook _book = new HSSFWorkbook();
                string xlsPath = @"D:\HeXiao\Solution\App" + entity.GoldTempFullPath;
                FileStream file = new FileStream(xlsPath, FileMode.Open, FileAccess.Read);
                IWorkbook workbook = WorkbookFactory.Create(file);
                ISheet sheet = workbook.GetSheetAt(0);

                ICell cell;
                List<Standard> list = new List<Standard>();
                Standard standard = null;
                IDictionary<int, int> relation = DataFactory.CreateRelation(entity.GoldTempId);

                //循环excel的行数
                for (int i = 2; i <= sheet.LastRowNum; i++)
                {
                    standard = DataFactory.CreateStandard(entity.Vertion);
                    //标准模板
                    foreach (var item in relation.Values.Distinct())
                    {
                        standard.list.Add(item, new CalculateResult());
                    }
                    //循环
                    foreach (var item in relation)
                    {

                        cell = sheet.GetRow(i).GetCell(item.Key - 1);
                        if (cell != null)
                        {

                            switch (cell.CellType)
                            {
                                case CellType.Unknown:
                                    break;
                                case CellType.Numeric:
                                    var formatCode = cell.CellStyle.GetDataFormatString();
                                    if (formatCode.EndsWith("%"))
                                    {
                                        standard[item.Value].Value += string.Format("{0:" + formatCode + "}", cell.NumericCellValue);//得到5.88%
                                        standard[item.Value].Percent = formatCode;

                                    }
                                    else
                                    {
                                        standard[item.Value].Value += cell.NumericCellValue;
                                    }

                                    break;
                                case CellType.String:
                                    standard[item.Value].Value += cell.StringCellValue;
                                    break;
                                case CellType.Formula:
                                    standard[item.Value].Value += cell.NumericCellValue;
                                    break;
                                case CellType.Blank:
                                    break;
                                case CellType.Boolean:
                                    break;
                                case CellType.Error:
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            err = "没有这一列";
                        }

                    }
                    //进行计算
                    standard.Calculate(entity);
                    list.Add(standard);

                }
                //写入excel

                //string xlsxPath = @"D:\HeXiao\Solution\App\up\standard\5.xlsx";

                string xlsxPath = @"D:\HeXiao\Solution\App\up\standard\" + entity.Vertion + ".xlsx";

                FileStream fileStandard = new FileStream(xlsxPath, FileMode.Open, FileAccess.Read);
                IWorkbook workbookStandard = WorkbookFactory.Create(fileStandard);
                ISheet sheetfileStandard = workbookStandard.GetSheetAt(0);
                //红色单元格
                ICellStyle style = null;


                ISheet sheetfileStandard1 = workbookStandard.GetSheetAt(1);


                for (int i = 0; i < list.Count; i++)
                {
                    var dataRow = sheetfileStandard.CreateRow(i + 2);
                    var dataRow1 = sheetfileStandard1.CreateRow(i + 2);
                    if (null != (list[i]))
                    {
                        foreach (var item in list[i].list)
                        {
                            var cellStandard = dataRow.CreateCell(item.Key - 1);
                            var cellStandard1 = dataRow1.CreateCell(item.Key - 1);
                            //红色单元格
                            style = workbookStandard.CreateCellStyle();
                            if (item.Value.Red|| string.IsNullOrWhiteSpace(item.Value.Value))
                            {
                                 
                                style.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Red.Index;
                                style.FillPattern = FillPattern.SolidForeground;
                                cellStandard.CellStyle = style;
                                cellStandard1.CellStyle = style;
                            }
                            if ((!string.IsNullOrWhiteSpace(item.Value.Value)) && item.Value.Value.Contains('%'))
                            {
                                cellStandard.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat(item.Value.Percent);
                            }
                            if ((!string.IsNullOrWhiteSpace(item.Value.Calculate)) && item.Value.Calculate.Contains('%'))
                            {
                                cellStandard1.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00%");
                            }

                            cellStandard.SetCellValue(item.Value.Value);

                            if (string.IsNullOrWhiteSpace(item.Value.Calculate))
                            {
                                cellStandard1.SetCellValue(item.Value.Value);
                            }
                            else
                            {

                                cellStandard1.SetCellValue(item.Value.Calculate);
                            }

                        }
                    }
                }

                string guid = Common.Result.GetNewId();

                var saveFileName = entity.GoldTempFullPath.Path(guid);
                entity.Result = saveFileName;
                string xlsPathFileName = @"D:\HeXiao\Solution\App\up\Result\" + saveFileName;
                using (FileStream fileWrite = new FileStream(xlsPathFileName, FileMode.Create))
                {
                    workbookStandard.Write(fileWrite);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return err;
        }


    }
}
