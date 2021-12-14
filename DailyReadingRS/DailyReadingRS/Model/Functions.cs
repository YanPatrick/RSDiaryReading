using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSDiaryReading.Model
{
    public class Functions
    {
        public int CInt(object valor)
        {
            try
            {
                return Convert.ToInt16(valor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public long CLng(object valor)
        {
            try
            {
                return Convert.ToInt64(valor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public double CDbl(object valor)
        {
            try
            {
                return Convert.ToDouble(valor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool CBool(object Objeto)
        {
            int resultado;

            if (int.TryParse(Convert.ToString(Objeto), out resultado))
            {
                return Convert.ToBoolean(resultado);
            }
            else
            {
                return Convert.ToBoolean(Objeto);
            }
        }

        public bool IsNumeric(string strNumero)
        {
            double result;

            if (double.TryParse(strNumero, out result))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool IsValidTime(string thetime)
        {

            DateTime time;

            //string timeStr = "23:00";

            if (DateTime.TryParse(thetime, out time))
            {
                return true;
            }

            return false;
        }

        public string FormataData(DateTime data)
        {
            return data.ToString("dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-br"));
        }

        public string ExibirMesPorExtenso(DateTime data)
        {
            return data.ToString("MMMM", CultureInfo.CreateSpecificCulture("en"));
        }

        public string RetornaNumeroMes(string strMes)
        {
            switch (strMes)
            {
                case "JANUARY":
                    return "01";
                case "FEBRUARY":
                    return "02";
                case "MARCH":
                    return "03";
                case "APRIL":
                    return "04";
                case "MAY":
                    return "05";
                case "JUNE":
                    return "06";
                case "JULY":
                    return "07";
                case "AUGUST":
                    return "08";
                case "SEPTEMBER":
                    return "09";
                case "OCTOBER":
                    return "10";
                case "NOVEMBER":
                    return "11";
                case "DECEMBER":
                    return "12";
                default:
                    return "";
            }
        }

        public double TotalLineNumeric(DataGridView dg, int col)
        {
            double sum = 0;

            for (int i = 0; i < dg.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dg.Rows[i].Cells[col].Value);
            }

            return sum;
        }

        public long TotalLineLong(DataGridView dg, int col)
        {
            long sum = 0;

            for (int i = 0; i < dg.Rows.Count; ++i)
            {
                sum += Convert.ToInt64(dg.Rows[i].Cells[col].Value);
            }

            return sum;
        }

        public string RetornaVersaoSistema(bool formataComUmaCasa = true)
        {
            System.Version version;

            try
            {
                version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

                if (formataComUmaCasa)
                {
                    return String.Format("{0}.{1}.{2}", version.Major, version.Minor, version.Build);
                }
                else
                {
                    return String.Format("{0:000}.{1:000}.{2:000}", version.Major, version.Minor, version.Build).Replace(".", "");
                }
            }
            catch (Exception ex)
            {
                return "0.0.0";
            }
        }

        #region retornos das linhas

        public long retornaStarbitsLinha(string strLinha)
        {
            string result;

            result = Regex.Match(strLinha, @"\d+ STARBITS").Value;

            return int.Parse(result.Split(' ')[0]);
        }

        public long retornaEgoLinha(string strLinha)
        {
            string result;

            result = Regex.Match(strLinha, @"\d+ EGO").Value;

            return int.Parse(result.Split(' ')[0]);
        }

        public long retornaSkillLinha(string strLinha)
        {
            string result;

            result = Regex.Match(strLinha, @"\d+ SKILL").Value;

            return int.Parse(result.Split(' ')[0]);
        }

        #endregion retornos das linhas

    }
}
