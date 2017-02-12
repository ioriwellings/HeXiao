using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public enum Digit
    {    /*  
        <select class="form-control" id="CompanyDigit" name="CompanyDigit">
                                <option value="2">保留到分，即两位小数</option>
                                <option value="1">保留到角，即一位小数</option>
                                <option value="0">保留到元，即保留到整数</option>


                            </select>
                            */
        /// <summary>
        /// 即保留到整数
        /// </summary>
        保留到元 = 0,
        /// <summary>
        /// 即两位小数
        /// </summary>
        保留到分 = 2,
        /// <summary>
        /// 即一位小数
        /// </summary>
        保留到角 = 1
    }
  
}
