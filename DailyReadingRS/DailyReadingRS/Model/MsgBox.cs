using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSDiaryReading.Model
{
    public class MsgBox
    {
        public static void GravaLog(string erro)
        {
            throw new Exception("Error: " + erro);
        }

        public static void MostraErro(Exception e, String erro)
        {
            MessageBox.Show(null, erro + "\n\n" + e.TargetSite + ": " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //critica
        public static void Critica(Form form, String mensagem)
        {
            MessageBox.Show(form, mensagem, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //advertencia
        public static void Advertencia(Form form, String mensagem)
        {
            MessageBox.Show(form, mensagem, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void Informacao(Form form, String mensagem)
        {
            MessageBox.Show(form, mensagem, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult Pergunta(Form form, String Mensagem, string Titulo = "Information")
        {
            return MessageBox.Show(form, Mensagem, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
