using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Xml;
using System.Collections;

namespace CBusNoti
{
    public static class CXMLProc
    {
        // 웹 페이지 호출
        public static string GetRequestWeb(string url, Encoding encType)
        {
            WebClient client = new WebClient();
            client.Encoding = encType;
            string text = client.DownloadString(url);

            return text;
        }

        // 결과 xml dictionary로 리턴
        public static Dictionary<string, string> ParseXMLForDic(string xmlMessage, string rootElement)
        {

            Dictionary<string, string> dicParam = new Dictionary<string, string>();

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlMessage);

                XmlNodeList nodeList = xmlDoc.GetElementsByTagName(rootElement);
                XmlNode node = nodeList[0];
                if (nodeList.Count <= 0)
                {
                    return null;
                }

                int nCnt = 0;
                string strName = "";
                string strValue = "";

                while (node.ChildNodes.Count > nCnt)
                {
                    strName = node.ChildNodes[nCnt].LocalName;
                    strValue = node.ChildNodes[nCnt].InnerText;

                    dicParam.Add(strName, strValue);
                    nCnt++;
                }

                return dicParam;

            }
            catch (Exception ex)
            {
                string strErr = ex.ToString();
            }

            return null;
        }

        // 결과 xml ArrayList로 리턴
        public static ArrayList ParseXMLForArrayList(string xmlMessage, string rootElement)
        {
            ArrayList rsList = new ArrayList();

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlMessage);

                XmlNodeList nodeList = xmlDoc.GetElementsByTagName(rootElement);
                if (nodeList.Count <= 0)
                {
                    return null;
                }

                foreach (XmlNode node in nodeList)
                {
                    int nCnt = 0;
                    string strName = "";
                    string strValue = "";

                    Dictionary<string, string> dicParam = new Dictionary<string, string>();

                    while (node.ChildNodes.Count > nCnt)
                    {
                        strName = node.ChildNodes[nCnt].LocalName;
                        strValue = node.ChildNodes[nCnt].InnerText;

                        dicParam.Add(strName, strValue);
                        nCnt++;
                    }

                    rsList.Add(dicParam);
                }

                return rsList;

            }
            catch (Exception ex)
            {
                string strErr = ex.ToString();
            }

            return null;
        }

    }
}
