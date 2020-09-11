using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace 一键启动.Utils
{
    class ConfigFileAccess
    {
        static string context = Application.StartupPath;
        string path = string.Concat(context, @"\Configs\Config.config");
        XmlDocument xml = new XmlDocument();

        /// <summary>
        /// 获取
        /// </summary>
        /// <returns></returns>
        public List<ProgramModel> readConfig()
        {
            try
            {
                xml.Load(path);
                XmlElement root = xml.DocumentElement;
                if (root != null)
                {
                    XmlNodeList xnl = root.ChildNodes;
                    List<ProgramModel> proList = new List<ProgramModel>();
                    foreach (XmlNode xn in xnl)
                    {
                        ProgramModel pm = new ProgramModel();
                        XmlElement xe = (XmlElement)xn;
                        pm.FileName = xe.GetAttribute("FileName");
                        pm.FilePath = xe.GetAttribute("FilePath");
                        pm.Count = xe.GetAttribute("Count");
                        proList.Add(pm);
                    }
                    proList = proList.Distinct().ToList();
                    return proList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        /// <summary>
        /// 写入
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public bool WriteStartPath(string FileName, string FilePath)
        {
            XmlElement theProgram = null, root = null;
            try
            {
                xml.Load(path);
                root = xml.DocumentElement;
                theProgram = xml.CreateElement("Program");

                theProgram.SetAttribute("FileName", FileName);
                theProgram.SetAttribute("Count", "1");
                theProgram.SetAttribute("FilePath", FilePath);
                root.AppendChild(theProgram);
                xml.Save(path);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "获取配置");
                return false;

            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ID"></param>
        public void DeleteNode(int Index)
        {
            try
            {
                xml.Load(path);
                XmlElement root = xml.DocumentElement;
                XmlElement xe = (XmlElement)root.SelectNodes("Program")[Index];
                if (xe != null)
                {
                    xe.ParentNode.RemoveChild(xe);
                    xml.Save(path);
                }
                else
                {
                    MessageBox.Show("凎", "删除");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "删除");
            }
        }

        /// <summary>
        /// 修改配置程序名
        /// </summary>
        /// <param name="Index"></param>
        /// <param name="FileName"></param>
        /// <param name="Count"></param>
        public void EditConfig(int Index, string FileName, string Count)
        {
            try
            {
                xml.Load(path);
                XmlElement root = xml.DocumentElement;
                XmlElement xe = (XmlElement)root.SelectNodes("Program")[Index];
                if (xe != null)
                {
                    xe.Attributes.GetNamedItem("FileName").InnerText = FileName;
                    xe.Attributes.GetNamedItem("Count").InnerText = Count;
                    xml.Save(path);
                }
                else
                {
                    MessageBox.Show("凎", "修改");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "修改");
            }
        }

        /// <summary>
        /// 启动程序
        /// </summary>
        /// <param name="Index"></param>
        /// <param name="Count"></param>
        public async void StarApp(int Index, string Count)
        {
            int count = int.Parse(Count);
            try
            {
                xml.Load(path);
                XmlElement root = xml.DocumentElement;
                XmlElement xe = (XmlElement)root.SelectNodes("Program")[Index];
                string filePath = xe.Attributes.GetNamedItem("FilePath").InnerText;
                if (count == 1)
                {
                    await Task.Run(() => System.Diagnostics.Process.Start(filePath));
                }
                else if (count > 1)
                {
                    for (int i = 0; i < count; i++)
                    {
                        await Task.Run(() => System.Diagnostics.Process.Start(filePath));
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


    }
}
