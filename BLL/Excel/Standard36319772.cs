using Langben.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Langben.BLL
{
    public partial class Standard36319772 : Standard
    {

        public override bool Calculate(DAL.MYResult entity)
        {
            /*			
                                <option value="养老保险">养老保险</option>
                                <option value="医疗保险">医疗保险</option>
                                <option value="失业保险">失业保险</option>
                                <option value="工伤保险">工伤保险</option>
                                <option value="生育保险">生育保险</option>
                                <option value="住房公积金">住房公积金</option>
                                <option value="补充养老保险">补充养老保险</option>
                                <option value="大病或者特种病">大病或者特种病</option>
*/
            //获取养老的政策
            PoliceInsuranceBLL pi = new PoliceInsuranceBLL();
            PoliceInsurance data = new PoliceInsurance();
            var policeInsurance = pi.GetByVertion(entity.Vertion, entity.InsuranceId, list[City].Value, list[InsuranceStyle].Value);
            //以下为修改的地方
            data = policeInsurance.Where(w => w.InsuranceKindId == "养老保险").FirstOrDefault();
            if (data != null)
            {
                list[10].Red = Between(data, "企业", list[10].Value);
                list[11].Calculate = data.CompanyPercent.ToString() + "%";
                list[12].Calculate = Scale(data, "企业", list[10].Value);
                list[13].Calculate = data.EmployeePercent.ToString() + "%";
                list[14].Calculate = Scale(data, "员工", list[10].Value);
                //list[11].Red = Different(data, "企业", list[11].Value);//错误配置，因为在第34行已经为其赋值了，就会自动对比是否相同
            
            }

            data = policeInsurance.Where(w => w.InsuranceKindId == "医疗保险").FirstOrDefault();
            if (data != null)
            {
                list[15].Red = Between(data, "企业", list[15].Value);
                list[16].Calculate = data.CompanyPercent.ToString() + "%";
                list[17].Calculate = Scale(data, "企业", list[15].Value);
                list[18].Calculate = data.EmployeePercent.ToString() + "%";
                list[19].Calculate = Scale(data, "员工", list[15].Value);
      
            }

            data = policeInsurance.Where(w => w.InsuranceKindId == "失业保险").FirstOrDefault();
            if (data != null)
            {
                list[20].Red = Between(data, "企业", list[20].Value);
                list[21].Calculate = data.CompanyPercent.ToString() + "%";
                list[22].Calculate = Scale(data, "企业", list[20].Value);
                list[23].Calculate = data.EmployeePercent.ToString() + "%";
                list[24].Calculate = Scale(data, "员工", list[20].Value);
            
            }

            data = policeInsurance.Where(w => w.InsuranceKindId == "生育保险").FirstOrDefault();
            if (data != null)
            {
                list[25].Red = Between(data, "企业", list[25].Value);
                list[26].Calculate = data.CompanyPercent.ToString() + "%";
                list[27].Calculate = Scale(data, "企业", list[25].Value);
                
            }

            data = policeInsurance.Where(w => w.InsuranceKindId == "工伤保险").FirstOrDefault();
            if (data != null)
            {
                list[28].Red = Between(data, "企业", list[28].Value);
                list[29].Calculate = data.CompanyPercent.ToString() + "%";
                list[30].Calculate = Scale(data, "企业", list[28].Value);
          
            }

            data = policeInsurance.Where(w => w.InsuranceKindId == "住房公积金").FirstOrDefault();
            if (data != null)
            {
                list[31].Red = Between(data, "企业", list[31].Value);
                list[32].Calculate = data.CompanyPercent.ToString() + "%";
                list[33].Calculate = Scale(data, "企业", list[31].Value);
                list[34].Calculate = data.EmployeePercent.ToString() + "%";
                list[35].Calculate = Scale(data, "员工", list[31].Value);
         
            }
            return true;
        }
        /// <summary>
        /// 缴纳地
        /// </summary>
        public int City { get { return 2; } }
        /// <summary>
        /// 参保类型
        /// </summary>
        public int InsuranceStyle { get { return 5; } }

    }

}
