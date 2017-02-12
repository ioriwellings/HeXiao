using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Langben.BLL
{
    public partial class CalculateResult
    {
        string c = string.Empty;
        public string Value { get; set; }
        public string Calculate
        {
            get { return c; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    this.Red = true;
                }
                else
                {
                    c = value;
                    decimal d = 0;
                    decimal e = 0;
                    string f = string.Empty;
                    string g = string.Empty;

                    if (value.Contains('%'))
                    {
                        f = value.Remove(value.IndexOf('%'));
                    }
                    else
                    {
                        f = value;
                    }
                    if (this.Value.Contains('%'))
                    {
                        g = this.Value.Remove(this.Value.IndexOf('%'));
                    }
                    else
                    {
                        g = this.Value;
                    }
                    if (Decimal.TryParse(f, out d) && Decimal.TryParse(g, out e))
                    {
                        if (d != e)
                        {
                            this.Red = true;
                        }
                        else
                        {
                            this.Red = false;
                        }
                    }
                }
            }
        }
        public string Percent { get; set; }
        public bool Red { get; set; }

    }
}
