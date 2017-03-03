using Common;
using Langben.DAL;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Langben.BLL
{
    public partial class GoldMatch
    {


        public static string Make(DAL.MatchResult entity)
        {
            string err = string.Empty;

            try
            {
                string pathmy = @"D:\SheBaoHeXiao\App";

                HSSFWorkbook _book = new HSSFWorkbook();
                string xlsPath = pathmy + entity.BaseFullPath;
                FileStream file = new FileStream(xlsPath, FileMode.Open, FileAccess.Read);
                IWorkbook workbook = WorkbookFactory.Create(file);
                ISheet sheet = workbook.GetSheetAt(0);
                ICell cell;
                //获取设置的规则
                var detail = new MatchDetailBLL().GetByRefRuleId(entity.RuleId);
                var matchs = detail.Where(w => w.BaseMatch == "匹配项设定").ToList();

                //读取excel，第一个，基础文件
                List<StandardMatch> listBase = new List<StandardMatch>();
                StandardFirst standardBase = null;

                //循环excel的行数
                for (int i = 2; i <= sheet.LastRowNum; i++)
                {
                    standardBase = new StandardFirst();

                    //标准模板
                    foreach (var item in detail)
                    {
                        int lie = (int)item.BaseExcel;

                        standardBase.list.Add(lie, new CalculateResult());
                        standardBase.Row = i;

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
                    standardBase.Calculate(matchs);
                    listBase.Add(standardBase);
                }

                //读取excel，第2个，对比文件
                xlsPath = pathmy + entity.GoldTempFullPath;
                file = new FileStream(xlsPath, FileMode.Open, FileAccess.Read);
                workbook = WorkbookFactory.Create(file);
                var sheet2 = workbook.GetSheetAt(0);
                List<StandardMatch> listMatch = new List<StandardMatch>();
                StandardSecond standardMatch = null;

                //循环excel的行数
                for (int i = 2; i <= sheet2.LastRowNum; i++)
                {
                    standardMatch = new StandardSecond();

                    //标准模板
                    foreach (var item in detail)
                    {
                        int lie = (int)item.MatchExcel;
                        standardMatch.Row = i;

                        standardMatch.list.Add(lie, new CalculateResult());

                        cell = sheet2.GetRow(i).GetCell(lie - 1);
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
                    standardMatch.Calculate(matchs);
                    listMatch.Add(standardMatch);

                }

                // 基础集合
                var dataBase = from m in listBase select m.Condition;
                var dataMatch = from m in listMatch select m.Condition;
                //查询结果集
                List<StandardMatch> manyBase = new List<StandardMatch>();//相同匹配项存在多条数据，基础文件
                var conditions = (from n in dataBase

                                  group n by n into g
                                  where g.Count() >= 2
                                  select g.Key);
                foreach (var item in conditions)
                {
                    var data = from m in listBase where m.Condition == item select m;
                    foreach (var it in data)
                    {

                        manyBase.Add(it);
                    }
                }
                List<StandardMatch> manyMatch = new List<StandardMatch>();//相同匹配项存在多条数据，对比文件
                conditions = (from n in dataMatch

                              group n by n into g
                              where g.Count() >= 2
                              select g.Key);
                foreach (var item in conditions)
                {
                    var data = from m in listMatch where m.Condition == item select m;
                    foreach (var it in data)
                    {

                        manyMatch.Add(it);
                    }
                }
                List<StandardMatch> onlyBase = new List<StandardMatch>();//仅基础文件存在数据
                conditions = dataBase.Except(dataMatch);//差集,
                foreach (var item in conditions)
                {
                    var data = from m in listBase where m.Condition == item select m;
                    foreach (var it in data)
                    {
                        onlyBase.Add(it);

                    }
                }
                List<StandardMatch> onlyMatch = new List<StandardMatch>();//仅对比文件存在数据
                conditions = dataMatch.Except(dataBase);//差集,
                foreach (var item in conditions)
                {
                    var data = from m in listMatch where m.Condition == item select m;
                    foreach (var it in data)
                    {
                        onlyMatch.Add(it);

                    }
                }

                var purBase = listBase.Except(manyBase).Except(onlyBase);
                var purMatch = listMatch.Except(manyMatch).Except(onlyMatch);

                List<StandardMatchBaseTogether> newSame = new List<StandardMatchBaseTogether>();//完全一致数据
                List<StandardMatchBaseTogether> newDiffrent = new List<StandardMatchBaseTogether>();//存在差异项目数据
                var goldExcel = detail.Where(w => w.BaseMatch == "对比项设定");
                foreach (var item in purBase)
                {
                    var match = (from m in purMatch where m.Condition == item.Condition select m).FirstOrDefault();
                    if (match != null)
                    {
                        StandardMatchBaseTogether bm = new BLL.StandardMatchBaseTogether();
                        bm.Base = item;
                        bm.Match = match;
                        if (IsSame(goldExcel, item, match))
                        {

                            newSame.Add(bm);
                        }
                        else
                        {
                            newDiffrent.Add(bm);

                        }
                    }


                }
                //写入excel

                string xlsxPath = pathmy + @"\up\standard\result.xls";

                FileStream fileStandard = new FileStream(xlsxPath, FileMode.Open, FileAccess.Read);
                IWorkbook workbookStandard = WorkbookFactory.Create(fileStandard);

                ISheet sheetfileStandard = workbookStandard.GetSheetAt(0);
                for (int i = 0; i < 2; i++)//复制表头
                {
                    CopyRow(workbookStandard, sheetfileStandard, sheet, i, i);
                }
                for (int i = 0; i < onlyBase.Count; i++)
                {
                    CopyRow(workbookStandard, sheetfileStandard, sheet, onlyBase[i].Row, i + 2);
                }

                ICellStyle style = null;//红色单元格


                ISheet sheetfileStandard1 = workbookStandard.GetSheetAt(1);
                for (int i = 0; i < 2; i++)//复制表头
                {
                    CopyRow(workbookStandard, sheetfileStandard1, sheet2, i, i);
                }
                for (int i = 0; i < onlyMatch.Count; i++)
                {
                    CopyRow(workbookStandard, sheetfileStandard1, sheet2, onlyMatch[i].Row, i + 2);
                }

                ISheet sheetfileStandard2 = workbookStandard.GetSheetAt(2);
                bool isCol = false;
                bool isCol2 = false;
                Dictionary<int, int> flag = new Dictionary<int, int>();

                for (int i = 0; i < newDiffrent.Count; i++)
                {
                    var dataRow = sheetfileStandard2.CreateRow(i + 2);


                    int j = 0;

                    foreach (var item in newDiffrent[i].Base.list.OrderBy(o => o.Key))
                    {
                        j++;
                        var cellStandard = dataRow.CreateCell(j);

                        if (!isCol) flag.Add(item.Key, j);

                        //红色单元格
                        style = workbookStandard.CreateCellStyle();
                        if (item.Value.Red || string.IsNullOrWhiteSpace(item.Value.Value))
                        {

                            style.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Red.Index;
                            style.FillPattern = FillPattern.SolidForeground;
                            cellStandard.CellStyle = style;

                        }
                        if ((!string.IsNullOrWhiteSpace(item.Value.Value)) && item.Value.Value.Contains('%'))
                        {
                            cellStandard.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat(item.Value.Percent);
                        }
                        cellStandard.SetCellValue(item.Value.Value);

                    }
                    if (!isCol)
                    {
                        isCol = true;
                    }
                    j++;//加一列空白
                    foreach (var item in newDiffrent[i].Match.list.OrderBy(o => o.Key))
                    {
                        j++;
                        var cellStandard = dataRow.CreateCell(j);
                        if (!isCol2) flag.Add(item.Key, j);

                        //红色单元格
                        style = workbookStandard.CreateCellStyle();
                        if (item.Value.Red || string.IsNullOrWhiteSpace(item.Value.Value))
                        {

                            style.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Red.Index;
                            style.FillPattern = FillPattern.SolidForeground;
                            cellStandard.CellStyle = style;

                        }
                        if ((!string.IsNullOrWhiteSpace(item.Value.Value)) && item.Value.Value.Contains('%'))
                        {
                            cellStandard.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat(item.Value.Percent);
                        }
                        cellStandard.SetCellValue(item.Value.Value);

                    }
                    if (!isCol2)
                    {
                        isCol2 = true;
                    }
                }


                for (int t = 0; t < 2; t++)//复制表头
                {
                    foreach (var item in flag)
                    {

                        CopyRow(workbookStandard, sheetfileStandard1, sheet2, t, t, item.Key, item.Value);

                    }

                }


                ISheet sheetfileStandard3 = workbookStandard.GetSheetAt(3);
                for (int i = 0; i < newSame.Count; i++)
                {
                    var dataRow = sheetfileStandard3.CreateRow(i + 2);

                    if (null != (newSame[i]))
                    {
                        int j = 0;
                        foreach (var item in newSame[i].Base.list.OrderBy(o => o.Key))
                        {
                            j++;
                            var cellStandard = dataRow.CreateCell(j);

                            if ((!string.IsNullOrWhiteSpace(item.Value.Value)) && item.Value.Value.Contains('%'))
                            {
                                cellStandard.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat(item.Value.Percent);
                            }
                            cellStandard.SetCellValue(item.Value.Value);

                        }
                        foreach (var item in newSame[i].Match.list.OrderBy(o => o.Key))
                        {
                            j++;
                            var cellStandard = dataRow.CreateCell(j);

                            if ((!string.IsNullOrWhiteSpace(item.Value.Value)) && item.Value.Value.Contains('%'))
                            {
                                cellStandard.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat(item.Value.Percent);
                            }
                            cellStandard.SetCellValue(item.Value.Value);

                        }
                    }
                }

                ISheet sheetfileStandard4 = workbookStandard.GetSheetAt(4);
                for (int i = 0; i < 2; i++)//复制表头
                {
                    CopyRow(workbookStandard, sheetfileStandard4, sheet, i, i);
                }
                for (int i = 0; i < manyBase.Count; i++)
                {
                    CopyRow(workbookStandard, sheetfileStandard4, sheet, manyBase[i].Row, i + 2);
                }

                ISheet sheetfileStandard5 = workbookStandard.GetSheetAt(5);
                for (int i = 0; i < 2; i++)//复制表头
                {
                    CopyRow(workbookStandard, sheetfileStandard5, sheet2, i, i);
                }
                for (int i = 0; i < manyMatch.Count; i++)
                {
                    CopyRow(workbookStandard, sheetfileStandard5, sheet2, manyMatch[i].Row, i + 2);
                }


                string guid = Common.Result.GetNewId();

                var saveFileName = entity.GoldTempFullPath.Path(guid);
                entity.Result = saveFileName;
                var xlsPathFileName = pathmy + @"\up\Result\" + saveFileName;
                using (FileStream fileWrite = new FileStream(xlsPathFileName, FileMode.Create))
                {
                    workbookStandard.Write(fileWrite);
                }
                return saveFileName;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public static bool IsSame(IEnumerable<MatchDetail> detail, StandardMatch baseExcle, StandardMatch matchExcel)
        {
            bool result = true;
            foreach (var item in detail)
            {
                if (baseExcle[(int)item.BaseExcel].Value != matchExcel[(int)item.MatchExcel].Value)
                {
                    baseExcle[(int)item.BaseExcel].Red = true;
                    matchExcel[(int)item.MatchExcel].Red = true;
                    result = false;
                }
                else
                {
                    baseExcle[(int)item.BaseExcel].Red = false;
                    matchExcel[(int)item.MatchExcel].Red = false;
                }

            }

            return result;
        }


        /// <summary>
        /// 模板中所有的合并的单元格
        /// </summary>
        static Dictionary<string, List<CellRangeAddress>> returnList = new Dictionary<string, List<CellRangeAddress>>();
        /// <summary>
        ///  获取合并区域信息
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        private static Dictionary<string, List<CellRangeAddress>> GetMergedCellRegion(ISheet sheet)
        {
            if (!returnList.ContainsKey(sheet.SheetName))
            {
                int mergedRegionCellCount = sheet.NumMergedRegions;
                List<CellRangeAddress> cellList = new List<CellRangeAddress>();

                for (int i = 0; i < mergedRegionCellCount; i++)
                {
                    cellList.Add(sheet.GetMergedRegion(i));
                }
                returnList.Add(sheet.SheetName, cellList);

            }


            return returnList;
        }
        /// <summary>
        /// 获取合并单元格的坐标范围
        /// </summary>
        /// <param name="sheet">sheet</param>
        /// <param name="columnIndex"></param>
        /// <param name="rowIndex"></param> 
        /// <returns>合并单元格的范围</returns>
        public static CellRangeAddress getMergedRegionCell(ISheet sheet, int columnIndex, int rowIndex)
        {
            List<CellRangeAddress> result = null;
            if (!returnList.ContainsKey(sheet.SheetName))
            {
                GetMergedCellRegion(sheet);

            }
            result = returnList[sheet.SheetName];
            return (from c in result
                    where columnIndex >= c.FirstColumn && columnIndex <= c.LastColumn && rowIndex >= c.FirstRow && rowIndex <= c.LastRow
                    select c).FirstOrDefault();

        }
        /// <summary>
        /// HSSFRow Copy Command
        /// 
        /// Description:  Inserts a existing row into a new row, will automatically push down
        ///               any existing rows.  Copy is done cell by cell and supports, and the
        ///               command tries to copy all properties available (style, merged cells, values, etc...)
        /// </summary>
        /// <param name="workbook">Workbook containing the worksheet that will be changed</param>
        /// <param name="destinationsheet">WorkSheet containing rows to be copied</param>
        /// <param name="sourceRowNum">Source Row Number</param>
        /// <param name="destinationRowNum">Destination Row Number</param>
        private static void CopyRow(IWorkbook workbook, ISheet destinationsheet, ISheet sourcesheet, int sourcerow, int destinationRowNum)
        {
            // Get the source / new row
            var newRow = destinationsheet.CreateRow(destinationRowNum);
            var sourceRow = sourcesheet.GetRow(sourcerow);
            if (sourceRow == null)
            {
                return;
            }
            var newCellStyle = workbook.CreateCellStyle();
            int startMergeCell = -1; //记录每行的合并单元格起始位置
            // Loop through source columns to add to new row
            for (int i = 0; i < sourceRow.LastCellNum; i++)
            {
                // Grab a copy of the old/new cell
                var sourceCell = sourceRow.GetCell(i);
                var newCell = newRow.CreateCell(i);

                // If the old cell is null jump to next cell
                if (sourceCell == null)
                {
                    newCell = null;
                    continue;
                }

                // Copy style from old cell and apply to new cell

                newCellStyle.CloneStyleFrom(sourceCell.CellStyle);
                newCell.CellStyle = newCellStyle;

                // If there is a cell comment, copy
                if (newCell.CellComment != null) newCell.CellComment = sourceCell.CellComment;

                // If there is a cell hyperlink, copy
                if (sourceCell.Hyperlink != null) newCell.Hyperlink = sourceCell.Hyperlink;

                // Set the cell data type
                newCell.SetCellType(sourceCell.CellType);

                // Set the cell data value
                switch (sourceCell.CellType)
                {
                    case CellType.Blank:
                        newCell.SetCellValue(sourceCell.StringCellValue);
                        break;
                    case CellType.Boolean:
                        newCell.SetCellValue(sourceCell.BooleanCellValue);
                        break;
                    case CellType.Error:
                        newCell.SetCellErrorValue(sourceCell.ErrorCellValue);
                        break;
                    case CellType.Formula:
                        newCell.SetCellFormula(sourceCell.CellFormula);
                        break;
                    case CellType.Numeric:
                        newCell.SetCellValue(sourceCell.NumericCellValue);
                        break;
                    case CellType.String:
                        newCell.SetCellValue(sourceCell.RichStringCellValue);
                        break;
                    case CellType.Unknown:
                        newCell.SetCellValue(sourceCell.StringCellValue);
                        break;
                }
                #region 新合并方式                   
                if (sourceCell.IsMergedCell)
                {
                    CellRangeAddress cellAddress = getMergedRegionCell(sourcesheet, i, sourceRow.RowNum);//此处有错
                    if (cellAddress != null && cellAddress.LastColumn > startMergeCell && (cellAddress.LastRow > cellAddress.FirstRow || cellAddress.LastColumn > cellAddress.FirstColumn))
                    {
                        if (sourceRow.RowNum == cellAddress.LastRow)
                        {
                            destinationsheet.AddMergedRegion(new CellRangeAddress(i - (cellAddress.LastRow - cellAddress.FirstRow), i, cellAddress.FirstColumn, cellAddress.LastColumn));
                            startMergeCell = cellAddress.LastColumn + 1;
                        }

                    }

                }

                #endregion

            }
            //列合并，以下为复制模板行的单元格合并格式                    



        }
        private static void CopyRow(IWorkbook workbook, ISheet destinationsheet, ISheet sourcesheet, int sourcerow, int destinationRowNum, int sourceCol, int destinationCol)
        {
            // Get the source / new row
            var newRow = destinationsheet.CreateRow(destinationRowNum);
            var sourceRow = sourcesheet.GetRow(sourcerow);
            if (sourceRow == null)
            {
                return;
            }
            var newCellStyle = workbook.CreateCellStyle();

            // Grab a copy of the old/new cell
            var sourceCell = sourceRow.GetCell(sourceCol);
            var newCell = newRow.CreateCell(destinationCol);

            // If the old cell is null jump to next cell
            if (sourceCell == null)
            {
                newCell = null;
                return;
            }

            // Copy style from old cell and apply to new cell

            newCellStyle.CloneStyleFrom(sourceCell.CellStyle);
            newCell.CellStyle = newCellStyle;

            // If there is a cell comment, copy
            if (newCell.CellComment != null) newCell.CellComment = sourceCell.CellComment;

            // If there is a cell hyperlink, copy
            if (sourceCell.Hyperlink != null) newCell.Hyperlink = sourceCell.Hyperlink;

            // Set the cell data type
            newCell.SetCellType(sourceCell.CellType);

            // Set the cell data value
            switch (sourceCell.CellType)
            {
                case CellType.Blank:
                    newCell.SetCellValue(sourceCell.StringCellValue);
                    break;
                case CellType.Boolean:
                    newCell.SetCellValue(sourceCell.BooleanCellValue);
                    break;
                case CellType.Error:
                    newCell.SetCellErrorValue(sourceCell.ErrorCellValue);
                    break;
                case CellType.Formula:
                    newCell.SetCellFormula(sourceCell.CellFormula);
                    break;
                case CellType.Numeric:
                    newCell.SetCellValue(sourceCell.NumericCellValue);
                    break;
                case CellType.String:
                    newCell.SetCellValue(sourceCell.RichStringCellValue);
                    break;
                case CellType.Unknown:
                    newCell.SetCellValue(sourceCell.StringCellValue);
                    break;
            }

        }


    }
}
