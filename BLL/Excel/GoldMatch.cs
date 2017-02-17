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
    public static partial class GoldMatch
    {


        public static string Make(DAL.MatchResult entity)
        {
            string err = string.Empty;
            try
            {
                string pathmy = @"D:\SheBaoHeXiao\App";

                HSSFWorkbook _book = new HSSFWorkbook();
                string xlsPath = pathmy + entity.GoldTempFullPath;
                FileStream file = new FileStream(xlsPath, FileMode.Open, FileAccess.Read);
                IWorkbook workbook = WorkbookFactory.Create(file);
                ISheet sheet = workbook.GetSheetAt(0);
                ICell cell;
                //获取设置的规则
                var detail = new MatchDetailBLL().GetByRefRuleId(entity.RuleId);
                //读取excel，第一个，基础文件
                List<MatchStand> listBase = new List<MatchStand>();
                MatchStand standardBase = null;

                //循环excel的行数
                for (int i = 2; i <= sheet.LastRowNum; i++)
                {
                    standardBase = new MatchStand();

                    //标准模板
                    foreach (var item in detail)
                    {
                        int lie = (int)item.BaseExcel;

                        standardBase.list.Add(lie, new CalculateResult());

                        cell = sheet.GetRow(i).GetCell(lie - 1);
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
                                        standardBase[lie].Value += string.Format("{0:" + formatCode + "}", cell.NumericCellValue);//得到5.88%
                                        standardBase[lie].Percent = formatCode;

                                    }
                                    else
                                    {
                                        standardBase[lie].Value += cell.NumericCellValue;
                                    }

                                    break;
                                case CellType.String:
                                    standardBase[lie].Value += cell.StringCellValue;
                                    break;
                                case CellType.Formula:
                                    standardBase[lie].Value += cell.NumericCellValue;
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
                    standardBase.Calculate();
                    listBase.Add(standardBase);

                }

                //读取excel，第2个，对比文件
                xlsPath = pathmy + entity.BaseFullPath;
                file = new FileStream(xlsPath, FileMode.Open, FileAccess.Read);
                workbook = WorkbookFactory.Create(file);
                sheet = workbook.GetSheetAt(0);
                List<MatchStand> listMatch = new List<MatchStand>();
                MatchStand standardMatch = null;
                 
                //循环excel的行数
                for (int i = 2; i <= sheet.LastRowNum; i++)
                {
                    standardMatch = new MatchStand();

                    //标准模板
                    foreach (var item in detail)
                    {
                        int lie = (int)item.BaseExcel;

                        standardMatch.list.Add(lie, new CalculateResult());

                        cell = sheet.GetRow(i).GetCell(lie - 1);
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
                                        standardMatch[lie].Value += string.Format("{0:" + formatCode + "}", cell.NumericCellValue);//得到5.88%
                                        standardMatch[lie].Percent = formatCode;

                                    }
                                    else
                                    {
                                        standardMatch[lie].Value += cell.NumericCellValue;
                                    }

                                    break;
                                case CellType.String:
                                    standardMatch[lie].Value += cell.StringCellValue;
                                    break;
                                case CellType.Formula:
                                    standardMatch[lie].Value += cell.NumericCellValue;
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
                    standardMatch.Calculate();
                    listMatch.Add(standardMatch);

                }


                //写入excel

                //string xlsxPath = @"D:\HeXiao\Solution\App\up\standard\5.xlsx";

                string xlsxPath = pathmy + @"\up\standard\" + entity.Vertion + ".xlsx";

                FileStream fileStandard = new FileStream(xlsxPath, FileMode.Open, FileAccess.Read);
                IWorkbook workbookStandard = WorkbookFactory.Create(fileStandard);
                ISheet sheetfileStandard = workbookStandard.GetSheetAt(0);
                //红色单元格
                ICellStyle style = null;


                ISheet sheetfileStandard1 = workbookStandard.GetSheetAt(1);


                for (int i = 0; i < listBase.Count; i++)
                {
                    var dataRow = sheetfileStandard.CreateRow(i + 2);
                    var dataRow1 = sheetfileStandard1.CreateRow(i + 2);
                    if (null != (listBase[i]))
                    {
                        foreach (var item in listBase[i].list)
                        {
                            var cellStandard = dataRow.CreateCell(item.Key - 1);
                            var cellStandard1 = dataRow1.CreateCell(item.Key - 1);
                            //红色单元格
                            style = workbookStandard.CreateCellStyle();
                            if (item.Value.Red || string.IsNullOrWhiteSpace(item.Value.Value))
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
                string xlsPathFileName = pathmy + @"\up\Result\" + saveFileName;
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
