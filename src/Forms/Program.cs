using System;
using System.Threading;
using System.Windows.Forms;

namespace NWebGather.Forms
{
    static class Program
    {

    /// 
    /// 处理程序异常
    /// 
    internal class ThreadExceptionHandler
    {
        public void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            try
            {
                var ex = e.Exception;
                string errorMessage = "发生错误，是否终止程序，错误信息：\n\n" +
                ex.Message + "\n\n" + ex.GetType() +
                "\n\nStack Trace:\n" + ex.StackTrace;

                if (MessageBox.Show(errorMessage, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                    Application.Exit();
            }
            catch
            {
                try
                {
                    MessageBox.Show("严重错误", "严重错误",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }
        }
    }
}
